using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.BookingDtos
{
    public class CreateBookingDto
    {
        [Required(ErrorMessage = "Telefon numarası bölümü boş bırakılamaz.")]
        [MaxLength(15, ErrorMessage = "Telefon numarası 15 karakteri geçemez.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Kişi sayısı bölümü boş bırakılamaz.")]
        public string PersonCount { get; set; }

        [Required(ErrorMessage = "Tarih bölümü boş bırakılamaz.")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Saat bölümü boş bırakılamaz.")]
        public string Time { get; set; }
    }
}
