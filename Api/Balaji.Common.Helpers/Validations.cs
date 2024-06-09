using Balaji.Common.Models;
using System.Text.RegularExpressions;

namespace Balaji.Common.Helpers
{
    public class Validations
    {
        public static bool IsValidEmail(string email)
        {
            // Regular expression pattern for a basic email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            // Use Regex.IsMatch to check if the email matches the pattern
            return Regex.IsMatch(email, pattern);
        }

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            // Regular expression pattern for mobile number validation
            string pattern = @"^\d{10}$";

            // Use Regex.IsMatch to check if the phone number matches the pattern
            return Regex.IsMatch(phoneNumber, pattern);
        }

        public static bool IsStrongPassword(string password)
        {
            // Regular expression pattern for strong password validation
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";

            // Use Regex.IsMatch to check if the password matches the pattern
            return Regex.IsMatch(password, pattern);
        }

        public static bool IsNotNull(string value)
        {
            return value != null;
        }

        public static List<dynamic> ValidateSearchRequest(SearchRequest request)
        {
            int page = request.Page;
            int pageSize = request.PageSize;
            List<string> allowedOperators = new List<string>()
            {
                "=",
                "<>",
                ">",
                "<",
                ">=",
                "<=",
                "IN",
                "LIKE",
                "IS NULL",
                "IS NOT NULL"
            };
            List<string> allowedOrders = new List<string>()
            {
              "ASC",
              "DESC"
            };
            List<dynamic> errorList = new List<dynamic>();
            List<Criterion> criterions = request.Criterion;
            List<string> fields = request.Fields;
            List<Sort> sort = request.Sort;

            if (page < 0)
            {
                errorList.Add(new
                {
                    Message = "Page cannot be negative",
                    StackTrace = "ValidateSearchRequest at Balaji.Common.Helpers.Validations"
                });
            }

            if (pageSize < 0)
            {
                errorList.Add(new
                {
                    Message = "PageSize cannot be negative",
                    StackTrace = "ValidateSearchRequest at Balaji.Common.Helpers.Validations"
                });
            }

            if (fields.Count() == 0)
            {
                errorList.Add(new
                {
                    Message = "Field list is empty!",
                    StackTrace = "ValidateSearchRequest at Balaji.Common.Helpers.Validations"
                });
            }
            else
            {
                foreach (string field in fields)
                {
                    if (string.IsNullOrEmpty(field))
                    {
                        errorList.Add(new
                        {
                            Message = "Field list contains empty fields ",
                            StackTrace = "ValidateSearchRequest at Balaji.Common.Helpers.Validations "
                        });
                        break;
                    }
                }
            }

            if (sort.Count() > 0)
            {
                foreach (Sort item in sort)
                {
                    if (string.IsNullOrEmpty(item.Field))
                    {
                        errorList.Add(new
                        {
                            Message = "sort contains empty fields",
                            StackTrace = "ValidateSearchRequest at Balaji.Common.Helpers.Validations "
                        });
                        break;
                    }

                    if (string.IsNullOrEmpty(item.Order) || !allowedOrders.Contains(item.Order.ToUpper()))
                    {
                        errorList.Add(new
                        {
                            Message = "Invalid sort order in sort list",
                            StackTrace = "ValidateSearchRequest at Balaji.Common.Helpers.Validations "
                        });
                        break;
                    }
                }
            }

            if (criterions.Count() > 0)
            {
                foreach (Criterion criteria in criterions)
                {
                    if (string.IsNullOrEmpty(criteria.Field))
                    {
                        errorList.Add(new
                        {
                            Message = "Criterion contains empty fields",
                            StackTrace = "ValidateSearchRequest at Balaji.Common.Helpers.Validations "
                        });
                        break;
                    }

                    if (string.IsNullOrEmpty(criteria.Operator) || !allowedOperators.Contains(criteria.Operator.ToUpper()))
                    {
                        errorList.Add(new
                        {
                            Message = "Criterion contains invalid operators",
                            StackTrace = "ValidateSearchRequest at Balaji.Common.Helpers.Validations "
                        });

                        break;
                    }
                }
            }

            return errorList;
        }
    }
}
