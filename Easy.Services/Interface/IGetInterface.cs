using Easy.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services.Interface
{
    public interface IGetInterface
    {
        Task<DocInfo> listdoc(string ComId,int EmpId);
        Task<OrganizationDto> orglist(string CompanyId, int IsOurClient, int UserId);
        Task<AllOrganizationDto> allorglist(string CompanyId, int EmployeeId, string FromDate, string ToDate, int IsOurClient);
        Task<OrganizationTypeDto> orgtype(string CompanyId,int BranchId);
        Task<OrganizationProductDto> orgproduct(string CompanyId,int BranchId);
        Task<LeadSourceDto> leadSource(string CompanyId,int BranchId);
        Task<FollowUpTypeDto> FollowupType(string CompanyId,int BranchId);
        Task<OrgnizationStaffDto> orgstaff(string CompanyId,string BranchId,int DepartmentId,int SubDepartmentId);
        Task<FollowupListDto> followuplist (string ComID, int EmpID, int IsOurClient, string FromDate, string ToDate, int OrgType, int FollowType, int FollowStatus, int ToType);
        Task<ContectInfoList> ContactInfo (string CompanyId, int EmployeeId);
        Task<ContactListDto> ContactList (string CompanyId, int EmployeeId);


        Task<NotificationListDto> NotificationList (string CompanyId, int EmployeeId);
        Task<CustomerSupportInfoDto> CustomerSupportInfo(string CompanyId, int EmployeeId, int CustomerSupportId);


        Task<CustomerSupportListDto> CustomersupportList(string CompanyId, int EmployeeId, int Organizationid, int Supportstatus, string Supportmedium, string Fromdate, string Todate);
    }
}
