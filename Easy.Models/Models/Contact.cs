using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Contact
    {
        public string CompanyId { get; set; }
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string ContactName { get; set; }
        public string JobTitle { get; set; }
        public string JobOrg { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int District { get; set; }
        public int Gender { get; set; }
        public string Pan { get; set; }
        public int MaritalStatus { get; set; }
        public int BloodGroup { get; set; }
        public int Religion { get; set; }
        public string Image { get; set; }
        public string Fb { get; set; }
        public string Source { get; set; }
        public string Remarks { get; set; }
        public int Branch { get; set; }
        public int Fiscal { get; set; }
    }
    public class ContactInfo
    {
        public string ContactId { get; set; }
        public string FullName { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
    }
    public class ContectInfoList:CommonResponse
    {
        public List<ContactInfo> ContactInfo { get; set; }
    }
    public class ContactList
    {
        public string CompanyId { get; set; }
        public string Employeeid { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        public string JobTitle { get; set; }
        public string JobOrg { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Gender { get; set; }
        public string Pan { get; set; }
        public string MaritalStatus { get; set; }
        public string BloodGroup { get; set; }
        public string Religion { get; set; }
        public string Image { get; set; }
        public string Fb { get; set; }
        public string Source { get; set; }
        public string Remarks { get; set; }
    }
    public class ContactListDto:CommonResponse
    {
        public List<ContactList> ContactListInfo { get; set; }
    }

    public class UpdateContect
    {
        public string CompanyId { get; set; }
        public int Employeeid { get; set; }


        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        public string JobTitle { get; set; }
        public string JobOrg { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public int District { get; set; }
        public int Gender { get; set; }
        public string Pan { get; set; }
        public int MaritalStatus { get; set; }
        public int BloodGroup { get; set; }
        public int Religion { get; set; }
        public string Image { get; set; }
        public string Fb { get; set; }
        public string Source { get; set; }
        public string Remarks { get; set; }
        public int Branch { get; set; }
        public int Fiscal { get; set; }
        public int ContactId { get; set; }
    }
}
