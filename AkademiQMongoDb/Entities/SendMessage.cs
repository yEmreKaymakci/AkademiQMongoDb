using AkademiQMongoDb.Entities.Common;

namespace AkademiQMongoDb.Entities
{
    public class SendMessage : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; } = false;
    }
}
