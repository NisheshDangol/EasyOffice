using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Followup
    {
        public string CompanyId { get; set; }
        public int CreatedBy { get; set; }
        public int OrganizationId { get; set; }
        public int ProductId { get; set; }
        public string FollowDate { get; set; }
        public string FollowTime { get; set; }
        public int AssignedTo { get; set; }
        public string Remarks { get; set; }
        public int FollowStatus { get; set; }
        public int FollowType { get; set; }
        public int BranchId { get; set; }
        public int FiscalId { get; set; }
    }
    public class FollowupList
    {
        public int OrgId { get; set; }
        public string OrgName { get; set; }
        public string OrgType { get; set; }
        public string FollowStatus { get; set; }
        public string FollowTypeName { get; set; }
        public string ProductName { get; set; }
        public string FollowDate { get; set; }
        public string FollowTime { get; set; }
        public string AssignTo { get; set; }
    }
    public class FollowupListDto:CommonResponse
    {
        public List<FollowupList> FollowupLists { get; set; }
    }

    public class Followuptype
    {
        public int FollowTypeID { get; set; }
        public string FollowTypeName { get; set; }
        public string OrganizationCount { get; set; } 
        public string PersonCount { get; set; } 
    }
    public class FollowUpTypeDto:CommonResponse
    {
        public List<Followuptype> Followuptype { get; set; }
    }
}
