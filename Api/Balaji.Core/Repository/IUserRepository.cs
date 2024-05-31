using Balaji.ApiModels;
using Balaji.Common.Models;
using Balaji.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balaji.Core.Repository
{
    public interface IUserRepository
    {
        public Task<dynamic> InsertUserAsync(PublicSession session, UserApiModel user);
    }
}
