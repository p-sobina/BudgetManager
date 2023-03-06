using BudgetManager.Database;
using BudgetManager.Database.Entities;
using BudgetManager.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly BudgetManagerDbContext _context;

        public ExpenseRepository(BudgetManagerDbContext context)
        {
            _context = context;
        }

        public Task<List<Expense>> GetUserExpenses(int userId)
        {
            return _context.Expenses.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task SaveExpense(Expense expense)
        {
            if (expense.Id == 0)
            {
                _context.Expenses.Add(expense);
            }
            else
            {
                var expenseToUpdate = await _context.Expenses.SingleOrDefaultAsync(x => x.Id == expense.Id);

                if (expenseToUpdate != null)
                {
                    _context.Entry(expenseToUpdate).CurrentValues.SetValues(expense);
                }
            }

            await _context.SaveChangesAsync();
        }
        public async Task DeleteExpense(int expenseId)
        {
            var expenseToRemove = await _context.Expenses.SingleOrDefaultAsync(x => x.Id == expenseId);

            if (expenseToRemove != null)
            {
                _context.Expenses.Remove(expenseToRemove);
            }

            await _context.SaveChangesAsync();
        }
    }
}
