using AkademiQMongoDb.Services.SendMessageServices;
using Microsoft.AspNetCore.Mvc;

namespace AkademiQMongoDb.ViewComponents.AdminLayoutComponents
{
    // Artık IAdminService'e ihtiyacımız kalmadı, veritabanına gitmeyeceğiz!
    public class _AdminLayoutNavbarViewComponent : ViewComponent
    {
        private readonly ISendMessageService _sendMessageService;

        public _AdminLayoutNavbarViewComponent(ISendMessageService sendMessageService)
        {
            _sendMessageService = sendMessageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // 1. İSİM BULMA İŞLEMİ (Veritabanı yerine Cookie/Claim'den okuyoruz)
            var claimsPrincipal = HttpContext.User;

            if (claimsPrincipal.Identity != null && claimsPrincipal.Identity.IsAuthenticated)
            {
                // LoginController'da oluşturduğun "fullName" claim'ini yakalıyoruz
                var fullNameClaim = claimsPrincipal.FindFirst("fullName")?.Value;

                // Eğer Claim boş değilse onu yaz, boşsa Kullanıcı Adını yaz
                ViewBag.fullName = !string.IsNullOrWhiteSpace(fullNameClaim)
                    ? fullNameClaim
                    : claimsPrincipal.Identity.Name;
            }
            else
            {
                ViewBag.fullName = "Misafir Yönetici";
            }

            // 2. OKUNMAMIŞ MESAJ SAYISI (Bu kısım aynen kalıyor)
            var messages = await _sendMessageService.GetAllAsync();
            var unreadCount = messages.Count(x => !x.IsRead);
            ViewBag.UnreadMessageCount = unreadCount;

            return View();
        }
    }
}