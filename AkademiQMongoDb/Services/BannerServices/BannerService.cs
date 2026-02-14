using AkademiQMongoDb.DTOs.BannerDtos;
using AkademiQMongoDb.DTOs.ChefDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AkademiQMongoDb.Services.BannerServices
{
    public class BannerService : IBannerService
    {
        private readonly IMongoCollection<Banner> _bannerCollection;

        public BannerService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _bannerCollection = database.GetCollection<Banner>(databaseSettings.BannerCollectionName);

        }

        public async Task CreateAsync(CreateBannerDto bannerDto)
        {
            var banner = bannerDto.Adapt<Banner>();
            await _bannerCollection.InsertOneAsync(banner);
        }

        public async Task DeleteAsync(string id)
        {
            await _bannerCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultBannerDto>> GetAllAsync()
        {
            var banner = await _bannerCollection.AsQueryable().ToListAsync();
            return banner.Adapt<List<ResultBannerDto>>();
        }

        public async Task<UpdateBannerDto> GetByIdAsync(string id)
        {
            var banner = await _bannerCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return banner.Adapt<UpdateBannerDto>();
        }

        public async Task UpdateAsync(UpdateBannerDto bannerDto)
        {
            var banner = bannerDto.Adapt<Banner>();
            await _bannerCollection.FindOneAndReplaceAsync(x => x.Id == banner.Id, banner);
        }
    }
}
