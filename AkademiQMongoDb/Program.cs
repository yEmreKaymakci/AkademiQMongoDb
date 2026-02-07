using AkademiQMongoDb.Services.AdminServices;
using AkademiQMongoDb.Services.CategoryServices;
using AkademiQMongoDb.Services.ProductServices;
using AkademiQMongoDb.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// 1. Ayarlarý Yapýlandýrma (Configuration)
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection(nameof(DatabaseSettings)));

builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

// 2. Servis Kayýtlarý (Dependency Injection)
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAdminService, AdminService>();

// 3. Controller ve Yetkilendirme Politikasý
builder.Services.AddControllersWithViews(options =>
{
    // Varsayýlan olarak tüm sayfalarda yetki (login) istensin
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    options.Filters.Add(new AuthorizeFilter(policy));
});

// 4. Session Ayarlarý
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// 5. Authentication (Giriþ Ýþlemleri)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Index";
        options.LogoutPath = "/Login/Logout";
        options.Cookie.Name = "MilkyAppCookie";
        options.SlidingExpiration = true;
        options.AccessDeniedPath = "/Login/AccessDenied"; // Yetkisiz giriþler için
    });

var app = builder.Build();

// --- Middleware Hattý (Pipeline) ---

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // CSS, JS, Resimler için

app.UseRouting();

app.UseSession(); // Session Authentication'dan önce veya sonra olabilir ama Routing'den sonra olmasý iyidir.

app.UseAuthentication(); // Kimlik Doðrulama (Kimsin?)
app.UseAuthorization();  // Yetkilendirme (Girebilir misin?)

// Area Rotalarý (Admin paneli vb. için)
app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

// Varsayýlan Rota
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();