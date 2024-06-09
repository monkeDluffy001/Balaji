using Balaji.Common.Models;

namespace Balaji.Core.Repository
{
    public interface ISessionRepository
    {
        public Task<dynamic> AddSessionAsync(Session session);

        Task<Session> GetUserSession(PublicSession session, string sessionId);
    }
}
