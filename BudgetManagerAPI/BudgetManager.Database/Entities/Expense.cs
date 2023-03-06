using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetManager.Database.Entities
{
    public class Expense : Entity
    {
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime ExpenseDate { get; set; }
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public virtual ExpenseCategory Category { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
