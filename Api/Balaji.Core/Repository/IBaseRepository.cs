using Balaji.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balaji.Core.Repository
{
    public interface IBaseRepository<T>
    {
        public Task<dynamic> InsertAsync(Session session, T model, string sqlStatement);

        public Task<dynamic> UpdateAsync(Session session, T model, string sqlStatement);
    }
}
