using AkademiQMongoDb.DTOs.SubscriberDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AkademiQMongoDb.Services.SubscriberServices
{
    public class SubscriberService : ISubscriberService
    {
        private readonly IMongoCollection<Subscriber> _subscriberCollection;

        public SubscriberService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _subscriberCollection = database.GetCollection<Subscriber>(databaseSettings.SubscriberCollectionName);

        }

        public async Task CreateAsync(CreateSubscriberDto subscriberDto)
        {
            var subscriber = subscriberDto.Adapt<Subscriber>();
            await _subscriberCollection.InsertOneAsync(subscriber);
        }

        public async Task DeleteAsync(string id)
        {
            await _subscriberCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultSubscriberDto>> GetAllAsync()
        {
            var subscriber = await _subscriberCollection.AsQueryable().ToListAsync();
            return subscriber.Adapt<List<ResultSubscriberDto>>();
        }

        public async Task<ResultSubscriberDto> GetByIdAsync(string id)
        {
            var subscriber = await _subscriberCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return subscriber.Adapt<ResultSubscriberDto>();
        }
    }
}
