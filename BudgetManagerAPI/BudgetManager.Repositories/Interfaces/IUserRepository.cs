using BudgetManager.Database.Entities;

namespace BudgetManager.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> Get(int id);
        Task<User?> Get(string email);
        Task SaveUser(User user);
    }
}
