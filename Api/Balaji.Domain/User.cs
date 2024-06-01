namespace Balaji.Domain
{
    public class User
    {
        public int Id { get; set; }
        public int UserType { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleName { get; set; } = string.Empty;
        public string? Address { get; set; }
        public string? MobileNumber { get; set; }
        public string? Email { get; set; } = string.Empty;
        public string? Password { get; set; }
        public string? CountryCode { get; set; }
    }
}
