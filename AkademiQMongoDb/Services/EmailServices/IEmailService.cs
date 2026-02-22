namespace AkademiQMongoDb.Services.EmailServices
{
    public interface IEmailService
    {
        Task SendDiscountEmailToSubscribersAsync(List<string> emails);
    }
}
