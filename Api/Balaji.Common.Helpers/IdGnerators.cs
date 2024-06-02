using System.Security.Cryptography;
using System.Text;

namespace Balaji.Common.Helpers
{
    public class IdGnerators
    {
        public static string GenerateUniqueId(string uniqueKey)
        {
            // Get the current timestamp
            var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");

            // Concatenate the timestamp and uniqueKey
            var input = $"{timestamp}{uniqueKey}";

            // Compute the hash
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
