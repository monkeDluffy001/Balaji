using Balaji.ApiModels;
using Balaji.Common.Models;
using Balaji.Domain;

namespace Balaji.Core.Repository
{
    public interface IUserRepository
    {
        public Task<dynamic> InsertUserAsync(PublicSession session, UserApiModel user);
        public Task<List<User>> LoginUserInfo(PublicSession session, User model);
    }
}
