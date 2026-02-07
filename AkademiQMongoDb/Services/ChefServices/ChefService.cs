using AkademiQMongoDb.DTOs.ChefDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using MongoDB.Driver;

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

        public Task CreateAsync(CreateChefDto chefDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ResultChefDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UpdateChefDto> GetByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(UpdateChefDto chefDto)
        {
            throw new NotImplementedException();
        }
    }
}
