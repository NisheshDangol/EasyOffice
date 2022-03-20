using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class CustomerSupport
    {
        public string CompanyId { get; set; }
        public int EmplopyeeId { get; set; }
        public int OrganizationId { get; set; }
        public int ProductId { get; set; }
        public string Issue { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Attachment { get; set; }
        public int AssignedTo { get; set; }
        public int SupportStatus { get; set; }
        public string SupportMedium { get; set; }
        public string clientComment { get; set; }
        public string Remarks { get; set; }
        public int BranchId { get; set; }
        public int FiscalId { get; set; }
    }
}
