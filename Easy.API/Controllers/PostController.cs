using Easy.Models.Models;
using Easy.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace Easy.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
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

        [HttpPost]
        [Route("~/api/admin/department")]
        public async Task<IActionResult> AdminDepartment(AdminDepartmentReq req)
        {
            var data = await _unitOfWork.PostServices.AdminDepartment(req);
            return Ok(data);

        }

        [HttpPost]
        [Route("~/api/admin/sub-department")]
        public async Task<IActionResult> SubDepartment(SubDepartmentReq req)
        {
            var data = await _unitOfWork.PostServices.SubDepartment(req);
            return Ok(data);

        }

        [HttpPost]
        [Route("~/api/admin/designation")]
        public async Task<IActionResult> Designation(DesignationReq req)
        {
            var data = await _unitOfWork.PostServices.Designation(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/product")]
        public async Task<IActionResult> Product(ProductReq req)
        {
            var data = await _unitOfWork.PostServices.ProductAdmin(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/shift")]
        public async Task<IActionResult> Shift(ShiftReq req)
        {
            var data = await _unitOfWork.PostServices.ShiftAdmin(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/user")]
        public async Task<IActionResult> User(UserReq req)
        {
            var data = await _unitOfWork.PostServices.UserAdmin(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/branch")]
        public async Task<IActionResult> Branch(BranchReq req)
        {
            var data = await _unitOfWork.PostServices.BranchAdmin(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/fiscal")]
        public async Task<IActionResult> Fiscal(FiscalYearReq req)
        {
            var data = await _unitOfWork.PostServices.FiscalAdmin(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/u-doc")]
        public async Task<IActionResult> Document(DocumentReq req)
        {
            var data = await _unitOfWork.PostServices.DocumentAdmin(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/u-bank")]
        public async Task<IActionResult> Bank(BankAdminReq req)
        {
            var data = await _unitOfWork.PostServices.BankAdmin(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/u-leave-type")]
        public async Task<IActionResult> LeaveType(LeaveTypeReq req)
        {
            var data = await _unitOfWork.PostServices.LeaveType(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/holiday")]
        public async Task<IActionResult> HolidayAdmin(HolidayReq req)
        {
            var data = await _unitOfWork.PostServices.HolidayAdmin(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/notification")]
        public async Task<IActionResult> NotificationAdmin(NotificationAdminReq req)
        {
            var data = await _unitOfWork.PostServices.NotificationAdmin(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/u-job-inf")]
        public async Task<IActionResult> JobInfoAdmin(JobInfoReq req)
        {
            var data = await _unitOfWork.PostServices.JobInfoAdmin(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/u-birthday")]
        public async Task<IActionResult> BirthdayAdmin(BirthdayReq req)
        {
            var data = await _unitOfWork.PostServices.Birthday(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/bulkbyxml")]
        public async Task<IActionResult> Bulk(BulkAttendance req)
        {
            var data = await _unitOfWork.PostServices.CreateBulkAttendanceXml(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/attendance")]
        public async Task<IActionResult> AdminAttendance(AttenAdminReq req)
        {
            var data = await _unitOfWork.PostServices.AttendanceAdmin(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/leave")]
        public async Task<IActionResult> AdminLeave(LeaveReq req)
        {
            var data = await _unitOfWork.PostServices.LeaveAdmin(req);
            return Ok(data);
        }
    }
}
