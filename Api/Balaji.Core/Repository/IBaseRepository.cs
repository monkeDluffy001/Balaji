using Balaji.Common.Models;

namespace Balaji.Core.Repository
{
    public interface IBaseRepository<T>
    {
        public Task<dynamic> InsertAsync(Session session, T model, string sqlStatement);

        public Task<dynamic> UpdateAsync(Session session, T model, string sqlStatement);

        public Task<List<T>> SaveAsync(Session session, T model, string sql);
    }
}
