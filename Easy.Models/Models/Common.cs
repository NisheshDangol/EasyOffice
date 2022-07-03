using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class OrgnizationGet
    {
        public string ComID { get; set; }
        public int UserID { get; set; }
        public string OrgName { get; set; }
        public int OrgType { get; set; }
        public string Address { get; set; }
        public int District { get; set; }
        public string LandLine { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public string PersonContact { get; set; }
        public string Email { get; set; }
        public string PAN { get; set; }
        public string Website { get; set; }
        public string Fb { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string CurrentSystem { get; set; }
        public string IFlag { get; set; }
        public int SourceID { get; set; }
        public int ProductID { get; set; }
        public int LeadStatus { get; set; }
        public int LAssignedTo { get; set; }
        public string EnquiryDate { get; set; }
        public string EnquiryTime { get; set; }
        public string LRemarks { get; set; }
        public int IsOurClient { get; set; }
        public int FollowType { get; set; }
        public string FollowDate { get; set; }
        public string FollowTime { get; set; }
        public int FAssignedTo { get; set; }
        public string FRemarks { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        
    }
}
