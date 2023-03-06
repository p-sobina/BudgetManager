using System.ComponentModel.DataAnnotations;

namespace BudgetManager.Database.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
