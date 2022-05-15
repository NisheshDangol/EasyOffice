using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Lead
    {
        public string ComID { get; set; }
        public int UserID { get; set; }
        public int OrgID { get; set; }
        public int ProductID { get; set; }
        public string EnquiryDate { get; set; }
        public string EnquiryTime { get; set; }
        public int StaffID { get; set; }
        public string Remarks { get; set; }
        public int LeadStatus { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int LeadSource { get; set; }
    }
}
