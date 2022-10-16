using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class JobReq
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public string Flag { get; set; }
        public int JobID { get; set; }
        public int DepartID { get; set; }
        public int SubDepartID { get; set; }
        public int DesignationID { get; set; }
        public int ShiftID { get; set; }
        public int ShiftTypeID { get; set; }
        public int JobTypeID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Responsibility { get; set; }
        public string Education  { get; set; }
        public int NoPos { get; set; }
        public string Experience  { get; set; }
        public int IsNeg  { get; set; }
        public int IsPaid  { get; set; }
        public string Salary { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string InterviewDate { get; set; }
        public int JobStatus { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public string Banner { get; set; }
    }
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

    public class JobApplication
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public string Flag { get; set; }
        public int JobID { get; set; }
        public int ApplicantID { get; set; }
        public int JobStatus { get; set; }
        public string FullName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string CV { get; set; }
        public string CVType { get; set; }
        public string Via { get; set; }
    }


    public class JobApplicationRes : CommonResponse
    {
        public List<dynamic> JobApplicantlst { get; set; }
    }
}
