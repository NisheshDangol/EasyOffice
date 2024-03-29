﻿using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Login
    {
        public string ComID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NotificationToken { get; set; }
        public string DeviceID { get; set; }

    }
    //public class LoginViewModel:CommonResponse
    //{
    //    public int UID { get; set; }
    //    public string UserId { get; set; }
    //    public string DeviceCode { get; set; }
    //    public string FirstName { get; set; }
    //    public string MiddleName { get; set; }
    //    public string LastName { get; set; }
    //    public string Contact { get; set; }
    //    public string Pan { get; set; }
    //    public string Phone { get; set; }
    //    public string MaritalStatus { get; set; }
    //    public string DateOfBirth { get; set; }
    //    public string Email { get; set; }
    //    public string CitizenshipNo { get; set; }
    //    public string Gender { get; set; }
    //    public string BloodGroup { get; set; }
    //    public string Religion { get; set; }
    //    public string Address { get; set; }
    //    public string District { get; set; }
    //    public string Image { get; set; }
    //    public string IsManager { get; set; }
    //    public string FiscalYear { get; set; }
    //    public string FiscalId { get; set; }
    //    public string ShiftName { get; set; }
    //    public string ShiftStart { get; set; }
    //    public string ShiftEnd { get; set; }
    //    public string AllowedLateIn { get; set; }
    //    public string AllowedEarlyOut { get; set; }
    //    public string LaunchStart { get; set; }
    //    public string LaunchEnd { get; set; }
    //    public string ShiftTypeId { get; set; }
    //    public string ShiftID { get; set; }
    //    public string Branch { get; set; }
    //    public string GradeId { get; set; }
    //    public string GradeName { get; set; }
    //    public string EnrollDate { get; set; }
    //    public string DesignationName { get; set; }
    //    public int DesignationId { get; set; }
    //    public int DepartmentId { get; set; }
    //    public string DepartmentName { get; set; }
    //    public int SubDepartmentId { get; set; }
    //    public string SubDepartmentName { get; set; }
    //    public string JobType { get; set; }
    //    public string LeavedDate { get; set; }
    //    public string WorkingStatus { get; set; }
    //    public string WorkingDays { get; set; }
    //    public int BranchId { get; set; }
    //}
    public class ListOutPut : CommonResponse
    {
        public string Token { get; set; }
        public List<dynamic> Logins { get; set; }
    }
    public class CheckSessionOutput : CommonResponse
    {
        public List<dynamic> Logins { get; set; }
    }

    public class ChangePsw
    {
        public int UserID { get; set; }
        public string OldPwd { get; set; }
        public string NewPwd { get; set; }
    }
}
