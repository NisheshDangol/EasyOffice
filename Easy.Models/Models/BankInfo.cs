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
        public string bankName { get; set; }
        public string acNumber { get; set; }
        public string acName { get; set; }
        public string branch { get; set; }
    }
    public class Bank:CommonResponse
    {
        public List<BankInfo> BankInfo { get; set; }
    }
}
