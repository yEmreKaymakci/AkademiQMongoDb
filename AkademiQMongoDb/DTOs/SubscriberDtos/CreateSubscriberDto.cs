using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.SubscriberDtos
{
    public class CreateSubscriberDto
    {
        [Required(ErrorMessage = "E-posta adresi boş bırakılamaz.")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }
    }
}
