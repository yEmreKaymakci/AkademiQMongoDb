using AkademiQMongoDb.DTOs.SendMessageDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.SendMessageServices
{
    public class SendMessageService : ISendMessageService
    {
        private readonly IMongoCollection<SendMessage> _sendMessageCollection;

        public SendMessageService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _sendMessageCollection = database.GetCollection<SendMessage>(databaseSettings.SendMessageCollectionName);
        }

        public async Task CreateAsync(CreateSendMessageDto createSendMessageDto)
        {
            var message = createSendMessageDto.Adapt<SendMessage>();
            await _sendMessageCollection.InsertOneAsync(message);
        }

        public async Task DeleteAsync(string id)
        {
            // DÜZELTME: id doğrudan verilemez, lambda ifadesiyle filtre yazılmalıdır.
            await _sendMessageCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultSendBoxDto>> GetAllAsync()
        {
            // DÜZELTME: AsQueryable() hatasından kaçınmak için Find(x => true) kullandık.
            var message = await _sendMessageCollection.Find(x => true).ToListAsync();
            return message.Adapt<List<ResultSendBoxDto>>();
        }

        public async Task<ResultSendBoxDto> GetByIdAsync(string id)
        {
            var message = await _sendMessageCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return message.Adapt<ResultSendBoxDto>();
        }

        public async Task UpdateAsync(UpdateSendMessageDto sendMessageDto)
        {
            var message = sendMessageDto.Adapt<SendMessage>();
            await _sendMessageCollection.FindOneAndReplaceAsync(x => x.Id == message.Id, message);
        }
    }
}