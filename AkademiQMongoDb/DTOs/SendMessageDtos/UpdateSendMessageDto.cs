namespace AkademiQMongoDb.DTOs.SendMessageDtos
{
    public class UpdateSendMessageDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Content { get; set; }
        public bool IsRead { get; set; }
    }
}
