using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class SubDepartment:CommonResponse
    {
        public List<dynamic> SubDepList { get; set; }
    }

    public class SubDepartmentReq
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public int DepartID { get; set; }
        public int SubDepartID { get; set; }
        public string SubDepartName { get; set; }
        public int SubDepHeadID { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int Status { get; set; }
        public string Flag { get; set; }
    }
}
