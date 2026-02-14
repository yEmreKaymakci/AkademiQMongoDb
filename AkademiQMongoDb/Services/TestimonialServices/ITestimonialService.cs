using AkademiQMongoDb.DTOs.TestimonialDtos;

namespace AkademiQMongoDb.Services.TestimonialServices
{
    public interface ITestimonialService
    {
        Task<List<ResultTestimonialDto>> GetAllAsync();
        Task<UpdateTestimonialDto> GetByIdAsync(string id);
        Task CreateAsync(CreateTestimonialDto testimonialDto);
        Task UpdateAsync(UpdateTestimonialDto testimonialDto);
        Task DeleteAsync(string id);
    }
}
