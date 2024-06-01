using Balaji.ApiModels;
using Balaji.Common.Helpers;
using Balaji.Common.Models;
using Balaji.Core.Service;
using Balaji.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Balaji.Api.ApiService
{
    public class SessionApiService : ISessionApiService
    {
        private readonly ILogger<SessionApiService> logger;
        private readonly IUserService userService;
        private readonly IConfiguration configuration;

        public SessionApiService(
            ILogger<SessionApiService> _logger,
            IUserService _userService,
            IConfiguration _configuration
        )
        {
            logger = _logger;
            userService = _userService;
            configuration = _configuration;
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
                if (errorList.Count() > 0)
                {
                    response.ErrorList = errorList;
                    response.ErrorCount = errorList.Count();

                    return response;
                }

                var res = await userService.AddUserAsync(session, user).ConfigureAwait(false);

                response.Data.Add(res);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error: {ex.Message} at {DateTime.Now}");
                response.ErrorList.Add(new { Message = ex.Message, StackTrace = ex.StackTrace });
                response.ErrorCount = response.ErrorList.Count();
            }

            return response;
        }

        public async Task<ApiResponse> LoginUserAsync(PublicSession session, UserApiModel credentials)
        {
            ApiResponse response = new ApiResponse();
            response.ErrorList = new List<dynamic>();
            response.Data = new List<dynamic>();

            try
            {
                logger.LogInformation($"SessionApiService.LoginUserAsync at {DateTime.Now}");

                List<User> list = await userService.GetUserDetailsAsync(session, credentials).ConfigureAwait(false);

                if (list.Count() == 0)
                {
                    throw new Exception("No user found");
                }

                // creating session 
                User currentUser = list[0];

                Session userSession = new Session()
                {
                    UserId = currentUser.Id,
                    UserName = currentUser.Email,
                    Email = currentUser.Email,
                    UserType = currentUser.UserType,
                    MobileNumber = currentUser.MobileNumber,
                    FirstName = currentUser.FirstName,
                    LastName = currentUser.LastName,
                    CountryCode = currentUser.CountryCode,
                    ConnectionString = session.ConnectionString ?? string.Empty,
                    SessionValadity = DateTime.Now.AddHours(1)
                };

                // Generate Token
                var jwtSettings = configuration.GetSection("Jwt");
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                                issuer: jwtSettings["Issuer"],
                                audience: jwtSettings["Audience"],
                                expires: DateTime.Now.AddMinutes(
                                    Convert.ToDouble(jwtSettings["DurationInMinutes"])
                                ),
                                signingCredentials: creds);

                response.Data.Add(new
                {
                    Token = token
                });

                response.DataCount = response.Data.Count();

                return response;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error: {ex.Message} at {DateTime.Now} ");
                response.ErrorList.Add(new
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                });
                response.ErrorCount = response.ErrorList.Count();
                return response;
            }
        }
    }
}
