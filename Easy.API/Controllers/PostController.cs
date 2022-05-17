using Easy.Models.Models;
using Easy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Easy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("~/api/create-org")]
        public async Task<IActionResult> CreateOrganization(OrgnizationGet orgnization)
        {
            var data = await _unitOfWork.PostServices.CreateCompany(orgnization);
            return Ok(data);
        }
        [HttpPost]
        [Route("~/api/create-lead")]
        public async Task<IActionResult> CreateLead(Lead lead)
        {
            var data = await _unitOfWork.PostServices.CreateLeads(lead);
            return Ok(data);
        }
        [HttpPost]
        [Route("~/api/create-follow-up")]
        public async Task<IActionResult> CreateFollowOrg(Followup followup)
        {
            var data = await _unitOfWork.PostServices.CreateFollowUp(followup);
            return Ok(data);
        }
        [HttpPost]
        [Route("~/api/create-contact")]
        public async Task<IActionResult> CreateContact(ContactCreate contact)
        {
            var data = await _unitOfWork.PostServices.CreateContact(contact);
            return Ok(data);
        }
        [HttpPost]
        [Route("~/api/create-customer-support")]
        public async Task<IActionResult> CustomerSupport(CustomerSupport customerSupport)
        {
            var data = await _unitOfWork.PostServices.CustomerSupport(customerSupport);
            return Ok(data);
        }
        [HttpPost]
        [Route("~/api/update-contact")]
        public async Task<IActionResult> UpdateContact(UpdateContact contect)
        {
            var data = await _unitOfWork.PostServices.ContactUpdate(contect);
            return Ok(data);
        }
        [HttpPost]
        [Route("~/api/create-notification")]
        public async Task<IActionResult> CreateNotication(Notification notifi)
        {
            var data = await _unitOfWork.PostServices.CreateNotification(notifi);
            return Ok(data);
        }
        [HttpPost]
        [Route("~/api/create-leave")]
        public async Task<IActionResult> CreateLeave(Leave leave)
        {
            var data = await _unitOfWork.PostServices.CreateLeave(leave);
            return Ok(data);
        }
        [HttpPost]
        [Route("~/api/leave-status")]
        public async Task<IActionResult> UpdateLeaveStatus(UpdateLeaveStatus updateLeave)
        {
            var data = await _unitOfWork.PostServices.UpdateLeaveStatus(updateLeave.ComID, updateLeave.UserID, updateLeave.LeaveID, updateLeave.Status);
            return Ok(data);
        }
        [HttpPost]
        [Route("~/api/create-attendance")]
        public async Task<IActionResult> CreateAttendance(CreateAttendance attendance)
        {
            var data = await _unitOfWork.PostServices.CreateAttendance(attendance);
            return Ok(data);
        }
        [HttpPost]
        [Route("~/api/bulk-attendance")]
        public async Task<IActionResult> CreateBulkAttendance( BulkAttendance BulkAtten)
        {
            var data = await _unitOfWork.PostServices.CreateBulkAttendance(BulkAtten);
            return Ok(data);
        }
    }
}
