using AkademiQMongoDb.DTOs.TestimonialDtos;
using AkademiQMongoDb.Entities;
using AkademiQMongoDb.Settings;
using Mapster;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AkademiQMongoDb.Services.TestimonialServices
{
    public class TestimonialService : ITestimonialService
    {
        private readonly IMongoCollection<Testimonial> _testimonialCollection;

        public TestimonialService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _testimonialCollection = database.GetCollection<Testimonial>(databaseSettings.TestimonialCollectionName);

        }

        public async Task CreateAsync(CreateTestimonialDto testimonialDto)
        {
            var testimonial = testimonialDto.Adapt<Testimonial>();
            await _testimonialCollection.InsertOneAsync(testimonial);
        }

        public async Task DeleteAsync(string id)
        {
            await _testimonialCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<List<ResultTestimonialDto>> GetAllAsync()
        {
            var testimonial = await _testimonialCollection.AsQueryable().ToListAsync();
            return testimonial.Adapt<List<ResultTestimonialDto>>();
        }

        public async Task<UpdateTestimonialDto> GetByIdAsync(string id)
        {
            var testimonial = await _testimonialCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
            return testimonial.Adapt<UpdateTestimonialDto>();
        }

        public async Task UpdateAsync(UpdateTestimonialDto testimonialDto)
        {
            var testimonial = testimonialDto.Adapt<Testimonial>();
            await _testimonialCollection.FindOneAndReplaceAsync(x => x.Id == testimonial.Id, testimonial);
        }
    }
}
