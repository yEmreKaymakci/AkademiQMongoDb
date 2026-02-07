using AkademiQMongoDb.DTOs.ChefDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AkademiQMongoDb.Services.ChefServices
{
    public class ChefService : IChefService
    {
        private readonly IMongoCollection<Chef> _chefCollection;

        public ChefService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _chefCollection = database.GetCollection<Chef>(databaseSettings.ChefCollectionName);

        }

        public async Task CreateAsync(CreateChefDto chefDto)
        {
            var chef = chefDto.Adapt<Chef>();
            await _chefCollection.InsertOneAsync(chef);
        }

        public async Task DeleteAsync(string id)
        {
            await _chefCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultChefDto>> GetAllAsync()
        {
            var chef = await _chefCollection.AsQueryable().ToListAsync();
            return chef.Adapt<List<ResultChefDto>>();
        }

        public async Task<UpdateChefDto> GetByIdAsync(string id)
        {
            var chef = await _chefCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return chef.Adapt<UpdateChefDto>();
        }

        public async Task UpdateAsync(UpdateChefDto chefDto)
        {
            var chef = chefDto.Adapt<Chef>();
            await _chefCollection.FindOneAndReplaceAsync(x => x.Id == chef.Id, chef);
        }
    }
}
