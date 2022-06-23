using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class AdminDepartmentReq
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public string Department { get; set; }
        public int DepHeadID { get; set; }
        public string Flag { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int DepartmentID { get; set; }
        public int Status { get; set; }
    }

    public class AdminDepartmentRes:CommonResponse
    {
        public List<dynamic> list { get; set; }
    }
}
