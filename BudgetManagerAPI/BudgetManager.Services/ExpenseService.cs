using AutoMapper;
using BudgetManager.Models.Expense;
using BudgetManager.Repositories.Interfaces;
using BudgetManager.Services.Interfaces;

namespace BudgetManager.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IMapper mapper, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;
        }

        public async Task<List<Expense>> GetUserExpenses(int userId)
        {
            var expenses = await _expenseRepository.GetUserExpenses(userId);

            return _mapper.Map<List<Expense>>(expenses);
        }

        public async Task SaveExpense(Expense expense)
        {
            var entityToSave = _mapper.Map<Database.Entities.Expense>(expense);

            await _expenseRepository.SaveExpense(entityToSave);
        }

        public async Task DeleteExpense(int expenseId)
        {
            await _expenseRepository.DeleteExpense(expenseId);
        }
    }
}
