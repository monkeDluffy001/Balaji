using Balaji.Common.Helpers;
using Balaji.Common.Models;
using Balaji.Core.Service;

namespace Balaji.Api.ApiService
{
    public class UserApiService : IUserApiService
    {
        private readonly ILogger<UserApiService> logger;
        private readonly IUserService userService;

        public UserApiService(ILogger<UserApiService> _logger, IUserService _userService)
        {
            logger = _logger;
            userService = _userService;
        }

        public async Task<ApiResponse> SearchUserAsync(Session session, SearchRequest request)
        {
            logger.LogInformation($"UserApiService.SearchUserAsync at {DateTime.Now}");

            ApiResponse response = new ApiResponse();
            try
            {
                List<dynamic> erroList = Validations.ValidateSearchRequest(request);

                if (erroList.Count > 0)
                {
                    response.ErrorCount = erroList.Count;
                    response.ErrorList = erroList;

                    return response;
                }

                List<dynamic> userList = await userService.SearchUserAsync(session, request);

                if (userList != null)
                {
                    response.Data = userList;
                    response.DataCount = userList.Count;
                }
            }
            catch (Exception ex)
            {
                logger.LogError($"Error: {ex.Message} at {DateTime.Now}");
                response.ErrorList = new List<dynamic>()
                {
                   new ErrorModel(ex)
                };
                response.ErrorCount = response.ErrorList.Count();
            };

            return response;
        }

    }
}
