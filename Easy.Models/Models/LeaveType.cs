using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class LeaveType:CommonResponse
    {
        public List<dynamic> LeaveLst { get; set; }
    }

    public class LeaveTypeReq
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public string Flag { get; set; }
        public string Name { get; set; }
        public string Balance { get; set; }
        public int IsPaid { get; set; }
        public int IsCarryable { get; set; }
        public int Gender { get; set; }
        public string Description { get; set; }
        public int BrancID { get; set; }
        public int FiscalID { get; set; }
        public int Status { get; set; }
        public int LeaveID { get; set; }
    }
}
