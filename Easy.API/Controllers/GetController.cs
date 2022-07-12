using Easy.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Easy.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
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
        public async Task<IActionResult> GetDoc(string ComID, int UserID)
        {
            var data= await _unitOfWork.GetServices.listdoc(ComID, UserID);
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
        public async Task<IActionResult> AllOrgList(string ComID, int UserID, string FromDate, string ToDate, int IsOurClient,int OrgType, int SourceID)
        {
            var data= await _unitOfWork.GetServices.allorglist(ComID, UserID, FromDate,ToDate,IsOurClient,OrgType,SourceID);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/follow-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Followuplist(string ComID, int UserID, int IsOurClient, string FromDate, string ToDate, int OrgType, int FollowType, int FollowStatus, int ToType)
        {
            var data= await _unitOfWork.GetServices.followuplist(ComID, UserID,IsOurClient,FromDate,ToDate,OrgType,FollowType,FollowStatus,ToType);
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
        public async Task<IActionResult> OrgProduct(string ComID, int BranchID)
        {
            var data = await _unitOfWork.GetServices.orgproduct(ComID, BranchID);
            return Ok(data);

        }

        [HttpGet]
        [Route("~/api/org-staff")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> OrgStaff(string ComID, string BranchID, int DepartmentID, int SubDepartmentID)
        {
            var data = await _unitOfWork.GetServices.orgstaff(ComID, BranchID,DepartmentID,SubDepartmentID);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/contact-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ContactList(string ComID, int UserID)
        {
            var data = await _unitOfWork.GetServices.ContactList(ComID, UserID);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/contact-info")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ContactInfo(string ComID, int UserID, int ContactID)
        {
            var data = await _unitOfWork.GetServices.ContactInfo(ComID,UserID,ContactID);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/csupport-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CustomerSupport(string ComID, int UserID, int OrgID, int SupportStatus,int ProductID, string SupportMedium, string FromDate, string ToDate)
        {
            var data = await _unitOfWork.GetServices.CustomersupportList(ComID,UserID,OrgID,SupportStatus, ProductID,SupportMedium, FromDate,ToDate);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/notification-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> NotificationList(string ComID, int UserID)
        {
            var data = await _unitOfWork.GetServices.NotificationList(ComID,UserID);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/csupport-info")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CustomerSupportInfo(string ComID, int UserID, int CustomerSupportID)
        {
            var data = await _unitOfWork.GetServices.CustomerSupportInfo(ComID,UserID,CustomerSupportID);
            return Ok(data);

        }

        [HttpGet]
        [Route("~/api/leave-type")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetLeaveType(string ComID, int BranchID)
        {
            var data = await _unitOfWork.GetServices.LeaveType(ComID,BranchID);
            return Ok(data);
        }

        [HttpGet]
        [Route("~/api/user-leave-type")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UserLeaveType(string ComID, int UserID)
        {
            var data = await _unitOfWork.GetServices.UserLeaveType(ComID,UserID);
            return Ok(data);
        }

        [HttpGet]
        [Route("~/api/leave-report")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> LeaveReport(string ComID, int UserID, int LeaveTypeID)
        {
            var data = await _unitOfWork.GetServices.LeaveReport(ComID, UserID, LeaveTypeID);
            return Ok(data);
        }

        [HttpGet]
        [Route("~/api/attendance-report")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AttendanceReport(string ComID, int UserID, string Flag, string Value, string From, string To, string DFlag)
        {
            var data = await _unitOfWork.GetServices.AttendanceReport(ComID, UserID, Flag, Value,From,To, DFlag);
            return Ok(data);
        }

        [HttpGet]
        [Route("~/api/atten-summary")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AttendanceSummary(string ComID, int UserID, string Flag,string Values, string DFlag)
        {
            var data = await _unitOfWork.GetServices.AttendanceSummary(ComID, UserID, Flag, Values, DFlag);
            return Ok(data);
        }

        [HttpGet]
        [Route("~/api/holiday")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Holiday(string ComID, int BranchID)
        {
            var data = await _unitOfWork.GetServices.GetHoliday(ComID, BranchID);
            return Ok(data);
        }

        [HttpGet]
        [Route("~/api/fiscal-year")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> FiscalYear(string ComID, int BranchID)
        {
            var data = await _unitOfWork.GetServices.FiscalYear(ComID, BranchID);
            return Ok(data);
        }

        [HttpGet]
        [Route("~/api/user-activity")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> UserActivity(string ComID,int UserID,int FiscalID, int BranchID)
        {
            var data = await _unitOfWork.GetServices.UserActivity(UserID,ComID,FiscalID, BranchID);
            return Ok(data);
        }

        [HttpGet]
        [Route("~/api/master")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Dropdown(string ComID, int BranchID, int DepartID, int SubDepartID)
        {
            var data = await _unitOfWork.GetServices.Dropdowns(ComID, BranchID,DepartID,SubDepartID);
            return Ok(data);
        }
    }
}
