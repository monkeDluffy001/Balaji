using Balaji.ApiModels;
using Balaji.Common.Models;
using Balaji.Core.Repository;
using Balaji.Core.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balaji.Infrastructure.Service
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> logger;
        private readonly IUserRepository userRepository;
        public UserService(ILogger<UserService> _logger, IUserRepository _userRepository) {
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
            catch(Exception ex)
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
            catch(Exception ex)
            {
                logger.LogError($"Error: {ex.Message} at {DateTime.Now}");
                throw;
            }
        }
    }
}
