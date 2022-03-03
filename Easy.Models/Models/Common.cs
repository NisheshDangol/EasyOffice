using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class OrgnizationGet
    {
        public string CompanyId { get; set; }
        public int EmployeId { get; set; }
        public string OrganizationName { get; set; }
        public int OrganizationType { get; set; }
        public string Address { get; set; }
        public int District { get; set; }
        public string LandLine { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public string PersonContact { get; set; }
        public string Email { get; set; }
        public string Pan { get; set; }
        public string Website { get; set; }
        public string Fb { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Source { get; set; }
        public int IsOurClient { get; set; }
        public string CurrentSystem { get; set; }
        public int BranchId { get; set; }
        public int FiscalId { get; set; }
    }
}
