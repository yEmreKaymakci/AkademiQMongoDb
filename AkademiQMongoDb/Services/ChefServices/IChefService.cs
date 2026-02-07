using AkademiQMongoDb.DTOs.ChefDtos;

namespace AkademiQMongoDb.Services.ChefServices
{
    public interface IChefService
    {
        Task<List<ResultChefDto>> GetAllAsync();
        Task<UpdateChefDto> GetByIdAsync(string id);
        Task CreateAsync(CreateChefDto chefDto);
        Task UpdateAsync(UpdateChefDto chefDto);
        Task DeleteAsync(string id);
    }
}
