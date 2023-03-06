using AutoMapper;
using BudgetManager.Models.ExpenseCategories;
using BudgetManager.Repositories.Interfaces;
using BudgetManager.Services.Interfaces;

namespace BudgetManager.Services
{
    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IMapper _mapper;
        private readonly IExpenseCategoryRepository _expenseCategoryRepository;

        public ExpenseCategoryService(IMapper mapper, IExpenseCategoryRepository expenseCategoryRepository)
        {
            _mapper = mapper;
            _expenseCategoryRepository = expenseCategoryRepository;
        }

        public async Task<List<ExpenseCategory>> GetUserExpenseCategories(int userId)
        {
            var categories = await _expenseCategoryRepository.GetUserExpenseCategories(userId);

            return _mapper.Map<List<ExpenseCategory>>(categories);
        }

        public async Task SaveExpenseCategory(ExpenseCategory expenseCategory)
        {
            var entityToSave = _mapper.Map<Database.Entities.ExpenseCategory>(expenseCategory);
            
            await _expenseCategoryRepository.SaveExpenseCategory(entityToSave);
        }

        public async Task DeleteExpenseCategory(int categoryId)
        {
            await _expenseCategoryRepository.DeleteExpenseCategory(categoryId);
        }
    }
}
