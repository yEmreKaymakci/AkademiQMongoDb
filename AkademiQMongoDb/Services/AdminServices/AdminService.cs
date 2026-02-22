using AkademiQMongoDb.DTOs.AdminDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly IMongoCollection<Admin> _adminCollection;

        public AdminService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _adminCollection = database.GetCollection<Admin>("Admins");
        }

        // 1. KONTROL: Parametre arayüzle eşleşmesi için CreateAdminDto olarak düzeltildi.
        public async Task CreateAdminAsync(CreateAdminDto createAdminDto)
        {
            var admin = createAdminDto.Adapt<Admin>();

            // SİHİRLİ KOD BURASI: Kullanıcının girdiği "12345" gibi bir şifreyi 
            // "$2a$11$e.f1... " gibi asla çözülemeyecek 60 karakterlik bir hash'e çevirir.
            admin.Password = BCrypt.Net.BCrypt.HashPassword(createAdminDto.Password);

            await _adminCollection.InsertOneAsync(admin);
        }

        // 2. EKSİK EKLENDİ: Tüm adminleri getirme işlemi
        public async Task<List<ResultAdminDto>> GetAllAsync()
        {
            var admins = await _adminCollection.Find(x => true).ToListAsync();
            return admins.Adapt<List<ResultAdminDto>>();
        }

        public async Task<ResultAdminDto> GetAdminByUserNameAsync(string userName)
        {
            var admin = await _adminCollection.Find(x => x.UserName == userName).FirstOrDefaultAsync();
            return admin.Adapt<ResultAdminDto>();
        }

        public async Task<bool> LoginAdminAsync(LoginAdminDto loginAdminDto)
        {
            // 1. Önce veritabanından sadece Kullanıcı Adı ile admini bul
            var admin = await _adminCollection.Find(x => x.UserName == loginAdminDto.UserName && x.IsVerified).FirstOrDefaultAsync();

            // Eğer böyle bir kullanıcı adı yoksa direkt false dön
            if (admin is null)
            {
                return false;
            }

            // 2. DOĞRULAMA: Kullanıcının forma girdiği düz şifre ile, veritabanındaki karmaşık hash'i karşılaştır.
            // Eşleşirse true, eşleşmezse false döner.
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginAdminDto.Password, admin.Password);

            return isPasswordValid;
        }

        // 3. EKSİK EKLENDİ: Güncelleme işlemi
        public async Task UpdateAsync(UpdateAdminDto updateAdminDto)
        {
            var admin = updateAdminDto.Adapt<Admin>();
            // MongoDB'de veriyi güncellerken Id üzerinden eşleştirme (ReplaceOneAsync) yapılır
            await _adminCollection.ReplaceOneAsync(x => x.Id == admin.Id, admin);
        }

        // 4. EKSİK EKLENDİ: Silme işlemi
        public async Task DeleteAsync(string id)
        {
            await _adminCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task RegisterAdminAsync(RegisterAdminDto registerAdminDto)
        {
            var admin = registerAdminDto.Adapt<Admin>();
            await _adminCollection.InsertOneAsync(admin);
        }
    }
}