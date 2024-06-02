using Balaji.Domain;

namespace Balaji.ApiModels
{
    public class UserApiModel : User
    {
        public UserApiModel() { }
        public UserApiModel(User o)
        {
            UserType = o.UserType;
            FirstName = o.FirstName;
            LastName = o.LastName;
            MiddleName = o.MiddleName;
            Address = o.Address;
            MobileNumber = o.MobileNumber;
            Email = o.Email;
            Password = o.Password;
            CountryCode = o.CountryCode;
        }
    }
}
