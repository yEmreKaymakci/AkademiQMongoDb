using AkademiQMongoDb.DTOs.BookingDtos;

namespace AkademiQMongoDb.Services.BookingServices
{
    public interface IBookingService
    {
        Task<List<ResultBookingDto>> GetAllAsync();
        Task<UpdateBookingDto> GetByIdAsync(string id);
        Task CreateAsync(CreateBookingDto bookingDto);
        Task UpdateAsync(UpdateBookingDto bookingDto);
        Task DeleteAsync(string id);
    }
}
