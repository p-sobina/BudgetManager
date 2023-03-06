using BudgetManager.Database;
using BudgetManager.Database.Entities;
using BudgetManager.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetManager.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BudgetManagerDbContext _context;

        public UserRepository(BudgetManagerDbContext context)
        {
            _context = context;
        }

        public Task<User?> Get(int id)
        {
            return _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public Task<User?> Get(string email)
        {
            return _context.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task SaveUser(User user)
        {
            if (user.Id == 0)
            {
                _context.Users.Add(user);
            }
            else
            {
                var userToUpdate = await _context.Users.SingleOrDefaultAsync(x => x.Id == user.Id);

                if (userToUpdate != null)
                {
                    _context.Entry(userToUpdate).CurrentValues.SetValues(user);
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}