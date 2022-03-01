using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Login
    {
        public string CompanyId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string NotificationToken { get; set; }
        public string DeviceId { get; set; }
    }
    public class LoginViewModel
    {
        public int UID { get; set; }
        public string deviceCode { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string contact { get; set; }
        public string pan { get; set; }
        public string phone { get; set; }
        public string maritalStatus { get; set; }
        public string dateOfBirth { get; set; }
        public string email { get; set; }
        public string citizenshipNo { get; set; }
        public string gender { get; set; }
        public string bloodgroup { get; set; }
        public string religion { get; set; }
        public string address { get; set; }
        public string district { get; set; }
        public string image { get; set; }
        public string isManager { get; set; }
        public string fiscalid { get; set; }
        public string shiftname { get; set; }
        public string shiftStart { get; set; }
        public string shiftEnd { get; set; }
        public string allowedLateIn { get; set; }
        public string allowedEarlyOut { get; set; }
        public string launchStart { get; set; }
        public string launchEnd { get; set; }
        public string shiftTypeId { get; set; }
        public string shiftID { get; set; }
        public string branch { get; set; }

        public string gradeID { get; set; }
        public string enrollDate { get; set; }
        public string designationname { get; set; }
        public string designationID { get; set; }
        public string departmentID { get; set; }
        public string departmentname { get; set; }
        public string subDepartmentID { get; set; }
        public string subDepartmentName { get; set; }
        public string jobType { get; set; }
        public string LeavedDate { get; set; }
        public string workingStatus { get; set; }
        public string workingDays { get; set; }
    }
    public class ListOutPut : CommonResponse
    {
        public string token { get; set; }
        public List<LoginViewModel> logins { get; set; }
    }
}
