using Balaji.ApiModels;
using Balaji.Common.Models;
using Balaji.Core.Repository;
using Balaji.Core.Service;
using Balaji.Domain;
using Microsoft.Extensions.Logging;

namespace Balaji.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> logger;
        private readonly IUserRepository userRepository;
        public UserService(ILogger<UserService> _logger, IUserRepository _userRepository)
        {
            logger = _logger;
            userRepository = _userRepository;

        }
        public async Task<dynamic> GetUserAsync(UserApiModel model)
        {
            try
            {
                logger.LogInformation($"UserService.GetUserAsync at {DateTime.Now}");

                return new
                {
                    IsSuccess = true
                };
            }
            catch (Exception ex)
            {
                logger.LogError($"Error: {ex.Message}");
                throw;
            }

        }

        public async Task<dynamic> AddUserAsync(PublicSession session, UserApiModel user)
        {
            try
            {
                logger.LogInformation($"UserService.AddUserAsync at {DateTime.Now}");

                var result = await userRepository.InsertUserAsync(session, user);

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error: {ex.Message} at {DateTime.Now}");
                throw;
            }
        }

        public async Task<List<User>> GetUserDetailsAsync(PublicSession session, UserApiModel model)
        {
            try
            {
                logger.LogInformation($"UserService.GetUserDetailsAsync at {DateTime.Now}");
                List<User> result = await userRepository.LoginUserInfo(session, model);

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error: {ex.Message} at {DateTime.Now}");
                throw;
            }
        }
    }
}
