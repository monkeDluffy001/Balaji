using Balaji.Api.ApiService;
using Balaji.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Balaji.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        private readonly IUserApiService userApiService;
        private readonly ISessionApiService sessionApiService;

        public UsersController(
            ILogger<UsersController> _logger,
            IUserApiService _userApiService,
            ISessionApiService _sessionApiService)
        {
            logger = _logger;
            userApiService = _userApiService;
            sessionApiService = _sessionApiService;
        }

        [HttpPost("getuser", Name = "GetUserById")]
        public async Task<IActionResult> GetUserById([FromBody] SearchRequest request)
        {
            logger.LogInformation($"UsersController.GetUserById at {DateTime.Now}");

            try
            {
                var sessionId = User.Claims.FirstOrDefault(c => c.Type == "sessionId").Value;

                Session session = await sessionApiService.GetUserSessionAsync(sessionId).ConfigureAwait(false);

                ApiResponse response = await userApiService.SearchUserAsync(session, request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error: {ex.Message} at  {DateTime.Now}");
                ApiResponse response = new ApiResponse();
                response.ErrorList = new List<dynamic>()
                {
                   new {
                         Message = ex.Message,
                         StackTrace = ex.StackTrace
                       }
                };

                response.ErrorCount = response.ErrorList.Count();

                return BadRequest(response);
            }
        }
    }
}
