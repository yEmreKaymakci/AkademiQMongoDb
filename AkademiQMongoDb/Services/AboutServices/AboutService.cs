using AkademiQMongoDb.DTOs.AboutDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AkademiQMongoDb.Services.AboutServices
{
    public class AboutService : IAboutService
    {
        private readonly IMongoCollection<About> _aboutCollection;

        public AboutService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _aboutCollection = database.GetCollection<About>(databaseSettings.AboutCollectionName);
        }

       public async Task CreateAsync(CreateAboutDto aboutDto)
        {
            var about = aboutDto.Adapt<About>();
            await _aboutCollection.InsertOneAsync(about);
        }

        public async Task DeleteAsync(string id)
        {
            await _aboutCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultAboutDto>> GetAllAsync()
        {
            var about = await _aboutCollection.AsQueryable().ToListAsync();
            return about.Adapt<List<ResultAboutDto>>();
        }

        public async Task<UpdateAboutDto> GetByIdAsync(string id)
        {
            var about = await _aboutCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return about.Adapt<UpdateAboutDto>();
        }

        public async Task UpdateAsync(UpdateAboutDto aboutDto)
        {
            var about = aboutDto.Adapt<About>();
            await _aboutCollection.FindOneAndReplaceAsync(x => x.Id == about.Id, about);
        }
    }
}
