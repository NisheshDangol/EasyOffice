using Easy.Connection;
using Easy.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services.Interface
{
    public interface IAttendanceInterface
    {
        Task<CommonResponse> UpdateDeviceCode(DeviceUserInfo req);
        Task<CommonResponse> CreateBulkAttendance(BulkAttendance bulkatten);
        Task<AttenAdminRes> AttendanceSummaryAdmin(AttenAdminReq req);
        Task<AttendanceReportMonth> AttendanceReport(string ComID, int UserID, string Flag, string Value, string From, string To, string DFlag);
        Task<AttendanceSummary> AttendanceSummary(string ComID, int UserID, string Flag, string Value, string DFlag);
    }
}
