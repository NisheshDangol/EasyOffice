﻿using Easy.Models.Models;
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
        Task<AllOrganizationDto> allorglist(string CompanyId, int EmployeeId, string FromDate, string ToDate);
        Task<OrganizationTypeDto> orgtype(string CompanyId,string BranchId);
        Task<OrganizationProductDto> orgproduct(string CompanyId,int BranchId);
        Task<OrgnizationStaffDto> orgstaff(string CompanyId,string BranchId,int DepartmentId,int SubDepartmentId);
    }
}
