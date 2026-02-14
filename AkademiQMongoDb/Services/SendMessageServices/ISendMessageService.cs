using AkademiQMongoDb.DTOs.SendMessageDtos;

namespace AkademiQMongoDb.Services.SendMessageServices
{
    public interface ISendMessageService
    {
        Task<List<ResultSendBoxDto>> GetAllAsync();
        Task<ResultSendBoxDto> GetByIdAsync(string id);
        Task CreateAsync(CreateSendMessageDto sendMessageDto);
        Task DeleteAsync(string id);
    }
}
