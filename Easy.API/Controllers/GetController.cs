using Easy.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Easy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("~/api/GetDoc")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetDoc(string ComId, int EmpId)
        {
            var data= await _unitOfWork.GetServices.listdoc(ComId, EmpId);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/org-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> OrgList(string CompanyId, int IsOurClient, int UserId)
        {
            var data= await _unitOfWork.GetServices.orglist(CompanyId, IsOurClient, UserId);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/all-org-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AllOrgList(string CompanyId, int EmployeeId, string FromDate, string ToDate, int IsOurClient)
        {
            var data= await _unitOfWork.GetServices.allorglist(CompanyId, EmployeeId,FromDate,ToDate,IsOurClient);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/follow-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Followuplist(string CompanyId, int EmployeeId, string FromDate, string ToDate, int OrgType, int FollowType, int FollowStatus)
        {
            var data= await _unitOfWork.GetServices.followuplist(CompanyId, EmployeeId,FromDate,ToDate,OrgType,FollowType,FollowStatus);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/org-type")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> OrgType(string CompanyId, int BranchId)
        {
            var data= await _unitOfWork.GetServices.orgtype(CompanyId, BranchId);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/follow-type")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> followuptype(string CompanyId, int BranchId)
        {
            var data= await _unitOfWork.GetServices.FollowupType(CompanyId, BranchId);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/lead-source")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> LeadSource(string CompanyId, int BranchId)
        {
            var data= await _unitOfWork.GetServices.leadSource(CompanyId, BranchId);
            return Ok(data);
        }

        [HttpGet]
        [Route("~/api/org-product")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> OrgProduct(string CompanyId, int BranchId)
        {
            var data = await _unitOfWork.GetServices.orgproduct(CompanyId, BranchId);
            return Ok(data);

        }

        [HttpGet]
        [Route("~/api/org-staff")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> OrgStaff(string CompanyId, string BranchId, int DepartmentId, int SubDepartmentId)
        {
            var data = await _unitOfWork.GetServices.orgstaff(CompanyId, BranchId,DepartmentId,SubDepartmentId);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/contact-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ContactList(string CompanyId, int EmployeeId)
        {
            var data = await _unitOfWork.GetServices.ContactInfo(CompanyId,EmployeeId);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/contact-info")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ContactInfo(string CompanyId, int EmployeeId)
        {
            var data = await _unitOfWork.GetServices.ContactList(CompanyId,EmployeeId);
            return Ok(data);

        }
        
    }
}
