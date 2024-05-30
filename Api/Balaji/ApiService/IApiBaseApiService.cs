using Balaji.ApiModels;
using Balaji.Common.Models;

namespace Balaji.Api.ApiService
{
    public interface IApiBaseApiService
    {
        public Task<ApiResponse> GetUserAsync(UserApiModel model);
    }
}
