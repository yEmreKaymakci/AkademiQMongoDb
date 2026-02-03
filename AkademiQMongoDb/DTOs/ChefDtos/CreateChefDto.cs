using System.ComponentModel.DataAnnotations;

namespace AkademiQMongoDb.DTOs.ChefDtos
{
    public class CreateChefDto
    {
        [Required(ErrorMessage = "Şef adı boş bırakılamaz.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Şef ünvanı boş bırakılamaz.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Görsel Url boş bırakılamaz.")]
        public string ImageUrl { get; set; }

        public string SocialMedia1 { get; set; }
        public string SocialMedia2 { get; set; }
        public string SocialMedia3 { get; set; }
    }
}
