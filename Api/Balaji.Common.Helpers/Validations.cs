using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
    }
}
