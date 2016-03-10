using System.ComponentModel.DataAnnotations;

namespace Evacuation.Web.Models
{
    public class UserModel
    {
        public int UserID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password doesn't match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        public bool IsDeleted { get; set; }
    }
}