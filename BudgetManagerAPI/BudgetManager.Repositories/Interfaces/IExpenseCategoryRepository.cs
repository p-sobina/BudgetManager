using BudgetManager.Database.Entities;

namespace BudgetManager.Repositories.Interfaces
{
    public interface IExpenseCategoryRepository
    {
        Task<List<ExpenseCategory>> GetUserExpenseCategories(int userId);
        Task SaveExpenseCategory(ExpenseCategory expenseCategory);
        Task DeleteExpenseCategory(int categoryId);
    }
}
