using System.ComponentModel.DataAnnotations;

namespace BudgetManager.Models.ExpenseCategories
{
    public class ExpenseCategory
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
