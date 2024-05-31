using Balaji.Api.ApiService;
using Balaji.ApiModels;
using Balaji.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Balaji.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
       private readonly ILogger<SessionController> logger;
       private readonly ISessionApiService sessionApiService;
        private readonly IConfiguration configuration;
       

        public SessionController(ILogger<SessionController> logger, ISessionApiService sessionApiService, IConfiguration configuration)
        {
            this.logger = logger;
            this.sessionApiService = sessionApiService;
            this.configuration = configuration;
        }

        [HttpPost("add", Name = "AddUserAsync")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserApiModel user)
        {
            try
            {
                logger.LogInformation($"SessionController.AddUserAsync at {DateTime.Now}");
                
                PublicSession session = new PublicSession();

                session.ConnectionString = configuration.GetConnectionString("Default");

                ApiResponse response = await sessionApiService.AddUserAsync(session, user).ConfigureAwait(false);

                return Ok(response);                
            }
            catch(Exception ex)
            {
                logger.LogError($"Error: {ex.Message} at {DateTime.Now}");

                ApiResponse response = new ApiResponse();

                response.ErrorList = new List<dynamic>()
                {
                   new { Message = ex.Message, trace = ex.StackTrace}
                };

                response.ErrorCount = response.ErrorList.Count();

                return BadRequest(response);
            }
        }

        [HttpPost("login", Name = "LoginUserAsync")]
        public async Task<IActionResult> LoginUserAsync([FromBody] UserApiModel user)
        {
            try
            {

            }
            catch(Exception ex)
            {

            }

            return Ok();
        }
        
    }
}
