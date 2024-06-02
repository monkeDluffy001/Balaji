using Balaji.Common.Models;
using Balaji.Core.Repository;

namespace Balaji.Infrastructure.Repository
{
    public class SessionRepository : BaseRepository<Session>, ISessionRepository
    {
        private readonly string? tableName = "sessions";
        public async Task<dynamic> AddSessionAsync(Session session)
        {
            string sql = $@"
                insert into {tableName} (SessionId
                , UserId
                , UserName
                , Email
                , UserType
                , MobileNumber
                , FirstName
                , LastName
                , CountryCode
                , ConnectionString
                , SessionValidity
                )   VALUES ( @SessionId,
                    @UserId,
                    @UserName,
                    @Email,
                    @UserType,
                    @MobileNumber,
                    @FirstName,
                    @LastName,
                    @CountryCode,
                    @ConnectionString,
                    @SessionValidity);
                select last_insert_id();
            ";

            var res = await InsertAsync(session, session, sql);

            return res;
        }
    }
}
