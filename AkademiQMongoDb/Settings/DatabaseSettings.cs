namespace AkademiQMongoDb.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ProductCollectionName { get; set; }
        public string ChefCollectionName { get; set; }
        public string AboutCollectionName { get; set; }
        public string BannerCollectionName { get; set; }
        public string ContactCollectionName { get; set; }
        public string SendMessageCollectionName { get; set; }
        public string SubscriberCollectionName { get; set; }
        public string TestimonialCollectionName { get; set; }
    }
}
