using BudgetManager.Database;
using BudgetManager.Database.Entities;
using BudgetManager.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Repositories
{
    public class ExpenseCategoryRepository : IExpenseCategoryRepository
    {
        private readonly BudgetManagerDbContext _context;

        public ExpenseCategoryRepository(BudgetManagerDbContext context)
        {
            _context = context;
        }

        public Task<List<ExpenseCategory>> GetUserExpenseCategories(int userId)
        {
            return _context.ExpenseCategories.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task SaveExpenseCategory(ExpenseCategory expenseCategory)
        {
            if (expenseCategory.Id == 0)
            {
                _context.ExpenseCategories.Add(expenseCategory);
            }
            else
            {
                var categoryToUpdate = await _context.ExpenseCategories.SingleOrDefaultAsync(x => x.Id == expenseCategory.Id);

                if (categoryToUpdate != null)
                {
                    _context.Entry(categoryToUpdate).CurrentValues.SetValues(expenseCategory);
                }
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteExpenseCategory(int categoryId)
        {
            var categoryToDelete = await _context.ExpenseCategories.SingleOrDefaultAsync(x => x.Id == categoryId);

            if (categoryToDelete != null)
            {
                _context.ExpenseCategories.Remove(categoryToDelete);
            }

            await _context.SaveChangesAsync();
        }
    }
}
