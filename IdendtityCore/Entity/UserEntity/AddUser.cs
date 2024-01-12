using System.ComponentModel.DataAnnotations;

namespace IdendtityCore.Entity.UserEntity
{
    public class AddUser
    {

        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        
        public string DealerId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        // You can include additional properties relevant to user registration, such as FirstName, LastName, etc.
    }
}
