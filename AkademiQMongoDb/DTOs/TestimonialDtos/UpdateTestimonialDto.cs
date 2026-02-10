using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.TestimonialDtos
{
    public class UpdateTestimonialDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Resim linki boş bırakılamaz.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "İsim alanı boş bırakılamaz.")]
        [MaxLength(50, ErrorMessage = "İsim uzunluğu 50 karakteri geçemez.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Yorum başlığı boş bırakılamaz.")]
        [MaxLength(40, ErrorMessage = "Yorum başlığı uzunluğu 40 karakteri geçemez.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mesaj boş bırakılamaz.")]
        [MaxLength(250, ErrorMessage = "Mesaj 250 uzunluğu karakteri geçemez.")]
        public string Comment { get; set; }

        [Required(ErrorMessage = "Puan alanı boş bırakılamaz.")]
        [Range(1, 5, ErrorMessage = "Puan değeri 1 ile 5 arasında olmalıdır.")]
        public int Rate { get; set; }
    }
}
