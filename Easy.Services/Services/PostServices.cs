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
            parameter.Add("@flag",1);
            var data= await DBHelper.RunProc<CommonResponse>(sql,parameter);
            return new CommonResponse
            {
                StatusCode = data.FirstOrDefault().StatusCode,
                Message = data.FirstOrDefault().Message
            };
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
                parameters.Add("@CompanyId", lead.CompanyId);
                parameters.Add("@EmpId", lead.EmpId);
                parameters.Add("@OrganizationId", lead.OrganizationId);
                parameters.Add("@ProductId", lead.ProductId);
                parameters.Add("@EnquiryDate", lead.EnquiryDate);
                parameters.Add("@EnquiryTime", lead.EnquiryTime);
                parameters.Add("@Assignedto", lead.Assignedto);
                parameters.Add("@Remarks", lead.Remarks);
                parameters.Add("@LeadStatus", lead.LeadStatus);
                parameters.Add("@BranchId", lead.BranchId);
                parameters.Add("@FiscalId", lead.FiscalId);
                parameters.Add("@flag",1);
                await DBHelper.RunProc<CommonResponse>(sql, parameters);
                response.StatusCode = 200;
                response.Message = "Success";
            }
            return response;
            
            
        }
    }
}
