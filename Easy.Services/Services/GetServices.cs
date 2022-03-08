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
        public async Task<AllOrganizationDto> allorglist(string CompanyId, string EmployeeId, DateTime fromDate, DateTime toDate)
        {
            var orglist = new AllOrganizationDto();
            orglist.StatusCode = 400;
            orglist.OrgList = null;

            if (string.IsNullOrEmpty(CompanyId)) orglist.Message = "Input CompanyId";
            else if (string.IsNullOrEmpty(EmployeeId)) orglist.Message = "Input EmployeeId";
            else
            {
                string sql = "sp_organization";
                DynamicParameters parameters=new DynamicParameters();
                parameters.Add("@companyid", CompanyId);
                parameters.Add("@createdby", EmployeeId);
                parameters.Add("@FromDate", fromDate);
                parameters.Add("@ToDate", toDate);
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
               
            }
            return orglist;

        }

        public async Task<DocInfo> listdoc(string ComId, int EmpId)
        {
            string sql = "sp_doc @ComId '" + ComId + "'";
            sql += ",@EmpId '" + EmpId + "'";
            var data= await DBHelper.RunProc<DocMain>(sql);
            if(data.Count()==0)
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
                    Message = "No data Found.",
                    StatusCode = 400
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
                if (data.Count() != 0)
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

        public async Task<OrganizationTypeDto> orgtype(string CompanyId, string BranchId)
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
                if (data.Count() != 0)
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
    }
}
