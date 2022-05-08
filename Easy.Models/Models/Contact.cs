using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class ContactCreate
    {
        public string ComID { get; set; }
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        public string JobTitle { get; set; }
        public string JobOrg { get; set; }
        public string Address { get; set; }
        public int District { get; set; }
        public int Gender { get; set; }        
        public string Image { get; set; }
        public string Fb { get; set; }
        public string Source { get; set; }
        public string Remarks { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
    }
    //public class ContactInfo
    //{
    //    public string ContactId { get; set; }
    //    public string FullName { get; set; }
    //    public string Email { get; set; }
    //    public string Address { get; set; }
    //    public string District { get; set; }
    //}
    public class ContactInfoList:CommonResponse
    {
        public List<dynamic> ContactInfo { get; set; }
    }
    //public class ContactList
    //{
    //    public string CompanyId { get; set; }
    //    public string Employeeid { get; set; }
    //    public string FirstName { get; set; }
    //    public string MiddleName { get; set; }
    //    public string LastName { get; set; }
    //    public string Email { get; set; }
    //    public string Website { get; set; }
    //    public string Phone { get; set; }
    //    public string JobTitle { get; set; }
    //    public string JobOrg { get; set; }
    //    public string Address { get; set; }
    //    public string District { get; set; }
    //    public string Gender { get; set; }
    //    public string Image { get; set; }
    //    public string Fb { get; set; }
    //    public string Source { get; set; }
    //    public string Remarks { get; set; }
    //}
    public class ContactListDto:CommonResponse
    {
        public List<dynamic> ContactListInfo { get; set; }
    }

    public class UpdateContact
    {
        public string ComID { get; set; }
        public int UserID { get; set; }
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        public string Contact { get; set; }
        public string JobTitle { get; set; }
        public string JobOrg { get; set; }
        public string Address { get; set; }
        public int District { get; set; }
        public int Gender { get; set; }
        public string Image { get; set; }
        public string Fb { get; set; }
        public string Source { get; set; }
        public string Remarks { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
    }
}
