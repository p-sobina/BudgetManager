﻿namespace BudgetManager.Models.Expense
{
    public class Expense
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
        public DateTime ExpenseDate { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
