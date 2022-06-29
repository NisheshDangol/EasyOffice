using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Shift:CommonResponse
    {
        public List<dynamic> ShiftList { get; set; }
    }

    public class ShiftReq
    {
        public string ComID { get; set; }
        public string StaffID { get; set; }
        public string Flag { get; set; }
        public string Shift { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string AllowLateIn { get; set; }
        public string AllowEarlyOut { get; set; }
        public string LunchStart { get; set; }
        public string LunchEnd { get; set; }
        public string FiscalID { get; set; }
        public string BranchID { get; set; }
        public string ShiftID { get; set; }
        public int Status { get; set; }
        public int HDHour { get; set; }
    }
}
