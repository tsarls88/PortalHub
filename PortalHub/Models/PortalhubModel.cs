using System.ComponentModel.DataAnnotations;

namespace PortalHub.Models
{
    public class PortalhubModel
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "App Name is Required ")]
        [Display(Name = "Application Name")]
        public string? AppName { get; set; }


        [Display(Name = "Description")]
        public string? Description { get; set; }


        [Required(ErrorMessage = "URL is required")]
        [Url(ErrorMessage = "Please enter a valid URL")]
        public string? AppUrl { get; set; }

        [Display(Name = "Icon Class")]
        public string? IconClass { get; set; }

        public int? DisplayOrder { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime? CreatedDate { get; set; }
    }
}
