using BudgetManager.Models.Expense;
using BudgetManager.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetManagerAPI.Controllers
{
    [Authorize]
    [Route("api/expense")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet("expenses")]
        public async Task<IActionResult> GetExpenses()
        {
            var userId = int.Parse(User.Identity!.Name!);
            var expenses = await _expenseService.GetUserExpenses(userId);

            return Ok(expenses);
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] Expense expense)
        {
            expense.UserId = int.Parse(User.Identity!.Name!);
            await _expenseService.SaveExpense(expense);

            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _expenseService.DeleteExpense(id);

            return Ok();
        }
    }
}
