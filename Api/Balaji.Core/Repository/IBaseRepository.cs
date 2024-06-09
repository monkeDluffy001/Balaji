using Balaji.Common.Models;

namespace Balaji.Core.Repository
{
    public interface IBaseRepository<TEntity>
    {
        public Task<dynamic> InsertAsync(Session session, TEntity model, string sqlStatement);

        public Task<dynamic> UpdateAsync(Session session, TEntity model, string sqlStatement);

        public Task<List<TEntity>> SaveAsync(Session session, TEntity model, string sql);

        Task<List<TEntity>> QueryAsync(Session session, string? sql);

        Task<List<TEntity>> QueryAsync(PublicSession session, string? sql);
    }
}
