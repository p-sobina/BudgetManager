using AutoMapper;
using BudgetManager.Enum;
using BudgetManager.Exceptions;
using BudgetManager.Helpers;
using BudgetManager.Models.Users;
using BudgetManager.Repositories.Interfaces;
using BudgetManager.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;

namespace BudgetManager.Services
{
    public class UserService : IUserService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IConfiguration configuration, IMapper mapper, IUserRepository userRepository)
        {
            _configuration = configuration;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserInformations> Authenticate(UserCredentials credentials)
        {
            var userToLogIn = await _userRepository.Get(credentials.Email);

            if (userToLogIn == null)
            {
                throw new NotFoundException(credentials.Email);
            }

            if (SecurityHelper.HashPassword(credentials.Password) != userToLogIn.Password)
            {
                throw new AuthenticationFailedException();
            }

            var mappedInfos = _mapper.Map<UserInformations>(userToLogIn);
            mappedInfos.Token = SecurityHelper.GenerateToken(1, userToLogIn.Role, _configuration.GetSection("EncryptingKey").Value!);

            return mappedInfos;
        }

        public async Task SaveUser(User user)
        {
            if (!IsUserValid(user))
            {
                throw new InvalidDataException("Invalid user data");
            }

            var entityToSave = _mapper.Map<BudgetManager.Database.Entities.User>(user);

            await _userRepository.SaveUser(entityToSave);
        }

        public async Task ChangePassword(int userId, string newPassword)
        {
            var updatedUser = await _userRepository.Get(userId);

            if (updatedUser == null)
            {
                throw new NotFoundException(userId);
            }

            if (!IsPasswordValid(newPassword))
            {
                throw new InvalidDataException("Selected password is too short");
            }

            updatedUser.Password = SecurityHelper.HashPassword(newPassword);

            await _userRepository.SaveUser(updatedUser);
        }

        private static bool IsUserValid(User user)
        {
            var context = new ValidationContext(user);
            var isValid = Validator.TryValidateObject(user, context, null);
            var isRoleValid = System.Enum.TryParse<UserRole>(user.Role, true, out var role);

            return isValid && isRoleValid;
        }

        private static bool IsPasswordValid(string password)
        {
            return password.Length > 5;
        }
    }
}