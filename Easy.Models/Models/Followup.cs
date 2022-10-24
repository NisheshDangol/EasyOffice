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
        public string ComID { get; set; }
        public int UserID { get; set; }
        public int ReferID { get; set; }
        public string ClientID { get; set; }
        public int CampaignID { get; set; }
        public int ProductID { get; set; }
        public int FollowType { get; set; }
        public string FollowFor { get; set; }
        public string FollowDate { get; set; }
        public string FollowTime { get; set; }
        public int AssignedTo { get; set; }
        public string Remarks { get; set; }
        public int FollowStatus { get; set; }
        public string NewExtra { get; set; }
        public Extraa Extra { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public string ContactPerson { get; set; }
        public string Contact { get; set; }
    }

    public class Extraa
    {
        public int ProductID { get; set; }
        public int FollowType { get; set; }
        public string FollowFor { get; set; }
        public string FollowDate { get; set; }
        public string FollowTime { get; set; }
        public string ContactPerson { get; set; }
        public string Contact { get; set; }
        public int AssignedTo { get; set; }
    }
    //public class FollowupList
    //{
    //    public int OrgID { get; set; }
    //    public string OrgName { get; set; }
    //    public string OrgType { get; set; }
    //    public string FollowStatus { get; set; }
    //    public string FollowTypeName { get; set; }
    //    public string ProductName { get; set; }
    //    public string FollowDate { get; set; }
    //    public string FollowTime { get; set; }
    //    public string AssignTo { get; set; }
    //}
    public class FollowupListDto:CommonResponse
    {
        public List<dynamic> FollowupLists { get; set; }
    }

    //public class Followuptype
    //{
    //    public int FollowTypeID { get; set; }
    //    public string FollowTypeName { get; set; }
    //    public string OrganizationCount { get; set; } 
    //    public string PersonCount { get; set; } 
    //}
    public class FollowUpTypeDto:CommonResponse
    {
        public List<dynamic> FollowupType { get; set; }
    }


    public class FollowTypeAdmin
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public string Flag { get; set; }
        public string Name { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int FollowTypeID { get; set; }
        public int Status { get; set; }
        public int LeadSrcID { get; set; }
    }

    public class FollowTypeAdminRes:CommonResponse
    {
        public List<dynamic> FlwTypeLst { get; set; }
    }
}
