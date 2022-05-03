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
    public class PostServices : IPostInterface
    {
        public async Task<CommonResponse> CreateNotification(Notification notifi)
        {
            CommonResponse response = new CommonResponse();
            response.StatusCode = 400;
            if (string.IsNullOrEmpty(notifi.ComID)) response.Message = "Input CompanyId";
            else
            {
                string sql = "sp_notification";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@comid", notifi.ComID);
                parameters.Add("@title", notifi.Title);
                parameters.Add("@description", notifi.Description);
                parameters.Add("@image", notifi.Image);
                parameters.Add("@publisheddate", notifi.PublishedDate);
                parameters.Add("@userid", notifi.UserID);
                parameters.Add("@acBtn", notifi.AcBtn);
                parameters.Add("@redurl", notifi.RedUrl);
                parameters.Add("@fiscalid", notifi.FiscalID);
                parameters.Add("@createdby", notifi.CreatedBy);
                parameters.Add("@flag", "CreateNotifi");
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                response.StatusCode = data.FirstOrDefault().StatusCode;
                response.Message = data.FirstOrDefault().Message;
                
            }
            return response;
        }

        public async Task<CommonResponse> ContactUpdate(UpdateContect contact)
        {
            var common = new CommonResponse();
           
                
                string sql = "sp_contect";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", contact.CompanyId);
                parameters.Add("@employeeid", contact.Employeeid);
                parameters.Add("@ID", contact.ContactId);


                parameters.Add("@firstname", contact.FirstName);
                parameters.Add("@middlename", contact.MiddleName);
                parameters.Add("@lastname", contact.LastName);
                parameters.Add("@email", contact.Email);
                parameters.Add("@website", contact.Website);
                parameters.Add("@phone", contact.Phone);
               
                parameters.Add("@jobtitle", contact.JobTitle);
                parameters.Add("@jobOrg", contact.JobOrg);
                parameters.Add("@address", contact.Address);
                parameters.Add("@district", contact.District);
                parameters.Add("@gender", contact.Gender);
                parameters.Add("@image", contact.Image);
                parameters.Add("@fb", contact.Fb);
                parameters.Add("@source", contact.Source);
                parameters.Add("@remarks", contact.Remarks);
                parameters.Add("@branchID", contact.Branch);
                parameters.Add("@fiscalID", contact.Fiscal);
                parameters.Add("@flag", "UpdateContact");
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);

                common.StatusCode = 200;
                common.Message = "Success";
                return common;
            
            
        }

        public async Task<CommonResponse> CreateCompany(OrgnizationGet orgnization)
        {
            CommonResponse res = new CommonResponse();
            res.StatusCode = 400;
            res.Message = "";
            if (string.IsNullOrEmpty(orgnization.ComID)) res.Message = "ComID is Empty";
            else if (orgnization.EmpID == 0) res.Message = "EmpID is Empty ";
            else if (string.IsNullOrEmpty(orgnization.Email)) res.Message = "Email is Empty";
            else if (orgnization.BranchID == 0) res.Message = "BranchID is Empty";
            else if (orgnization.FiscalID == 0) res.Message = "FiscalID is Empty";
            else
            {
                string sql = "sp_organization";

                var parameter = new DynamicParameters();
                parameter.Add("@companyid", orgnization.ComID);
                parameter.Add("@createdby", orgnization.EmpID);
                parameter.Add("@organizationname", orgnization.OrgName);
                parameter.Add("@organizationtype", orgnization.OrgType);
                parameter.Add("@address", orgnization.Address);
                parameter.Add("@district", orgnization.District);
                parameter.Add("@landline", orgnization.LandLine);
                parameter.Add("@phoneno", orgnization.Phone);
                parameter.Add("@cpersonname", orgnization.ContactPerson);
                parameter.Add("@cpersoncontact", orgnization.PersonContact);
                parameter.Add("@email", orgnization.Email);
                parameter.Add("@pan", orgnization.PAN);
                parameter.Add("@website", orgnization.Website);
                parameter.Add("@fb", orgnization.Fb);
                parameter.Add("@latitude", orgnization.Latitude);
                parameter.Add("@longitude", orgnization.Longitude);
                parameter.Add("@source", orgnization.Source);
                parameter.Add("@isourclient", orgnization.IsOurClient);
                parameter.Add("@currentsystem", orgnization.CurrentSystem);
                parameter.Add("@branchid", orgnization.BranchID);
                parameter.Add("@fiscalid", orgnization.FiscalID);
                parameter.Add("@AssignedTo", orgnization.AssignedTo);
                parameter.Add("@flag", "createorg");
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameter);
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;
            }
            return res;
        }

        public async Task<CommonResponse> CreateContact(Contact contact)
        {
            var common = new CommonResponse();
            string sql = "sp_contect";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyid",contact.CompanyId);
            parameters.Add("@employeeid",contact.EmployeeId);
            parameters.Add("@firstname",contact.FirstName);
            parameters.Add("@middlename",contact.MiddleName);
            parameters.Add("@lastname",contact.LastName);
            parameters.Add("@email",contact.Email);
            parameters.Add("@website",contact.Website);
            parameters.Add("@phone",contact.Phone);
            
            parameters.Add("@jobtitle",contact.JobTitle);
            parameters.Add("@jobOrg",contact.JobOrg);
            parameters.Add("@address",contact.Address);
            parameters.Add("@district",contact.District);
            parameters.Add("@gender",contact.Gender);
            parameters.Add("@image",contact.Image);
            parameters.Add("@fb",contact.Fb);
            parameters.Add("@source",contact.Source);
            parameters.Add("@remarks",contact.Remarks);
            parameters.Add("@branchID",contact.Branch);
            parameters.Add("@fiscalID",contact.Fiscal);
            parameters.Add("@flag", "Create");
            var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);

            common.StatusCode = 200;
            common.Message = "Success";
            return common;
        }

        public async Task<CommonResponse> CreateFollowUp(Followup followup)
        {
            var common = new CommonResponse();
            common.StatusCode = 400;
            if (string.IsNullOrEmpty(followup.ComID)) common.Message = "Input Companyid";
            else
            {
                string sql = "sp_followup";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", followup.ComID);
                parameters.Add("@createdby", followup.EmpID);
                parameters.Add("@organizationid", followup.OrganizationID);
                parameters.Add("@productid", followup.ProductID);
                parameters.Add("@followdate", followup.FollowDate);
                parameters.Add("@followtime", followup.FollowTime);
                parameters.Add("@assignedto", followup.AssignedTo);
                parameters.Add("@remarks", followup.Remarks);
                parameters.Add("@followstatus", followup.FollowStatus);
                parameters.Add("@followtype", followup.FollowType);
                parameters.Add("@branchid", followup.BranchID);
                parameters.Add("@fiscal_id", followup.FiscalID);
                parameters.Add("@flag", "createfollow");
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);

                common.StatusCode = data.FirstOrDefault().StatusCode;
                common.Message = data.FirstOrDefault().Message;
            }
            
            return common;
            
        }

        public async Task<CommonResponse> CreateLeads(Lead lead)
        {
            CommonResponse response=new CommonResponse();
            response.StatusCode = 400;
            if (string.IsNullOrEmpty(lead.ComID)) response.Message = "Input CompanyId";
            else if (lead.EmpID == 0) response.Message = "Input EmpID";
            else if (lead.OrgID == 0) response.Message = "Input OrgID";
            else if (lead.ProductID == 0) response.Message = "Input ProductID";
            else if (lead.BranchID == 0) response.Message = "Input BranchID";
            else if (lead.FiscalID == 0) response.Message = "Input FiscalID";
            else
            {
                string sql = "sp_leads";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyId", lead.ComID);
                parameters.Add("@EmpId", lead.EmpID);
                parameters.Add("@OrganizationId", lead.OrgID);
                parameters.Add("@ProductId", lead.ProductID);
                parameters.Add("@EnquiryDate", lead.EnquiryDate);
                parameters.Add("@EnquiryTime", lead.EnquiryTime);
                parameters.Add("@Assignedto", lead.AssignedTo);
                parameters.Add("@Remarks", lead.Remarks);
                parameters.Add("@LeadStatus", lead.LeadStatus);
                parameters.Add("@BranchId", lead.BranchID);
                parameters.Add("@FiscalId", lead.FiscalID);
                parameters.Add("@flag", "CreateLead");
                parameters.Add("@LeadSource", lead.LeadSource);
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                response.StatusCode = data.FirstOrDefault().StatusCode;
                response.Message = data.FirstOrDefault().Message;
            }
            return response;      
        }

        public async Task<CommonResponse> CustomerSupport(CustomerSupport customerSupport)
        {
            var data12 = new CommonResponse();
            string sql = "sp_customer_support";
            DynamicParameters parameters=new DynamicParameters();
            parameters.Add("@companyid",customerSupport.ComID);
            parameters.Add("@createdby",customerSupport.EmpID);
            parameters.Add("@organizationid",customerSupport.OrgID);
            parameters.Add("@productid",customerSupport.ProductID);
            parameters.Add("@issue",customerSupport.Issue);
            parameters.Add("@issuedate",customerSupport.IssueDate);
            parameters.Add("@starttime",customerSupport.StartTime);
            parameters.Add("@endtime",customerSupport.EndTime);
            parameters.Add("@attachment",customerSupport.Attachment);
            parameters.Add("@assignedto",customerSupport.AssignedTo);
            parameters.Add("@supportstatus",customerSupport.SupportStatus);
            parameters.Add("@supportmedium",customerSupport.SupportMedium);
            parameters.Add("@clientcomment",customerSupport.ClientComment);
            parameters.Add("@remarks",customerSupport.Remarks);
            parameters.Add("@branch",customerSupport.BranchID);
            parameters.Add("@fiscal",customerSupport.FiscalID);
            parameters.Add("@flag","Create");

            var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
            data12.Message = data.FirstOrDefault().Message;
            data12.StatusCode = data.FirstOrDefault().StatusCode;
            return data12;
        }
    }
}
