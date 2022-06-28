using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Branch: CommonResponse
    {
        public List<dynamic> BranchLst { get; set; }
    }

    public class BranchReq
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public string Flag { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int District { get; set; }
        public int FiscalID { get; set; }
        public int BranchID { get; set; }
        public int Status { get; set; }
    }
}
