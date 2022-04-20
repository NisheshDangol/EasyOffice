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
        public int EmpID { get; set; }
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
        public int Source { get; set; }
        public int IsOurClient { get; set; }
        public string CurrentSystem { get; set; }
        public int StaffID { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int AssignedTo { get; set; }
    }
}
