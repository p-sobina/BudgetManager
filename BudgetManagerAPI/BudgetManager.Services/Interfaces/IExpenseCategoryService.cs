using BudgetManager.Models.ExpenseCategories;

namespace BudgetManager.Services.Interfaces
{
    public interface IExpenseCategoryService
    {
        Task<List<ExpenseCategory>> GetUserExpenseCategories(int userId);
        Task SaveExpenseCategory(ExpenseCategory expenseCategory);
        Task DeleteExpenseCategory(int categoryId);
    }
}
