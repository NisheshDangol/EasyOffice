using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Lead
    {
        public string CompanyId { get; set; }
        public int EmpId { get; set; }
        public int OrganizationId { get; set; }
        public int ProductId { get; set; }
        public DateTime EnquiryDate { get; set; }
        public string EnquiryTime { get; set; }
        public int Assignedto { get; set; }
        public string Remarks { get; set; }
        public int LeadStatus { get; set; }
        public int BranchId { get; set; }
        public int FiscalId { get; set; }
    }
}
