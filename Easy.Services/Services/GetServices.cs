using Dapper;
using Easy.Connection;
using Easy.Connection.Dapper;
using Easy.Models.Models;
using Easy.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services.Services
{
    public class GetServices : IGetInterface
    {
        public async Task<AllOrganizationDto> allorglist(string ComID, int UserID, string FromDate, string ToDate, int IsOurClient, int OrgType, int SourceID)
        {
            var orglist = new AllOrganizationDto();
            orglist.StatusCode = 400;
            orglist.OrgList = null;
            orglist.Message = "";
            if (string.IsNullOrEmpty(ComID)) orglist.Message = "CompanyId is empty";
            else if (UserID == 0) orglist.Message = "EmployeeId is empty";
            else if (string.IsNullOrEmpty(FromDate)) orglist.Message = "FormDate is empty";
            else if (string.IsNullOrEmpty(ToDate)) orglist.Message = "ToDate is empty";
            else
            {
                string sql = "sp_all_org_list";
                var parameters = new DynamicParameters();
                parameters.Add("@com_id", ComID);
                parameters.Add("@userid", UserID);
                parameters.Add("@FromDate", FromDate);
                parameters.Add("@ToDate", ToDate);
                parameters.Add("@isourclient", IsOurClient);
                parameters.Add("@orgtype", OrgType);
                parameters.Add("@sourceid", SourceID);
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 )//&& data.FirstOrDefault().Message == null)
                {
                    orglist.StatusCode = 200;
                    orglist.OrgList = data.ToList();
                    orglist.Message = "success";
                }
                else if (data.Count()==1 && data.FirstOrDefault().Message != null)
                {
                    orglist.StatusCode = data.FirstOrDefault().StatusCode;
                    orglist.OrgList = null;
                    orglist.Message = data.FirstOrDefault().Message;
                }
                else
                {
                    orglist.Message = "NO data";
                }

            }
            return orglist;

        }

        public async Task<ContactInfoList> ContactInfo(string CompanyId, int EmployeeId, int ContactID)
        {
            var contlist = new ContactInfoList();
            contlist.StatusCode = 400;
            contlist.ContactInfo = null;
            if(string.IsNullOrEmpty(CompanyId))
            {
                contlist.Message = "Input CompanyId";
            }
            else
            {
                string sql = "sp_contect";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@employeeid", EmployeeId);
                parameters.Add("@ID", ContactID);
                parameters.Add("@flag", "ContactInfo");
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    contlist.StatusCode = 200;
                    contlist.ContactInfo = data.ToList();
                    contlist.Message = "success";
                }
                else if(data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    contlist.StatusCode = data.FirstOrDefault().StatusCode;
                    contlist.Message = data.FirstOrDefault().Message;
                }
                else
                {
                    contlist.Message = "NO data";
                }
            }
            return contlist;
        }

        public async Task<FollowupListDto> followuplist(string ComID, int EmpID, int IsOurClient, string FromDate, string ToDate,int OrgType,int FollowType,int FollowStatus,int ToType)
        {
            var followuplist = new FollowupListDto();
            followuplist.StatusCode = 400;
            followuplist.FollowupLists = null;

            if (string.IsNullOrEmpty(ComID)) followuplist.Message = "Input CompanyId";

            else
            {
                string sql = "sp_followup";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", ComID);
                parameters.Add("@createdby", EmpID);
                parameters.Add("@isourclient", IsOurClient);
                parameters.Add("@fromDate", FromDate);
                parameters.Add("@toDate", ToDate);
                parameters.Add("@followstatus", FollowStatus);
                parameters.Add("@followtype", FollowType);
                parameters.Add("@OrgType", OrgType);
                parameters.Add("@totype", ToType);
                parameters.Add("@flag", "followList");
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().StatusCode == null)
                {
                    followuplist.StatusCode = 200;
                    followuplist.FollowupLists = data.ToList();
                    followuplist.Message = "success";
                }
                else if(data.Count() == 1 && data.FirstOrDefault().StatusCode != null)
                {
                    followuplist.Message = data.FirstOrDefault().Message;
                    followuplist.StatusCode = data.FirstOrDefault().StatusCode;
                    followuplist.FollowupLists = null;
                }
                else
                {
                    followuplist.Message = "no data";
                }
            }
            return followuplist;
        }

        public async Task<FollowUpTypeDto> FollowupType(string CompanyId, int BranchId)
        {
            var followtype = new FollowUpTypeDto();
            followtype.StatusCode = 400;
            followtype.FollowupType = null;

            if (string.IsNullOrEmpty(CompanyId)) followtype.Message = "Input CompanyId";
            else if (BranchId == 0) followtype.Message = "Input BranchId";
            else
            {
                string sql = "sp_followup";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@branchid", BranchId);
                parameters.Add("@flag", "followtype");
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().StatusCode == null)
                {
                    followtype.Message = "Success";
                    followtype.StatusCode = 200;
                    followtype.FollowupType = data.ToList();
                }
                else
                {
                    followtype.Message = "No Data Found.";
                    followtype.StatusCode = 400;
                    followtype.FollowupType = null;
                }
            }
            return followtype;
        }

        public async Task<LeadSourceDto> leadSource(string CompanyId, int BranchId)
        {
            var lead = new LeadSourceDto();
            lead.StatusCode = 400;
            lead.LeadSources = null;

            if (string.IsNullOrEmpty(CompanyId)) lead.Message = "Input CompanyId";
            else if (BranchId == 0) lead.Message = "Input BranchID";
            else
            {
                string sql = "sp_leads";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyId", CompanyId);
                parameters.Add("@branchid", BranchId);
                parameters.Add("@flag", "leadsource");
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().SourceId != 0)
                {
                    lead.Message = "Success";
                    lead.StatusCode = 200;
                    lead.LeadSources = data.ToList();
                }
                else
                {
                    lead.Message = data.FirstOrDefault().Message;
                    lead.StatusCode =202;
                    lead.LeadSources = null;
                }
            }
            return lead;
        }

        public async Task<DocInfo> listdoc(string ComId, int EmpId)
        {
            string sql = "sp_userinfo" ;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@ComId",  ComId);
            parameters.Add("@EmpId", EmpId);
            parameters.Add("@flag", "docinfo");
            var data= await DBHelper.RunProc<dynamic>(sql, parameters);
            if(data.Count()!=0 && data.FirstOrDefault().StatusCode == null)
            {
                return new DocInfo
                {
                    Docs = data.ToList(),
                    Message = "Success.",
                    StatusCode = 200
                };
            }
            else
            {
                return new DocInfo
                {
                    Docs = null,
                    Message = data.FirstOrDefault().Message,
                    StatusCode = data.FirstOrDefault().StatusCode
                };

            }

        }

        public async Task<OrganizationDto> orglist(string ComID, int IsOurClient, int UserID)
        {
            var org = new OrganizationDto();
            org.StatusCode = 400;
            org.OrgList = null;
            org.Message = "";

            if (string.IsNullOrEmpty(ComID)) org.Message = "Input CompanyId";
            else if (UserID == 0) org.Message = "UserID is Empty";
            else
            {
                string sql = "sp_organization";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@com_id", ComID);
                parameters.Add("@isourclient", IsOurClient);
                parameters.Add("@userid", UserID);
                parameters.Add("@flag", "orglist");
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().StatusCode == null)
                {
                    org.Message = "Success";
                    org.StatusCode = 200;
                    org.OrgList = data.ToList();
                }
                else
                {
                    org.Message = "No Data";
                    
                }
            }
            return org;
            
        }

        public async Task<OrganizationProductDto> orgproduct(string ComID, int BranchID)
        {
            var org = new OrganizationProductDto();
            org.StatusCode = 400;
            org.OrganizationProducts = null;

            if (string.IsNullOrEmpty(ComID)) org.Message = "Empty CompanyId";
            else if (BranchID == 0) org.Message = "Empty BranchID";
            else
            {
                string sql = "sp_organization";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@com_id", ComID);
                parameters.Add("@branchid", BranchID);
                parameters.Add("@flag", "orgproduct");
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().ProductId != 0)
                {
                    org.Message = "Success";
                    org.StatusCode = 200;
                    org.OrganizationProducts = data.ToList();
                }
                else
                {
                    org.Message = "No Data Found.";
                    org.StatusCode = 400;
                    org.OrganizationProducts = null;
                }
            }
            return org;
        }

        public async Task<OrgnizationStaffDto> orgstaff(string CompanyID, string BranchID, int DepartmentID, int SubDepartmentID)
        {
            var org = new OrgnizationStaffDto();
            org.StatusCode = 400;
            org.OrganizationStaffs = null;

            if (string.IsNullOrEmpty(CompanyID)) org.Message = "Input CompanyId";
            else if (string.IsNullOrEmpty(BranchID)) org.Message = "BranchId is Empty";
            else if (DepartmentID == 0) org.Message = "DepartmentId is Empty";
            else
            {
                string sql = "sp_organization";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@com_id", CompanyID);
                parameters.Add("@branchid", BranchID);
                parameters.Add("@DepartmentId", DepartmentID);
                parameters.Add("@SubDepartmentId", SubDepartmentID);
                parameters.Add("@flag", "orgstaff");
                var data = await DBHelper.RunProc<OrganizationStaff>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().StaffId != 0)
                {
                    org.Message = "Success";
                    org.StatusCode = 200;
                    org.OrganizationStaffs = data.ToList();
                }
                else
                {
                    org.Message = "No Data Found.";
                    org.StatusCode = 400;
                    org.OrganizationStaffs = null;
                }
            }
            return org;
        }

        public async Task<OrganizationTypeDto> orgtype(string CompanyId, int BranchId)
        {
            var org = new OrganizationTypeDto();
            org.StatusCode = 400;
            org.OrganizationTypes = null;

            if (string.IsNullOrEmpty(CompanyId)) org.Message = "Input CompanyId";
            else if (BranchId == 0) org.Message = "BranchId is Empty";
            else
            {
                string sql = "sp_organization";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@com_id", CompanyId);
                parameters.Add("@branchid", BranchId);
                parameters.Add("@flag", "orgtype");
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().OrgTypeID != 0)
                {
                    org.Message = "Success";
                    org.StatusCode = 200;
                    org.OrganizationTypes = data.ToList();
                }
                else
                {
                    org.Message = "No Data Found.";
                    org.StatusCode = 400;
                    org.OrganizationTypes = null;
                }
            }
            return org;
        }



        public async Task<ContactListDto> ContactList(string CompanyId, int EmployeeId)
        {
            var contlist = new ContactListDto();
            contlist.StatusCode = 400;
            contlist.ContactListInfo = null;
            if (string.IsNullOrEmpty(CompanyId))
            {
                contlist.Message = "Input com_id";
            }
            else
            {
                string sql = "sp_contect";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@employeeid", EmployeeId);
                parameters.Add("@flag", "ContactList");
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    contlist.StatusCode = 200;
                    contlist.ContactListInfo = data.ToList();
                    contlist.Message = "success";
                }
                else if (data.Count()==1 && data.FirstOrDefault().Message != null)
                {
                    contlist.StatusCode = data.FirstOrDefault().StatusCode;
                    contlist.Message = data.FirstOrDefault().Message;
                }
                else
                {
                    contlist.Message = "NO data";
                }
            }
            return contlist;
        }

        public async Task<CustomerSupportListDto> CustomersupportList(string CompanyId, int EmployeeId, int Organizationid, int Supportstatus, string Supportmedium, string Fromdate, string Todate)
        {
            var customersupport = new CustomerSupportListDto();
            customersupport.StatusCode = 400;
            customersupport.Customerlist = null;

            if (string.IsNullOrEmpty(CompanyId)) customersupport.Message = "Input CompanyId";
            else
            {
                string sql = "sp_customer_support";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@createdby", EmployeeId);
                parameters.Add("@organizationid", Organizationid);
                parameters.Add("@supportstatus", Supportstatus);
                parameters.Add("@supportmedium", Supportmedium);
                parameters.Add("@fromdate", Fromdate);
                //parameters.Add("@supportmedium", Supportmedium);
                parameters.Add("@todate", Todate);
                parameters.Add("@flag", "CustomerSupportList");
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    customersupport.Message = "Success";
                    customersupport.StatusCode = 200;
                    customersupport.Customerlist = data.ToList();
                }
                else if(data.Count() != 0 && data.FirstOrDefault().StatusCode != null)
                {
                    customersupport.Message = data.FirstOrDefault().Message;
                    customersupport.StatusCode = data.FirstOrDefault().StatusCode;
                    customersupport.Customerlist = null;
                }
                else
                {
                    customersupport.Message = "Nodata";
                    customersupport.StatusCode = 400;
                    customersupport.Customerlist = null;
                }
            }
            return customersupport;
        }

        public async Task<NotificationListDto> NotificationList(string CompanyId, int EmployeeId)
        {
            var notificationlist = new NotificationListDto();
            notificationlist.StatusCode = 400;
            notificationlist.NotificationList = null;

            if (string.IsNullOrEmpty(CompanyId)) notificationlist.Message = "Input CompanyId";
            else if (EmployeeId == 0) notificationlist.Message = "Input EmployeeId";
            else
            {
                string sql = "sp_notification";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@comid", CompanyId);
                parameters.Add("@empID", EmployeeId);
                parameters.Add("@flag", "NotificationList");
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    notificationlist.Message = "Success";
                    notificationlist.StatusCode = 200;
                    notificationlist.NotificationList = data.ToList();
                }
                else if (data.Count() != 0 && data.FirstOrDefault().Message != null)
                {
                    notificationlist.Message = data.FirstOrDefault().Message;
                    notificationlist.StatusCode = data.FirstOrDefault().StatusCode;
                    notificationlist.NotificationList = null;
                }
                else
                {
                    notificationlist.Message = "No Data Found.";
                    notificationlist.StatusCode = 400;
                    notificationlist.NotificationList = null;
                }
            }
            return notificationlist;
        }

        public async Task<CustomerSupportInfoDto> CustomerSupportInfo(string CompanyId, int EmployeeId, int CustomerSupportId)
        {
            var customersupport = new CustomerSupportInfoDto();
            customersupport.StatusCode = 400;
            customersupport.CustomerSupportInfo = null;

            if (string.IsNullOrEmpty(CompanyId)) customersupport.Message = "Input CompanyId";
            else
            {
                string sql = "sp_customer_support";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@createdby", EmployeeId);
                parameters.Add("@id", CustomerSupportId);
                parameters.Add("@flag", "CustomerSupportInfo");
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().StatusCode == null)
                {
                    customersupport.Message = "Success";
                    customersupport.StatusCode = 200;
                    customersupport.CustomerSupportInfo = data.ToList();
                }
                else if (data.Count() != 0 && data.FirstOrDefault().StatusCode != null)
                {
                    customersupport.Message = data.FirstOrDefault().Message;
                    customersupport.StatusCode = data.FirstOrDefault().StatusCode;
                    customersupport.CustomerSupportInfo = null;
                }
                else
                {
                    customersupport.Message = "No Data Found.";
                    customersupport.StatusCode = 400;
                    customersupport.CustomerSupportInfo = null;
                }
            }
            return customersupport;
        }


        public async Task<LeaveTypeList> LeaveType(string ComID, int BranchID)
        {
            var typelist = new LeaveTypeList();
            var sql = "sp_leave";
            var parameters = new DynamicParameters();
            parameters.Add("@flag","leavetype");
            parameters.Add("@ComID", ComID);
            parameters.Add("@BranchID", BranchID);
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if (data.Count() != 0)
            {
                typelist.StatusCode = 200;
                typelist.Message = "Success";
                typelist.LeaveList = data.ToList();
            }
            else
            {
                typelist.StatusCode = 400;
                typelist.Message = "No data";
                typelist.LeaveList = null;
            }
            return typelist;
        }

        public async Task<UserLeaveType> UserLeaveType(string ComID, int UserID)
        {
            var userleavetype = new UserLeaveType();
            var sql = "sp_leave";
            var parameters = new DynamicParameters();
            parameters.Add("@flag", "userleavetype");
            parameters.Add("@ComID", ComID);
            parameters.Add("@UserID", UserID);
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if(data.Count() != 0 && data.FirstOrDefault().Message == null)
            {
                userleavetype.LeaveType = data.ToList();
                userleavetype.Message = "Success";
                userleavetype.StatusCode = 200;
            }
            else if(data.Count()==1 && data.FirstOrDefault().Message != null)
            {
                userleavetype.LeaveType = null;
                userleavetype.Message = data.FirstOrDefault().Message;
                userleavetype.StatusCode = data.FirstOrDefault().StatusCode;
            }
            else
            {
                userleavetype.LeaveType = null;
                userleavetype.Message = "No Data";
                userleavetype.StatusCode = 400;
            }
            return userleavetype;
        }

        public async Task<LeaveReport> LeaveReport(string ComID, int UserID, int LeaveTypeID)
        {
            var leave_rep = new LeaveReport();
            var sql = "sp_leave";
            var parameters = new DynamicParameters();
            parameters.Add("@flag", "leavereport");
            parameters.Add("@ComID", ComID);
            parameters.Add("@UserID", UserID);
            parameters.Add("@LeaveTypeID", LeaveTypeID);
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if(data.Count()!=0 && data.FirstOrDefault().Message == null)
            {
                leave_rep.LeaveReports = data.ToList();
                leave_rep.StatusCode = 200;
                leave_rep.Message = "Success";
            }
            else if(data.Count()==1 && data.FirstOrDefault().Message != null)
            {
                leave_rep.Message= data.FirstOrDefault().Message;
                leave_rep.StatusCode= data.FirstOrDefault().StatusCode;
                leave_rep.LeaveReports = null;
            }
            else
            {
                leave_rep.LeaveReports = null;
                leave_rep.StatusCode = 400;
                leave_rep.Message = "No Data";
            }
            return leave_rep;
        }

        public async Task<AttendanceReportMonth> AttendanceReport(string ComID, int UserID, string Flag, string Value, string From, string To, string DFlag)
        {
            var sql = "sp_attendance";
            var leaveRep = new AttendanceReportMonth();
            leaveRep.AttenRepMonth = null;
            leaveRep.StatusCode = 400;
            var parameters = new DynamicParameters();
            parameters.Add("@flag", "attendancereport");
            parameters.Add("@comid", ComID);
            parameters.Add("@userid", UserID);
            parameters.Add("@repflag", Flag);
            parameters.Add("@value", Value);
            parameters.Add("@fromdate", From);
            parameters.Add("@todate", To);
            parameters.Add("@dflag", DFlag);

            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if(data.Count()!=0 && data.FirstOrDefault().Message == null)
            {
                leaveRep.StatusCode = 200;
                leaveRep.Message = "Success";
                leaveRep.AttenRepMonth = data.ToList();
            }
            else if(data.Count()==1 && data.FirstOrDefault().Message != null)
            {
                leaveRep.StatusCode = data.FirstOrDefault().StatusCode;
                leaveRep.Message = data.FirstOrDefault().Message;
            }
            else
            {
                leaveRep.Message = "NO data";
            }
            return leaveRep;
        }

        public async Task<AttendanceSummary> AttendanceSummary(string ComID, int UserID, string Flag, string Value,string DFlag)
        {
            var sql = "sp_attendance";
            var leaveRep = new AttendanceSummary();
            leaveRep.AttenSummary = null;
            leaveRep.StatusCode = 400;
            var parameters = new DynamicParameters();
            parameters.Add("@flag", "attendancesummary");
            parameters.Add("@comid", ComID);
            parameters.Add("@userid", UserID);
            parameters.Add("@repflag", Flag);
            parameters.Add("@value", Value);
            parameters.Add("@dflag", DFlag);            
                        
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if (data.Count() != 0 && data.FirstOrDefault().Message == null)
            {
                leaveRep.StatusCode = 200;
                leaveRep.Message = "Success";
                leaveRep.AttenSummary = data.ToList();
            }
            else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
            {
                leaveRep.StatusCode = data.FirstOrDefault().StatusCode;
                leaveRep.Message = data.FirstOrDefault().Message;
            }
            else
            {
                leaveRep.Message = "NO data";
            }
            return leaveRep;
        }

        public async Task<Holiday> GetHoliday(string ComID, int BranchID)
        {
            var sql = "sp_holiday";
            var res = new Holiday();
            var parameters = new DynamicParameters();
            parameters.Add("@comid", ComID);
            parameters.Add("@branchid", BranchID);
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if(data.Count()!=0 && data.FirstOrDefault().Message == null)
            {
                res.StatusCode = 200;
                res.Message = "Success";
                res.Holidays = data.ToList();
            }
            else if(data.Count() == 1 && data.FirstOrDefault().Message != null)
            {
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;
                res.Holidays = data.ToList();
            }
            else
            {
                res.StatusCode = 400;
                res.Message = "No Data";
                res.Holidays = null;
            }
            return res;
        }
    }
    
}
