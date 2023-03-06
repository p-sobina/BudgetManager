using BudgetManager.Models.Users;

namespace BudgetManager.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserInformations> Authenticate(UserCredentials credentials);
        Task SaveUser(User user);
        Task ChangePassword(int userId, string newPassword);
    }
}
