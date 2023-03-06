using System.ComponentModel.DataAnnotations.Schema;

namespace BudgetManager.Database.Entities
{
    public class ExpenseCategory : Entity
    {
        public string Name { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
