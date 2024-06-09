using Balaji.ApiModels;
using Balaji.Common.Models;
using Balaji.Core.Repository;
using Balaji.Core.Search;
using Balaji.Core.Service;
using Balaji.Domain;
using Microsoft.Extensions.Logging;

namespace Balaji.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> logger;
        private readonly IUserRepository userRepository;
        private readonly IUserSearch userSearch;

        public UserService(
            ILogger<UserService> _logger,
            IUserRepository _userRepository,
            IUserSearch _userSearch
        )
        {
            logger = _logger;
            userRepository = _userRepository;
            userSearch = _userSearch;
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

        public async Task<List<dynamic>> SearchUserAsync(Session session, SearchRequest request)
        {
            logger.LogInformation($"UserService.SearchUserAsync at {DateTime.Now}");

            try
            {
                // Get sql statement
                string sqlStatement = userSearch.GetSqlStatement(request);
                return new List<dynamic>()
                {
                    sqlStatement
                };
            }
            catch (Exception ex)
            {
                logger.LogError($"Error: {ex.Message} at {DateTime.Now}");
                throw;
            }

        }
    }
}
