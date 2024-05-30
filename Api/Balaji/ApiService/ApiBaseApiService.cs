using Balaji.ApiModels;
using Balaji.Common.Models;
using Balaji.Core.Service;

namespace Balaji.Api.ApiService
{
    public class ApiBaseApiService : IApiBaseApiService
    {
       private readonly ILogger<ApiBaseApiService> logger;
       private readonly IUserService userService;
       public ApiBaseApiService(ILogger<ApiBaseApiService> _logger, IUserService _userService) 
       {
            logger = _logger;
            userService = _userService;
       }
       public async Task<ApiResponse> GetUserAsync(UserApiModel model)
       {
            ApiResponse response = new ApiResponse();
            response.ErrorList = new List<dynamic>();
            response.Data = new List<dynamic>();

            try
            {
                logger.LogInformation($"ApiBaseApiService.GetUserAsync- start at {DateTime.Now}");
                dynamic data =  await userService.GetUserAsync(model);
                response.Data.Add(data);
            }
            catch(Exception ex)
            {
                logger.LogError($"Error: {ex.Message}");
                response.ErrorList.Add(new {Message = ex.Message, StackTrace = ex.StackTrace});
            }
            finally
            {
                logger.LogInformation($"ApiBaseApiService.GetUserAsync- end at {DateTime.Now}");
            }

            return response;
       }
    }
}
