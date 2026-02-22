using AkademiQMongoDb.DTOs.AdminDtos;

namespace AkademiQMongoDb.Services.AdminServices
{
    public interface IAdminService
    {
        Task<List<ResultAdminDto>> GetAllAsync();
        Task RegisterAdminAsync(RegisterAdminDto registerAdminDto);
        Task CreateAdminAsync(CreateAdminDto createAdminDto);
        Task UpdateAsync(UpdateAdminDto admintDto);
        Task<bool> LoginAdminAsync(LoginAdminDto loginAdminDto);
        Task<ResultAdminDto> GetAdminByUserNameAsync(string userName);
        Task DeleteAsync(string id);
    }
}
