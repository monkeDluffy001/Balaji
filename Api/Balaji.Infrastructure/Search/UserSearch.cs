using Balaji.Common.Models;
using Balaji.Core.Search;

namespace Balaji.Infrastructure.Search
{
    public class UserSearch : BaseSearch, IUserSearch
    {
        public override Dictionary<string, string> Fields { get; set; } = new Dictionary<string, string>()
        {
            { "UserId", "u.Id" },
            { "FirstName", "u.FirstName" },
            { "LastName", "u.LastName" },
            { "MiddleName", "u.MiddleName" },
            { "Address", "u.Address" },
            { "Email", "u.Email" },
            { "MobileNumber", "u.MobileNumber, u.CountryCode" },
        };

        public override string GetSqlStatement(SearchRequest request)
        {
            string tables = $@"user u";

            return CreateQuery(request, tables);
        }
    }
}
