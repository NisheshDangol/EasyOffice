using Easy.Models.Models;
using Easy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EasyOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendanceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("~/api/admin/update-devicecode")]
        public async Task<IActionResult> UpdateDeviceCode(DeviceUserInfo req)
        {
            var data = await _unitOfWork.attendanceService.UpdateDeviceCode(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/newbulkatten")]
        public async Task<IActionResult> BulkAttendance(BulkAttendance req)
        {
            var data = await _unitOfWork.attendanceService.CreateBulkAttendance(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/atten-summary")]
        public async Task<IActionResult> AttendanceSummaryAdmin(AttenAdminReq req)
        {
            var data = await _unitOfWork.attendanceService.AttendanceSummaryAdmin(req);
            return Ok(data);
        }

        [HttpGet]
        [Route("~/api/attendance-report")]
        public async Task<IActionResult> AttendanceReport(string ComID, int UserID, string Flag, string Value, string From, string To, string DFlag)
        {
            var data = await _unitOfWork.attendanceService.AttendanceReport(ComID,UserID,Flag,Value,From,To,DFlag);
            return Ok(data);
        }

        [HttpGet]
        [Route("~/api/atten-summary")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AttendanceSummary(string ComID, int UserID, string Flag, string Values, string DFlag)
        {
            var data = await _unitOfWork.attendanceService.AttendanceSummary(ComID, UserID, Flag, Values, DFlag);
            return Ok(data);
        }
    }
}
