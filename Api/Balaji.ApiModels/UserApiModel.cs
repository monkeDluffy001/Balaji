using Balaji.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balaji.ApiModels
{
    public class UserApiModel: User
    {
        public UserApiModel() { }
        public UserApiModel(User o) {
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
