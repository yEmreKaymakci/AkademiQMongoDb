using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.ContactDtos
{
    public class UpdateContactDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Tam adres boş bırakılamaz.")]
        [MaxLength(80, ErrorMessage = "Tam adres 80 karakteri geçemez.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz.")]
        [MaxLength(15, ErrorMessage = "Telefon numarası 15 karakteri geçemez.")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Mail adresi boş bırakılamaz.")]
        [MaxLength(255, ErrorMessage = "Mail adresi 255 karakteri geçemez.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Harita linki boş bırakılamaz.")]
        public string MapUrl { get; set; }
    }
}
