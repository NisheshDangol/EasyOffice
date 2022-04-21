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
        [Route("~/api/doc-information")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetDoc(string ComID, int EmpID)
        {
            var data= await _unitOfWork.GetServices.listdoc(ComID, EmpID);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/org-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> OrgList(string ComID, int IsOurClient, int UserID)
        {
            var data= await _unitOfWork.GetServices.orglist(ComID, IsOurClient, UserID);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/all-org-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AllOrgList(string ComID, int EmpID, string FromDate, string ToDate, int IsOurClient)
        {
            var data= await _unitOfWork.GetServices.allorglist(ComID, EmpID,FromDate,ToDate,IsOurClient);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/follow-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Followuplist(string ComID, int EmpID, int IsOurClient, string FromDate, string ToDate, int OrgType, int FollowType, int FollowStatus, int ToType)
        {
            var data= await _unitOfWork.GetServices.followuplist(ComID, EmpID,IsOurClient,FromDate,ToDate,OrgType,FollowType,FollowStatus,ToType);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/org-type")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> OrgType(string ComID, int BranchID)
        {
            var data= await _unitOfWork.GetServices.orgtype(ComID, BranchID);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/follow-type")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> followuptype(string ComID, int BranchID)
        {
            var data= await _unitOfWork.GetServices.FollowupType(ComID, BranchID);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/lead-source")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> LeadSource(string ComID, int BranchID)
        {
            var data= await _unitOfWork.GetServices.leadSource(ComID, BranchID);
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
        [HttpGet]
        [Route("~/api/csupport-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CustomerSupport(string CompanyId, int EmployeeId, int Organizationid, int Supportstatus, string Supportmedium, string Fromdate, string Todate)
        {
            var data = await _unitOfWork.GetServices.CustomersupportList(CompanyId,EmployeeId,Organizationid,Supportstatus,Supportmedium,Fromdate,Todate);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/notification-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> NotificationList(string CompanyId, int EmployeeId)
        {
            var data = await _unitOfWork.GetServices.NotificationList(CompanyId,EmployeeId);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/csupport-info")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CustomerSupportInfo(string CompanyId, int EmployeeId, int CustomerSupportId)
        {
            var data = await _unitOfWork.GetServices.CustomerSupportInfo(CompanyId,EmployeeId,CustomerSupportId);
            return Ok(data);

        }
        
    }
}
