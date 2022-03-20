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
                parameters.Add("@contact", contact.Contact);
                parameters.Add("@jobtitle", contact.JobTitle);
                parameters.Add("@jobOrg", contact.JobOrg);
                parameters.Add("@dateOfBirth", contact.DateOfBirth);
                parameters.Add("@address", contact.Address);
                parameters.Add("@district", contact.District);
                parameters.Add("@gender", contact.Gender);
                parameters.Add("@pan", contact.Pan);
                parameters.Add("@maritalStatus", contact.MaritalStatus);
                parameters.Add("@bloodGroup", contact.BloodGroup);
                parameters.Add("@religion", contact.Religion);
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
            string sql = "sp_organization";
            
            var parameter = new DynamicParameters();
            parameter.Add("@companyid", orgnization.CompanyId);
            parameter.Add("@createdby", orgnization.EmployeId);
            parameter.Add("@organizationname", orgnization.OrganizationName);
            parameter.Add("@organizationtype", orgnization.OrganizationType);
            parameter.Add("@address", orgnization.Address);
            parameter.Add("@district", orgnization.District);
            parameter.Add("@landline", orgnization.LandLine);
            parameter.Add("@phoneno", orgnization.Phone);
            parameter.Add("@cpersonname", orgnization.ContactPerson);
            parameter.Add("@cpersoncontact", orgnization.PersonContact);
            parameter.Add("@email", orgnization.Email);
            parameter.Add("@pan", orgnization.Pan);
            parameter.Add("@website", orgnization.Website);
            parameter.Add("@fb", orgnization.Fb);
            parameter.Add("@latitude", orgnization.Latitude);
            parameter.Add("@longitude", orgnization.Longitude);
            parameter.Add("@source", orgnization.Source);
            parameter.Add("@isourclient", orgnization.IsOurClient);
            parameter.Add("@currentsystem", orgnization.CurrentSystem);
            parameter.Add("@branchid", orgnization.BranchId);
            parameter.Add("@fiscalid", orgnization.FiscalId);
            parameter.Add("@Assignedto", orgnization.AssignedTo);
            parameter.Add("@flag",1);
            var data= await DBHelper.RunProc<CommonResponse>(sql,parameter);
            return new CommonResponse
            {
                StatusCode = data.FirstOrDefault().StatusCode,
                Message = data.FirstOrDefault().Message
            };
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
            parameters.Add("@contact",contact.ContactName);
            parameters.Add("@jobtitle",contact.JobTitle);
            parameters.Add("@jobOrg",contact.JobOrg);
            parameters.Add("@dateOfBirth",contact.DateOfBirth);
            parameters.Add("@address",contact.Address);
            parameters.Add("@district",contact.District);
            parameters.Add("@gender",contact.Gender);
            parameters.Add("@pan",contact.Pan);
            parameters.Add("@maritalStatus",contact.MaritalStatus);
            parameters.Add("@bloodGroup",contact.BloodGroup);
            parameters.Add("@religion",contact.Religion);
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
            if (string.IsNullOrEmpty(followup.CompanyId)) common.Message = "Input Companyid";
            else
            {
                string sql = "sp_followup";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", followup.CompanyId);
                parameters.Add("@createdby", followup.CreatedBy);
                parameters.Add("@organizationid", followup.OrganizationId);
                parameters.Add("@productid", followup.ProductId);
                parameters.Add("@followdate", followup.FollowDate);
                parameters.Add("@followtime", followup.FollowTime);
                parameters.Add("@assignedto", followup.AssignedTo);
                parameters.Add("@remarks", followup.Remarks);
                parameters.Add("@followstatus", followup.FollowStatus);
                parameters.Add("@followtype", followup.FollowType);
                parameters.Add("@branchid", followup.BranchId);
                parameters.Add("@fiscal_id", followup.FiscalId);
                parameters.Add("@flag", 1);
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);

                common.StatusCode = 200;
                common.Message = "Success";
            }
            
            return common;
            
        }

        public async Task<CommonResponse> CreateLeads(Lead lead)
        {
            CommonResponse response=new CommonResponse();
            response.StatusCode = 400;
            if (string.IsNullOrEmpty(lead.CompanyId)) response.Message = "Input CompanyId";
            else
            {
                string sql = "sp_leads";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyId",lead.CompanyId);
                parameters.Add("@EmpId",lead.EmpId);
                parameters.Add("@OrganizationId",lead.OrganizationId);
                parameters.Add("@ProductId",lead.ProductId);
                parameters.Add("@EnquiryDate",lead.EnquiryDate);
                parameters.Add("@EnquiryTime",lead.EnquiryTime);
                parameters.Add("@Assignedto",lead.Assignedto);
                parameters.Add("@Remarks",lead.Remarks);
                parameters.Add("@LeadStatus",lead.LeadStatus);
                parameters.Add("@BranchId",lead.BranchId);
                parameters.Add("@FiscalId",lead.FiscalId);
                parameters.Add("@flag",1);
                parameters.Add("@LeadSource",lead.LeadSource);
                await DBHelper.RunProc<CommonResponse>(sql, parameters);
                response.StatusCode = 200;
                response.Message = "Success";
            }
            return response;
            
            
        }

        public async Task<CommonResponse> CustomerSupport(CustomerSupport customerSupport)
        {
            var data12 = new CommonResponse();
            string sql = "sp_customer_support";
            DynamicParameters parameters=new DynamicParameters();
            parameters.Add("@companyid",customerSupport.CompanyId);
            parameters.Add("@createdby",customerSupport.EmplopyeeId);
            parameters.Add("@organizationid",customerSupport.OrganizationId);
            parameters.Add("@productid",customerSupport.ProductId);
            parameters.Add("@issue",customerSupport.Issue);
            parameters.Add("@issuedate",customerSupport.IssueDate);
            parameters.Add("@starttime",customerSupport.StartTime);
            parameters.Add("@endtime",customerSupport.EndTime);
            parameters.Add("@attachment",customerSupport.Attachment);
            parameters.Add("@assignedto",customerSupport.AssignedTo);
            parameters.Add("@supportstatus",customerSupport.SupportStatus);
            parameters.Add("@supportmedium",customerSupport.SupportMedium);
            parameters.Add("@clientcomment",customerSupport.clientComment);
            parameters.Add("@remarks",customerSupport.Remarks);
            parameters.Add("@branch",customerSupport.BranchId);
            parameters.Add("@fiscal",customerSupport.FiscalId);
            parameters.Add("@flag","Create");

            var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
            data12.Message = data.FirstOrDefault().Message;
            data12.StatusCode = data.FirstOrDefault().StatusCode;
            return data12;
        }
    }
}
