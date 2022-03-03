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
    }
}
