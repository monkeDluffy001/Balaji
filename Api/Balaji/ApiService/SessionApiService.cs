using Balaji.ApiModels;
using Balaji.Common.Helpers;
using Balaji.Common.Models;
using Balaji.Core.Service;

namespace Balaji.Api.ApiService
{
    public class SessionApiService : ISessionApiService
    {
        private readonly ILogger<SessionApiService> logger;
        private readonly IUserService userService;
        public SessionApiService(ILogger<SessionApiService> logger, IUserService userService) 
        {
            this.logger = logger;
            this.userService = userService;
        }

        public List<dynamic> ValidateUser(UserApiModel user)
        {
            List<dynamic> errorList = new List<dynamic>();

            if (!Validations.IsValidEmail(user.Email))
            {
                errorList.Add("User Email is not Valid");
            }

            if (!Validations.IsValidPhoneNumber(user.MobileNumber))
            {
                errorList.Add("User mobile number is not Valid");
            }

            if (!Validations.IsStrongPassword(user.Password))
            {
                errorList.Add("Entered a weak Password");
            }
          
            return errorList;
        }
        public async Task<ApiResponse> AddUserAsync(PublicSession session, UserApiModel user)
        {
            
            ApiResponse response = new ApiResponse();
            response.ErrorList = new List<dynamic>();
            response.Data = new List<dynamic>();

            try
            {
                logger.LogInformation($"SessionApiService.AddUserAsync at {DateTime.Now}");

                List<dynamic> errorList = ValidateUser(user);
                if(errorList.Count() > 0)
                {
                    response.ErrorList = errorList;
                    response.ErrorCount = errorList.Count();

                    return response;
                }

                var res = await userService.AddUserAsync(session, user).ConfigureAwait(false);

                response.Data.Add(res);
            }
            catch(Exception ex)
            {
                logger.LogError($"Error: {ex.Message} at {DateTime.Now}");
                response.ErrorList.Add( new { Message = ex.Message, StackTrace = ex.StackTrace });
                response.ErrorCount = response.ErrorList.Count();
            }

            return response;     
        }
    }
}
