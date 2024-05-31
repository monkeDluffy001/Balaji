using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balaji.Common.Models
{
    public class Session
    {
        public decimal SessionId { get; set; }
        public string UserName { get;set; }
        public string Email { get; set; }
        public int UserType { get; set; }
        public string ConnectionString { get; set; }
        public DateTime SessionValadity { get; set; }
    }
}
