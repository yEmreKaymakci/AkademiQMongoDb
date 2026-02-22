using AkademiQMongoDb.Entities.Common;

namespace AkademiQMongoDb.Entities
{
    public class Booking : BaseEntity   
    {
        public string Phone { get; set; }
        public string PersonCount { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
    }
}
