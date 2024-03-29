﻿using Easy.Services;
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
        public async Task<IActionResult> Followuplist(string ComID, int UserID, int AssignedTo, string FromDate, string ToDate, int ProductID, int FollowTypeID, int FollowStatus, int ClientID)
        {
            var data= await _unitOfWork.GetServices.followuplist(ComID, UserID, AssignedTo, FromDate,ToDate, ProductID, FollowTypeID, FollowStatus, ClientID);
            return Ok(data);

        }

        [HttpGet]
        [Route("~/api/re-follow-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Refollowup(string ComID, int UserID, int AssignedTo, int FollowID)
        {
            var data = await _unitOfWork.GetServices.Refollowup(ComID, UserID, AssignedTo, FollowID);
            return Ok(data);

        }

        [HttpGet]
        [Route("~/api/client-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ClientList(string ComID, int UserID, int AssignedTo)
        {
            var data = await _unitOfWork.GetServices.ClientList(ComID, UserID, AssignedTo);
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
        [Route("~/api/oldattendance-report")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AttendanceReport(string ComID, int UserID, string Flag, string Value, string From, string To, string DFlag)
        {
            var data = await _unitOfWork.GetServices.AttendanceReport(ComID, UserID, Flag, Value,From,To, DFlag);
            return Ok(data);
        }

        [HttpGet]
        [Route("~/api/old-atten-summary")]
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

        [HttpGet]
        [Route("~/api/job")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Job(string ComID, string Flag, int JobStatus, int JobID)
        {
            var data = await _unitOfWork.GetServices.Job(ComID, Flag, JobStatus, JobID);
            return Ok(data);
        }

        [HttpGet]
        [Route("~/api/date-converter")]
        public async Task<IActionResult> DateConvert(string Date, string Flag)
        {
            string data = "";
            if (Flag.ToUpper() == "E")
            {
                string month = "";
                string day = "";
                var attendate = NepaliDateConverter.DateConverter.ConvertToNepali(DateTime.Parse(Date).Year, DateTime.Parse(Date).Month, DateTime.Parse(Date).Day);
                if (attendate.Month < 10)
                {
                    month = "0" + attendate.Month;
                }
                else month = "" + attendate.Month;
                if (attendate.Day < 10)
                {
                    day = "0" + attendate.Day;
                }
                else day = "" + attendate.Day;
                data = attendate.Year + "/" + month + "/" + day;
            }
            if (Flag.ToUpper() == "N")
            {
                string month = Date.Substring(0, 3);
                string day = "";

                var attendate = NepaliDateConverter.DateConverter.ConvertToEnglish(Int32.Parse( Date.Substring(0,4)), Int32.Parse(Date.Substring(5,2)), Int32.Parse(Date.Substring(8,2)));
                if (attendate.Month < 10)
                {
                    month = "0" + attendate.Month;
                }
                else month = "" + attendate.Month;
                if (attendate.Day < 10)
                {
                    day = "0" + attendate.Day;
                }
                else day = "" + attendate.Day;
                data = attendate.Year + "-" + month + "-" + day;
            }
            return Ok(data);
        }
    }
}
