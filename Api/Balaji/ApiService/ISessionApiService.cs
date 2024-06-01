using Balaji.ApiModels;
using Balaji.Common.Models;

namespace Balaji.Api.ApiService
{
    public interface ISessionApiService
    {
        public Task<ApiResponse> AddUserAsync(PublicSession session, UserApiModel model);
        public Task<ApiResponse> LoginUserAsync(PublicSession session, UserApiModel credentials);
    }
}
