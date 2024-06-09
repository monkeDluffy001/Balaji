using Balaji.Common.Models;

namespace Balaji.Api.ApiService
{
    public interface IUserApiService
    {
        Task<ApiResponse> SearchUserAsync(Session session, SearchRequest request);
    }
}
