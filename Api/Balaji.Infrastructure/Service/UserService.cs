using Balaji.ApiModels;
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
        public UserService(ILogger<UserService> _logger) {
            logger = _logger;
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
    }
}
