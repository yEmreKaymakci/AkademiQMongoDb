

using AkademiQMongoDb.DTOs.SubscriberDtos;

namespace AkademiQMongoDb.Services.SubscriberServices
{
    public interface ISubscriberService
    {
        Task<List<ResultSubscriberDto>> GetAllAsync();
        Task<ResultSubscriberDto> GetByIdAsync(string id);
        Task CreateAsync(CreateSubscriberDto subscriberDto);
        Task DeleteAsync(string id);
    }
}
