using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balaji.Common.Models
{
    public class ApiResponse
    {
       public int DataCount { get; set; }
       public int ErrorCount { get; set; }
       public List<dynamic> ErrorList { get; set; }
       public List<dynamic> Data { get; set; }
    }
}
