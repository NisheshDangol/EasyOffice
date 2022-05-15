using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class CustomerSupport
    {
        public string ComID { get; set; }
        public int UserID { get; set; }
        public int OrgID { get; set; }
        public int ProductID { get; set; }
        public string Issue { get; set; }
        public DateTime IssueDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Attachment { get; set; }
        public int AssignedTo { get; set; }
        public int SupportStatus { get; set; }
        public int SupportMedium { get; set; }
        public string ClientComment { get; set; }
        public string Remarks { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
    }

    //public class CustomerSupportList
    //{
    //    public int CustomerSupportId { get; set; }
    //    public string OrganizationName { get; set; }
    //    public string ProductName { get; set; }
    //    public string Issue { get; set; }
    //    public string IssueDate { get; set; }
    //    public string StartTime { get; set; }
    //    public string EndTime { get; set; }
    //    public string Attachment { get; set; }
    //    public string UserName { get; set; }
    //    public string AssignedToId { get; set; }
    //    public string SupportStatus { get; set; }
    //    public string SupportMedium { get; set; }
    //    public DateTime AddedDate { get; set; }
    //}
    public class CustomerSupportListDto:CommonResponse
    {
        public List<dynamic> Customerlist { get; set; }

    }

    //public class CustomerSupportInfo
    //{
    //    public string OrgId { get; set; }
    //    public string OrganizationName { get; set; }
    //    public string ProductId { get; set; }
    //    public string ProductName { get; set; }
    //    public string Issue { get; set; }
    //    public string IssueDate { get; set; }
    //    public string StartTime { get; set; }
    //    public string EndTime { get; set; }
    //    public string Attachment { get; set; }
    //    public string AssignedToId { get; set; }
    //    public string AssignedTo { get; set; }
    //    public string SupportStatusId { get; set; }
    //    public string SupportStatus { get; set; }
    //    public string SupportMediumId { get; set; }
    //    public string SupportMedium { get; set; }
    //    public string ClientComment { get; set; }
    //    public string Remarks { get; set; }
    //    public string AddedDate { get; set; }
    //}
    public class CustomerSupportInfoDto :CommonResponse
    {
        public List<dynamic> CustomerSupportInfo { get; set; }
    }
}
