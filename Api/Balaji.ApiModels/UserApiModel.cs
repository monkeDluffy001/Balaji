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
           o.UserName = o.UserName;
           o.Password = o.Password;
        }
    }
}
