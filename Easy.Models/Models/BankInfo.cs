using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class BankInfo
    {
        public string BankName { get; set; }
        public string AcNumber { get; set; }
        public string AcName { get; set; }
        public string Branch { get; set; }
    }
    public class Bank:CommonResponse
    {
        public List<dynamic> BankInfo { get; set; }
    }
}
