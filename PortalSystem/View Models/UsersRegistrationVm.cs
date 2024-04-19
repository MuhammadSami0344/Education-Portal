using System.ComponentModel.DataAnnotations;

namespace PortalSystem.View_Models
{
    public class UsersRegistrationVm
    {
        public int Id { get; set; }
        [Required (ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string? RepeatPassword { get; set; }
        public bool IsDelete { get; set; }
    }

    public class LoginUserVm
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? EmailAddress { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string UserRole { get; set; }
    }
}
