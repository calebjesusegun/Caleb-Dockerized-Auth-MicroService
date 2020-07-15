using System.ComponentModel.DataAnnotations;

namespace Auth.API.Models
{
   public class RegisterModel
   {
      [Required]
      [Display(Name = "User Name")]
      public string UserName { get; set; }

      [Required]
      [Display(Name = "Email")]
      public string Email { get; set; }

      [Required]
      public string Password { get; set; }

      [Required]
      [Display(Name = "Confirm Password")]
      [Compare("Password")]
      public string ConfirmPassword { get; set; }
   }
}