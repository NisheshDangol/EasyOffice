using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    //public class Jobinfo
    //{
    //    public string DesignationName { get; set; }
    //    public string DepartmentName { get; set; }
    //    public string SubDepartmentName { get; set; }
    //    public string Grade { get; set; }
    //    public string Manager { get; set; }
    //    public string WorkingStatus { get; set; }
    //    public string StartDate { get; set; }
    //    public string EndDate { get; set; }
    //}
    public class JobReturn : CommonResponse
    {
        public List<dynamic> JobInfo { get; set; }
    }

    public class JobInfoAdmin : CommonResponse
    {
        public List<dynamic> JobInfo { get; set; }
    }

    public class JobInfoReq
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public string Flag { get; set; }
        public int UserID { get; set; }
        public int DepartmentID { get; set; }
        public int SubDepartmentID { get; set; }
        public int DesignationID { get; set; }
        public int GradeID { get; set; }
        public int JobType { get; set; }
        public int WorkingStatus { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int Status { get; set; }
        public int JobID { get; set; }
    }
}
