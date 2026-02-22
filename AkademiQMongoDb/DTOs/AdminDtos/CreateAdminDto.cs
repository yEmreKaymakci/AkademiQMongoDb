namespace AkademiQMongoDb.DTOs.AdminDtos
{
    public class CreateAdminDto
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool IsVerified { get; set; }
    }
}
