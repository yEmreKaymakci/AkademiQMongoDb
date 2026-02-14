using AkademiQMongoDb.DTOs.BannerDtos;

namespace AkademiQMongoDb.Services.BannerServices
{
    public interface IBannerService
    {
        Task<List<ResultBannerDto>> GetAllAsync();
        Task<UpdateBannerDto> GetByIdAsync(string id);
        Task CreateAsync(CreateBannerDto bannerDto);
        Task UpdateAsync(UpdateBannerDto bannerDto);
        Task DeleteAsync(string id);
    }
}
