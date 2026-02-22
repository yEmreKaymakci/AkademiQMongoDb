using AkademiQMongoDb.DTOs.BookingDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace AkademiQMongoDb.Services.BookingServices
{
    public class BookingService : IBookingService
    {
        private readonly IMongoCollection<Booking> _bookingCollection;

        public BookingService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _bookingCollection = database.GetCollection<Booking>(databaseSettings.BookingCollectionName);
        }
        public async Task CreateAsync(CreateBookingDto bookingDto)
        {
            var booking = bookingDto.Adapt<Booking>();
            await _bookingCollection.InsertOneAsync(booking);
        }

        public async Task DeleteAsync(string id)
        {
            await _bookingCollection.DeleteOneAsync(booking => booking.Id == id);
        }

        public async Task<List<ResultBookingDto>> GetAllAsync()
        {
            var bookings = await _bookingCollection.Find(x => true).ToListAsync();

            return bookings.Adapt<List<ResultBookingDto>>();
        }

        public async Task<UpdateBookingDto> GetByIdAsync(string id)
        {
            var booking = await _bookingCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

            return booking.Adapt<UpdateBookingDto>();
        }

        public async Task UpdateAsync(UpdateBookingDto bookingDto)
        {
            var booking = bookingDto.Adapt<Booking>();

            await _bookingCollection.FindOneAndReplaceAsync(x => x.Id == booking.Id, booking);
        }
    }
}
