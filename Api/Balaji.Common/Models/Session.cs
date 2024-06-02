namespace Balaji.Common.Models
{
    public class Session
    {
        public string? SessionId { get; set; }

        public long UserId { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }

        public int UserType { get; set; }

        public string? MobileNumber { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? CountryCode { get; set; }

        public string? ConnectionString { get; set; }

        public DateTime SessionValidity { get; set; }
    }
}
