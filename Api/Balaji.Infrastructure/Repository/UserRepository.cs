using Balaji.ApiModels;
using Balaji.Common.Models;
using Balaji.Core.Repository;
using Balaji.Core.Service;
using Balaji.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            User obj = (User) user;
            var res = await InsertAsync(session, obj, sql);

            return res;
       }
    }
}
