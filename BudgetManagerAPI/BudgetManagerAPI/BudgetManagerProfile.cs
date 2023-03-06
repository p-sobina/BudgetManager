using AutoMapper;
using BudgetManager.Database.Entities;
using BudgetManager.Helpers;

namespace BudgetManagerAPI
{
    public class BudgetManagerProfile : Profile
    {
        public BudgetManagerProfile()
        {
            CreateMap<User, BudgetManager.Models.Users.UserInformations>()
                .ForMember(x => x.Token, y => y.Ignore());

            CreateMap<User, BudgetManager.Models.Users.User>()
                .ForMember(x => x.Password, y => y.MapFrom(m => string.Empty))
                .ReverseMap()
                .ForMember(x => x.Password, y => y.MapFrom(m => SecurityHelper.HashPassword(m.Password)));

            CreateMap<ExpenseCategory, BudgetManager.Models.ExpenseCategories.ExpenseCategory>()
                .ReverseMap();

            CreateMap<Expense, BudgetManager.Models.Expense.Expense>()
                .ReverseMap();
        }
    }
}
