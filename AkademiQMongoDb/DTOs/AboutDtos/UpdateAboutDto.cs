using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.AboutDtos
{
    public class UpdateAboutDto
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Başlangıç yılı boş bırakılamaz.")]
        [Range(1800, 2100, ErrorMessage = "Lütfen başlangıç yılı için geçerli bir yıl giriniz.")]
        public int StartYear { get; set; }

        [Required(ErrorMessage = "Resim linki boş bırakılamaz.")]
        public string ImageUrl { get; set; }

        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        [MaxLength(80, ErrorMessage = "Başlık 80 karakteri geçemez.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [MaxLength(250, ErrorMessage = "Açıklama 250 karakteri geçemez.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Telefon numarası boş bırakılamaz.")]
        public string Number { get; set; }
    }
}
