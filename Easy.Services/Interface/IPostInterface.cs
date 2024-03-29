﻿using Easy.Connection;
using Easy.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services.Interface
{
    public interface IPostInterface
    {
        Task<CommonResponse> CreateCompany(OrgnizationGet orgnization);
        Task<CommonResponse> CreateLeads(Lead lead);
        Task<CommonResponse> CreateFollowUp(Followup followup);
        Task<CommonResponse> CreateContact(ContactCreate contact);
        Task<CommonResponse> CustomerSupport(CustomerSupport customerSupport);
        Task<CommonResponse> ContactUpdate(UpdateContact contact);
        Task<CommonResponse> CreateNotification(Notification notifi);
        Task<CommonResponse> CreateLeave(Leave leave);
        Task<CommonResponse> UpdateLeaveStatus(string ComID, int UserID, int LeaveID, int Status);
        Task<CommonResponse> CreateAttendance(CreateAttendance attendance);
        Task<AdminDepartmentRes> AdminDepartment(AdminDepartmentReq req);
        Task<SubDepartment> SubDepartment(SubDepartmentReq req);
        Task<Designation> Designation(DesignationReq req);
        Task<Shift> ShiftAdmin(ShiftReq req);
        Task<User> UserAdmin(UserReq req);
        Task<Branch> BranchAdmin(BranchReq req);
        Task<FiscalYear> FiscalAdmin(FiscalYearReq req);
        Task<DocumentRes> DocumentAdmin(DocumentReq req);
        Task<BankAdminRes> BankAdmin(BankAdminReq req);
        Task<LeaveType> LeaveType(LeaveTypeReq req);
        Task<Holiday> HolidayAdmin(HolidayReq req);
        Task<NotificationListDto> NotificationAdmin(NotificationAdminReq req);
        Task<JobInfoAdmin> JobInfoAdmin(JobInfoReq req);
        Task<Birthday> Birthday(BirthdayReq req);
        Task<AttenAdminRes> AttendanceAdmin(AttenAdminReq req);
        Task<LeaveReport> LeaveAdmin(LeaveReq req);
        Task<FollowTypeAdminRes> AdminFollowType(FollowTypeAdmin req);
        Task<AdminLeadSourceRes> AdminLead(AdminLeadSource req);
        Task<LeadRes> LeadsReport(Leads req);
        Task<LeadRes> LeadsSummary(Leads req);
        Task<LeadRes> LeadList(LeadList req);
        Task<JobReturn> JobAdmin(JobReq req);
        Task<CommonResponse> Complain(Complain req);
    }
}
