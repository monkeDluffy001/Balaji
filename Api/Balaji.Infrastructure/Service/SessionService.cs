using Balaji.Common.Models;
using Balaji.Core.Repository;
using Balaji.Core.Service;
using Microsoft.Extensions.Logging;

namespace Balaji.Infrastructure.Service
{
    public class SessionService : ISessionService
    {
        private readonly ILogger<SessionService> logger;
        private readonly ISessionRepository sessionRepository;

        public SessionService(ILogger<SessionService> _logger, ISessionRepository _sessionRepository)
        {
            logger = _logger;
            sessionRepository = _sessionRepository;
        }
        public async Task<dynamic> AddSessionAsync(Session session)
        {
            try
            {
                logger.LogInformation($"SessionService.SessionService at {DateTime.Now}");

                var result = await sessionRepository.AddSessionAsync(session);

                return result;
            }
            catch (Exception ex)
            {
                logger.LogError($"Error:{ex.Message} at {DateTime.Now}");
                throw;
            }
        }
    }
}
