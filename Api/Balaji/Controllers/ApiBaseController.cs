using Balaji.Api.ApiService;
using Balaji.ApiModels;
using Balaji.Common.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Balaji.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        private readonly ILogger<ApiBaseController> logger;
        private readonly IApiBaseApiService apiBaseService;
        public ApiBaseController(ILogger<ApiBaseController> _logger, IApiBaseApiService _apiBaseService)
        {
            logger = _logger;
            apiBaseService = _apiBaseService;
        }

        [HttpPost("", Name = "GetUserAsync")]
        
        public async Task<IActionResult> GetUserAsync(UserApiModel model)
        {
            try
            {
               logger.LogInformation($"ApiBase.GetUserAsync- start at {DateTime.Now}");

               ApiResponse response = await apiBaseService.GetUserAsync(model);

               return Ok(response);
            }
            catch(Exception ex)
            {
               logger.LogError($"Error: {ex.Message}");
               return BadRequest(ex.Message);
            }
            finally
            {
                logger.LogInformation($"ApiBase.GetUserAsync- end at {DateTime.Now}");
            }
        }
    }
}
