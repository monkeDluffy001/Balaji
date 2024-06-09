using Balaji.Common.Models;

namespace Balaji.Core.Search
{
    public interface IBaseSearch
    {
        public string GetSqlStatement(SearchRequest request);
        string CreateQuery(SearchRequest request, string tables);
    }
}
