using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class User:CommonResponse
    {
        public List<dynamic> UserList { get; set; }
    }

    public class UserReq
    {
        public string ComID { get; set; }
        public string Flag { get; set; }
        public int StaffID { get; set; }
        public string UserID { get; set; }
        public string UserCode { get; set; }
        public int DeviceCode { get; set; }
        public string MobileID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int District { get; set; }
        public string DateOfBirth { get; set; }
        public string CitizenshipNo { get; set; }
        public string PAN { get; set; }
        public int Gender { get; set; }
        public int BloodGroup { get; set; }
        public int Religion { get; set; }
        public int MaritialStatus { get; set; }
        public string Image { get; set; }
        public string EnrollDate { get; set; }
        public int WorkingStatus { get; set; }
        public string LeaveDate { get; set; }
        public int JobType { get; set; }
        public int Shift { get; set; }
        public int ShiftType { get; set; }
        public int Grade { get; set; }
        public int Department { get; set; }
        public int SubDepartment { get; set; }
        public int Designation { get; set; }
        public int WorkintDays { get; set; }
        public int IsManager { get; set; }
        public int FiscalID { get; set; }
        public int BranchID { get; set; }
        public int Status { get; set; }
        public int UID { get; set; }
    }


    public class UserActivity:CommonResponse
    {
        public List<dynamic> UserAct { get; set; }
    }
}
