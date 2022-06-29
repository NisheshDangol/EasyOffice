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


    public class BankAdminRes : CommonResponse
    {
        public List<dynamic> BankLst { get; set; }
    }

    public class BankAdminReq
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public int UserID { get; set; }
        public string Flag { get; set; }
        public string BankName { get; set; }
        public string AcName { get; set; }
        public string AcNo { get; set; }
        public string Branch { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int Status { get; set; }
        public int BankID { get; set; }
    }
}
