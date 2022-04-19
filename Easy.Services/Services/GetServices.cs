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
        public async Task<AllOrganizationDto> allorglist(string CompanyId, int EmployeeId, string FromDate, string ToDate,int IsOurClient)
        {
            var orglist = new AllOrganizationDto();
            orglist.StatusCode = 400;
            orglist.OrgList = null;
                string sql = "sp_organization";
                DynamicParameters parameters=new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@createdby", EmployeeId);
                parameters.Add("@FromDate", FromDate);
                parameters.Add("@ToDate", ToDate);
                parameters.Add("@isourclient", IsOurClient);
                parameters.Add("@flag", 3);
                var data = await DBHelper.RunProc<AllOrganizationList>(sql,parameters);
               if(data.Count()!=0)
                {
                    orglist.StatusCode = 200;
                    orglist.OrgList = data.ToList();
                    orglist.Message = "success";
                }
               else
                {
                    orglist.Message = "NO data";
                }
               
            
            return orglist;

        }

        public async Task<ContectInfoList> ContactInfo(string CompanyId, int EmployeeId)
        {
            var contlist = new ContectInfoList();
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
                parameters.Add("@flag", "ContactList");
                var data = await DBHelper.RunProc<ContactInfo>(sql, parameters);
                if (data.Count() != 0)
                {
                    contlist.StatusCode = 200;
                    contlist.ContactInfo = data.ToList();
                    contlist.Message = "success";
                }
                else
                {
                    contlist.Message = "NO data";
                }
            }
            


            return contlist;
        }

        public async Task<FollowupListDto> followuplist(string CompanyId, int EmployeeId, string FromDate, string ToDate,int OrgType,int FollowType,int FollowStatus)
        {
            var followuplist = new FollowupListDto();
            followuplist.StatusCode = 400;
            followuplist.FollowupLists = null;

            if (string.IsNullOrEmpty(CompanyId)) followuplist.Message = "Input CompanyId";

            else
            {
                string sql = "sp_followup";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@createdby", EmployeeId);
                parameters.Add("@fromDate", FromDate);
                parameters.Add("@toDate", ToDate);
                parameters.Add("@followstatus", FollowStatus);
                parameters.Add("@followtype", FollowType);
                parameters.Add("@OrgType", OrgType);
                parameters.Add("@flag", 2);
                var data = await DBHelper.RunProc<FollowupList>(sql, parameters);
                if (data.Count() != 0)
                {
                    followuplist.StatusCode = 200;
                    followuplist.FollowupLists = data.ToList();
                    followuplist.Message = "success";
                }
                else
                {
                    followuplist.Message = "NO data";
                }

            }
            return followuplist;
        }

        public async Task<FollowUpTypeDto> FollowupType(string CompanyId, int BranchId)
        {
            var followtype = new FollowUpTypeDto();
            followtype.StatusCode = 400;
            followtype.Followuptype = null;

            if (string.IsNullOrEmpty(CompanyId)) followtype.Message = "Input CompanyId";
            else
            {
                string sql = "sp_followup";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@branchid", BranchId);
                parameters.Add("@flag", 3);
                var data = await DBHelper.RunProc<Followuptype>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().FollowTypeID != 0)
                {
                    followtype.Message = "Success";
                    followtype.StatusCode = 200;
                    followtype.Followuptype = data.ToList();
                }
                else
                {
                    followtype.Message = "No Data Found.";
                    followtype.StatusCode = 400;
                    followtype.Followuptype = null;
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
            else
            {
                string sql = "sp_leads";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@branchid", BranchId);
                parameters.Add("@flag", 2);
                var data = await DBHelper.RunProc<LeadSource>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().SourceId != 0)
                {
                    lead.Message = "Success";
                    lead.StatusCode = 200;
                    lead.LeadSources = data.ToList();
                }
                else
                {
                    lead.Message = "No Data Found.";
                    lead.StatusCode = 400;
                    lead.LeadSources = null;
                }
            }
            return lead;
        }

        public async Task<DocInfo> listdoc(string ComId, int EmpId)
        {
            string sql = "sp_doc @ComId= '" + ComId + "'";
            sql += ",@EmpId='" + EmpId + "'";
            var data= await DBHelper.RunProc<dynamic>(sql);
            if(data.Count()!=0)
            {
                return new DocInfo
                {
                    docs = data.ToList(),
                    Message = "Success.",
                    StatusCode = 200
                };
            }
            else
            {
                return new DocInfo
                {
                    docs = null,
                    Message = data.FirstOrDefault().Message,
                    StatusCode = data.FirstOrDefault().StatusCode
                };

            }

        }

        public async Task<OrganizationDto> orglist(string CompanyId, int IsOurClient, int UserId)
        {
            var org = new OrganizationDto();
            org.StatusCode = 400;
            org.OrgList = null;
            
            if (string.IsNullOrEmpty(CompanyId)) org.Message = "Input CompanyId";
            else
            {
                string sql = "sp_organization";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@isourclient", IsOurClient);
                parameters.Add("@userid", UserId);
                parameters.Add("@flag", 2);
                var data = await DBHelper.RunProc<OrganizationList>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().OrgId!=0)
                {
                    org.Message = "Success";
                    org.StatusCode = 200;
                    org.OrgList = data.ToList();
                }
                else
                {
                    org.Message = "No Data Found.";
                    org.StatusCode = 400;
                    org.OrgList = null;
                }
            }
            return org;
            
        }

        public async Task<OrganizationProductDto> orgproduct(string CompanyId, int BranchId)
        {
            var org = new OrganizationProductDto();
            org.StatusCode = 400;
            org.OrganizationProducts = null;

            if (string.IsNullOrEmpty(CompanyId)) org.Message = "Input CompanyId";
            else
            {
                string sql = "sp_organization";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@branchid", BranchId);
                parameters.Add("@flag", 4);
                var data = await DBHelper.RunProc<OrganizationProduct>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().ProductId !=0)
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

        public async Task<OrgnizationStaffDto> orgstaff(string CompanyId, string BranchId, int DepartmentId, int SubDepartmentId)
        {
            var org = new OrgnizationStaffDto();
            org.StatusCode = 400;
            org.OrganizationStaffs = null;

            if (string.IsNullOrEmpty(CompanyId)) org.Message = "Input CompanyId";
            else
            {
                string sql = "sp_organization";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@branchid", BranchId);
                parameters.Add("@DepartmentId", DepartmentId);
                parameters.Add("@SubDepartmentId", SubDepartmentId);
                parameters.Add("@flag", 5);
                var data = await DBHelper.RunProc<OrganizationStaff>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().StaffId!=0)
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
            org.organizationTypes = null;

            if (string.IsNullOrEmpty(CompanyId)) org.Message = "Input CompanyId";
            else
            {
                string sql = "sp_organization";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@branchid", BranchId);
                parameters.Add("@flag", 6);
                var data = await DBHelper.RunProc<OrganizationType>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().OrgTypeID!=0)
                {
                    org.Message = "Success";
                    org.StatusCode = 200;
                    org.organizationTypes = data.ToList();
                }
                else
                {
                    org.Message = "No Data Found.";
                    org.StatusCode = 400;
                    org.organizationTypes = null;
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
                contlist.Message = "Input CompanyId";
            }
            else
            {
                string sql = "sp_contect";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@employeeid", EmployeeId);
                parameters.Add("@flag", "ContactInfo");
                var data = await DBHelper.RunProc<ContactList>(sql, parameters);
                if (data.Count() != 0)
                {
                    contlist.StatusCode = 200;
                    contlist.ContactListInfo = data.ToList();
                    contlist.Message = "success";
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
            customersupport.customerlist = null;

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
                parameters.Add("@supportmedium", Supportmedium);
                parameters.Add("@todate", Todate);
                parameters.Add("@flag", "CustomerSupportList");
                var data = await DBHelper.RunProc<CustomerSupportList>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().CustomerSupportId != 0)
                {
                    customersupport.Message = "Success";
                    customersupport.StatusCode = 200;
                    customersupport.customerlist = data.ToList();
                }
                else
                {
                    customersupport.Message = "No Data Found.";
                    customersupport.StatusCode = 400;
                    customersupport.customerlist = null;
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
            else
            {
                string sql = "sp_notification";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@comid", CompanyId);
                parameters.Add("@empID", EmployeeId);
                parameters.Add("@flag", "NotificationList");
                var data = await DBHelper.RunProc<NotificationList>(sql, parameters);
                if (data.Count() != 0 && !String.IsNullOrEmpty(data.FirstOrDefault().Title))
                {
                    notificationlist.Message = "Success";
                    notificationlist.StatusCode = 200;
                    notificationlist.NotificationList = data.ToList();
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
                var data = await DBHelper.RunProc<CustomerSupportInfo>(sql, parameters);
                if (data.Count() != 0)
                {
                    customersupport.Message = "Success";
                    customersupport.StatusCode = 200;
                    customersupport.CustomerSupportInfo = data.ToList();
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
    }
    
}
