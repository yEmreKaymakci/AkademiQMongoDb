using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.BannerDtos
{
    public class CreateBannerDto
    {
        [Required(ErrorMessage = "Başlık boş bırakılamaz.")]
        [MaxLength(35, ErrorMessage = "Başlık 35 karakteri geçemez.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        [MaxLength(250, ErrorMessage = "Açıklama 250 karakteri geçemez.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Resim linki boş bırakılamaz.")]
        public string ImageUrl { get; set; }
    }
}
