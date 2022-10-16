using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Leave
    {
        public string ComID { get; set; }
        public int UserID { get; set; }
        public int LeaveTypeID { get; set; }
        public int DayTypeID { get; set; }
        public string Title { get; set; }
        public string Cause { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string FromNepDate { get; set; }
        public string ToNepDate { get; set; }
        public int IsFieldWork { get; set; }
        public int LeaveAssignedTo { get; set; }
        public int Notify { get; set; }
        public int FiscalID { get; set; }
        public int BranchID { get; set; }
    }

    public class LeaveTypeList: CommonResponse
    {
        public List<dynamic> LeaveList { get; set; }
    }

    public class UserLeaveType: CommonResponse
    {
        public List<dynamic> LeaveType { get; set; }
    }

    public class LeaveReport : CommonResponse
    {
        public List<dynamic> LeaveReports { get; set; }
    }

    public class UpdateLeaveStatus
    {
        public string ComID { get; set; }
        public int UserID { get; set; }
        public int LeaveID { get; set; }
        public int Status { get; set; }
    }


    public class LeaveReq
    {
        public string ComID { get; set; }
        public int UserID { get; set; }
        public string Flag { get; set; }
        public string DFlag { get; set; }
        public string Values { get; set; }
        public int Status { get; set; }
        public int LeaveStatus { get; set; }
        public int BranchID { get; set; }
        public int StaffID { get; set; }
        public int FiscalID { get; set; }
        public int LeaveID { get; set; }
        public bool SendEmail { get; set; }
    }
}
