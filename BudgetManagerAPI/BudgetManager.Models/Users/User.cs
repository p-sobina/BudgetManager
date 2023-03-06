using System.ComponentModel.DataAnnotations;

namespace BudgetManager.Models.Users
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
