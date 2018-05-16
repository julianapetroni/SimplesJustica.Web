using System.ComponentModel.DataAnnotations;

namespace SimplesJustica.Identity.Models
{
    public class RegisterExternalBindingModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}