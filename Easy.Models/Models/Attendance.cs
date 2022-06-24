using Easy.Connection;
using Newtonsoft.Json.Linq;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class CreateAttendance
    {
        public string ComID { get; set; }
        public int UserID { get; set; }
        public int DepartmentID { get; set; }
        public int SubDepartmentID { get; set; }
        public int DesignationID { get; set; }
        public string AttenDate { get; set; }
        public string AttenTime { get; set; }
        public int AttenStatus { get; set; }
        public int AttenPlace { get; set; }
        public int AttenVia { get; set; }
        public int FiscalID { get; set; }
        public int BrachID { get; set; }
    }

    public class AttendanceReportMonth:CommonResponse
    {
        public List<dynamic> AttenRepMonth { get; set; }
    }

    public class BulkAttendance
    {
        public string ComID { get; set; }
        //public int UserID { get; set; }
        //public int DepartmentID { get; set; }
        //public int SubDepartmentID { get; set; }
        //public int DesignationID { get; set; }
        //public string AttenDate { get; set; }
        //public string AttenTime { get; set; }
        //public int AttenStatus { get; set; }
        //public int AttenPlace { get; set; }
        public int StaffID { get; set; }
        public List<JSonParam> Param { get; set; }
        //public int Flag { get; set; }
        public int AttenPlace { get; set; }
        public int FiscalID { get; set; }
        public int BranchID { get; set; }

    }

    public class JSonParam
    {
        public int UserID { get; set; }        
        public string AttenDate { get; set; }
        public string AttenTime { get; set; }
        
    }
     
    public class AttendanceSummary:CommonResponse
    {
        public List<dynamic> AttenSummary { get; set; }
    }

    //public class Attendance
}
