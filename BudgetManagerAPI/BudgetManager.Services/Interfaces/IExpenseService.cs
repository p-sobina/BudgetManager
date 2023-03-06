using BudgetManager.Models.Expense;

namespace BudgetManager.Services.Interfaces
{
    public interface IExpenseService
    {
        Task<List<Expense>> GetUserExpenses(int userId);
        Task SaveExpense(Expense expense);
        Task DeleteExpense(int expenseId);
    }
}
