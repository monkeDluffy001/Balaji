using Balaji.ApiModels;
using Balaji.Common.Models;
using Balaji.Core.Repository;
using Balaji.Domain;
using Dapper;
using MySqlConnector;

namespace Balaji.Infrastructure.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private string tableName = "user";
        public async Task<dynamic> InsertUserAsync(PublicSession session, UserApiModel user)
        {

            string sql = $@"
                insert into {tableName} ( UserType
                , FirstName
                , LastName
                , MiddleName
                , Address
                , MobileNumber
                , Email
                , Password
                , CountryCode
                )   VALUES ( @UserType
                , @FirstName
                , @LastName
                , @MiddleName
                , @Address
                , @MobileNumber
                , @Email
                , @Password
                , @CountryCode);
                select last_insert_id();
            ";

            User obj = (User)user;
            var res = await InsertAsync(session, obj, sql);

            return res;
        }

        public async Task<List<User>> LoginUserInfo(PublicSession session, User model)
        {
            string? sql = $@"SELECT 
                             Id,
                             UserType,
                             FirstName,
                             LastName,
                             MiddleName,
                             Address,
                             MobileNumber,
                             Email,
                             Password,
                             CountryCode
                           FROM 
                             User
                           WHERE 
                             Email = @Email AND Password = @Password;";

            try
            {
                List<User> result;

                string? connectionString = session?.ConnectionString;

                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new Exception("Empty connection string");
                }

                using (var connection = new MySqlConnection(connectionString))
                {
                    var res = await connection.QueryAsync<User>(sql, new { Email = model.Email, Password = model.Password });
                    result = res.ToList();
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
