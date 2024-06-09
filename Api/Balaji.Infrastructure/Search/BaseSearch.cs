using Balaji.Common.Models;
using Balaji.Core.Search;

namespace Balaji.Infrastructure.Search
{
    public class BaseSearch : IBaseSearch
    {
        public virtual Dictionary<string, string> Fields { get; set; }

        public string CreateQuery(SearchRequest request, string tables)
        {
            string sql = string.Empty;
            List<string> fields = request.Fields;
            List<Criterion> criterions = request.Criterion;
            List<Sort> sort = request.Sort;
            int page = request.Page;
            int pageSize = request.PageSize;

            // Adding output fields to sql statement
            if (fields.Count > 0)
            {
                sql += "SELECT ";

                for (int i = 0; i < fields.Count(); i++)
                {
                    string key = fields[i];

                    if (Fields.ContainsKey(key))
                    {
                        if (i == 0)
                        {
                            sql += Fields[key];
                        }
                        else
                        {
                            sql += $", {Fields[key]}";
                        }
                    }
                }
            }

            // Adding table to the sql statement
            if (!string.IsNullOrEmpty(sql))
            {
                sql += $" FROM {tables}";
            }

            // Adding conditions
            if (criterions.Count() > 0)
            {
                sql += " WHERE";

                for (int i = 0; i < criterions.Count(); i++)
                {
                    string key = criterions[i].Field;

                    if (Fields.ContainsKey(key))
                    {
                        if (i == 0)
                        {
                            sql += $" {Fields[key]} {criterions[i].Operator} {criterions[i].Value}";
                        }
                        else
                        {
                            sql += $" AND {Fields[key]} {criterions[i].Operator} {criterions[i].Value}";
                        }
                    }
                }
            }

            if (sort.Count() > 0)
            {
                sql += " ORDER BY";

                for (int i = 0; i < sort.Count(); i++)
                {
                    string key = sort[i].Field;
                    string order = sort[i].Order;

                    if (Fields.ContainsKey(key))
                    {
                        sql += $" {Fields[key]} {order}";
                    }
                }
            }

            // adding  pagination 
            if (page != 0 && pageSize != 0)
            {
                sql += " LIMIT";
                int offset = (page - 1) * pageSize;
                sql += $" {pageSize} OFFSET {offset}";
            }

            return sql;
        }

        public virtual string GetSqlStatement(SearchRequest request)
        {
            string tables = string.Empty;

            return CreateQuery(request, tables);
        }
    }
}
