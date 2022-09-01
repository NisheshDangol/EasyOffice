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
        Task<AllOrganizationDto> allorglist(string ComID, int UserID, string FromDate, string ToDate, int IsOurClient, int OrgType, int SourceID);
        Task<OrganizationTypeDto> orgtype(string CompanyId,int BranchId);
        Task<OrganizationProductDto> orgproduct(string CompanyId,int BranchId);
        Task<LeadSourceDto> leadSource(string CompanyId,int BranchId);
        Task<FollowUpTypeDto> FollowupType(string CompanyId,int BranchId);
        Task<OrgnizationStaffDto> orgstaff(string CompanyId,string BranchId,int DepartmentId,int SubDepartmentId);
        Task<FollowupListDto> followuplist (string ComID, int EmpID, int IsOurClient, string FromDate, string ToDate, int OrgType, int FollowType, int FollowStatus, int ToType);
        Task<ContactInfoList> ContactInfo (string CompanyId, int EmployeeId, int ContactID);
        Task<ContactListDto> ContactList (string CompanyId, int EmployeeId);
        Task<NotificationListDto> NotificationList (string CompanyId, int EmployeeId);
        Task<CustomerSupportInfoDto> CustomerSupportInfo(string CompanyId, int EmployeeId, int CustomerSupportId);
        Task<UserLeaveType> UserLeaveType(string ComID, int UserID);
        Task<LeaveTypeList> LeaveType(string ComID, int BranchID);
        Task<CustomerSupportListDto> CustomersupportList(string CompanyId, int EmployeeId, int Organizationid, int Supportstatus, int ProductID, string Supportmedium, string Fromdate, string Todate);
        Task<LeaveReport> LeaveReport(string ComID, int UserID, int LeaveTypeID);
        Task<AttendanceReportMonth> AttendanceReport(string ComID, int UserID, string Flag, string Value, string From, string To, string DFlag);
        Task<AttendanceSummary> AttendanceSummary(string ComID, int UserID, string Flag, string Value, string DFlag);
        Task<Holiday> GetHoliday(string ComID, int BranchID);
        Task<FiscalYear> FiscalYear(string ComID, int BranchID);
        Task<UserActivity> UserActivity(int UserID, string ComID, int FiscalID, int BranchID);
        Task<Master> Dropdowns(string ComID, int BranchID, int DepartID, int SubDepartID);
        Task<JobReturn> Job(string ComID, string Flag, int JobStatus, int JobID);
    }
}
