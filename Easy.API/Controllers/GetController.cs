﻿using Easy.Services;
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
        public async Task<IActionResult> AllOrgList(string ComID, int EmpID, string FromDate, string ToDate, int IsOurClient,int OrgType, int SourceID)
        {
            var data= await _unitOfWork.GetServices.allorglist(ComID, EmpID,FromDate,ToDate,IsOurClient,OrgType,SourceID);
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
        public async Task<IActionResult> ContactList(string ComID, int EmpID)
        {
            var data = await _unitOfWork.GetServices.ContactInfo(ComID, EmpID);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/contact-info")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> ContactInfo(string ComID, int EmpID)
        {
            var data = await _unitOfWork.GetServices.ContactList(ComID,EmpID);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/csupport-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CustomerSupport(string ComID, int EmpID, int OrgID, int SupportStatus, string SupportMedium, string FromDate, string ToDate)
        {
            var data = await _unitOfWork.GetServices.CustomersupportList(ComID,EmpID,OrgID,SupportStatus,SupportMedium,FromDate,ToDate);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/notification-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> NotificationList(string ComID, int EmpID)
        {
            var data = await _unitOfWork.GetServices.NotificationList(ComID,EmpID);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/csupport-info")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CustomerSupportInfo(string ComID, int EmpID, int CustomerSupportID)
        {
            var data = await _unitOfWork.GetServices.CustomerSupportInfo(ComID,EmpID,CustomerSupportID);
            return Ok(data);

        }
        
    }
}
