using System.ComponentModel.DataAnnotations;

namespace IdendtityCore.Entity.UserEntity
{
    public class ChangePasswordDto
    {

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        //public string UserName { get; set; }
        public AppUser AppUser { get; set; }
    }
}

