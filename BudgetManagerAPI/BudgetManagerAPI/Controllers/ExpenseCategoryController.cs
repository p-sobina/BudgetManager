using BudgetManager.Models.ExpenseCategories;
using BudgetManager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManagerAPI.Controllers
{
    [Authorize]
    [Route("api/expensecategory")]
    [ApiController]
    public class ExpenseCategoryController : ControllerBase
    {
        private readonly IExpenseCategoryService _expenseCategoryService;

        public ExpenseCategoryController(IExpenseCategoryService expenseCategoryService)
        {
            _expenseCategoryService = expenseCategoryService;
        }

        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var userId = int.Parse(User.Identity!.Name!);
            var categories = await _expenseCategoryService.GetUserExpenseCategories(userId);

            return Ok(categories);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] ExpenseCategory category)
        {
            category.UserId = int.Parse(User.Identity!.Name!);
            await _expenseCategoryService.SaveExpenseCategory(category);

            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _expenseCategoryService.DeleteExpenseCategory(id);
            return Ok();
        }
    }
}
