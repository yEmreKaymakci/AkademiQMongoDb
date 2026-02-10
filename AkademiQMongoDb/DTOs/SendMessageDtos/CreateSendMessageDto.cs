using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.SendMessageDtos
{
    public class CreateSendMessageDto
    {
        [Required(ErrorMessage ="Tam isim alanı boş bırakılamaz!")]
        [MaxLength(50, ErrorMessage ="Tam isim uzunluğu 50 karakteri geçemez")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Mail adresi boş bırakılamaz.")]
        [MaxLength(255, ErrorMessage = "Mail adresi 255 karakteri geçemez.")]
        public string Email { get; set; }

        [MaxLength(15, ErrorMessage = "Telefon numarası 15 karakteri geçemez.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Mesaj kısmı boş bırakılamaz.")]
        [MaxLength(500, ErrorMessage = "Mesaj uzunluğu 500 karakteri geçemez.")]
        public string Content { get; set; }
    }
}
