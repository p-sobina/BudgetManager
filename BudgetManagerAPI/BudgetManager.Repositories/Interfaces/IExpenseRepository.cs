using BudgetManager.Database.Entities;

namespace BudgetManager.Repositories.Interfaces
{
    public interface IExpenseRepository
    {
        Task<List<Expense>> GetUserExpenses(int userId);
        Task SaveExpense(Expense expense);
        Task DeleteExpense(int expenseId);
    }
}
