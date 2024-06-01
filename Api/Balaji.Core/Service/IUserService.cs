using Balaji.ApiModels;
using Balaji.Common.Models;
using Balaji.Domain;

namespace Balaji.Core.Service
{
    public interface IUserService
    {
        public Task<dynamic> GetUserAsync(UserApiModel model);
        public Task<dynamic> AddUserAsync(PublicSession session, UserApiModel user);
        public Task<List<User>> GetUserDetailsAsync(PublicSession session, UserApiModel model);
    }
}
