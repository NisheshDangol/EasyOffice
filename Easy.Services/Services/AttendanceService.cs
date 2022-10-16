using Dapper;
using Easy.Connection;
using Easy.Connection.Dapper;
using Easy.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services.Services
{
    public class AttendanceService
    {
        public async Task<CommonResponse> UpdateDeviceCode(DeviceUserInfo req)
        {
            CommonResponse res = new CommonResponse();
            try
            {
                var sql = "sp_update_user_code";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@flag", "del");
                await DBHelper.RunProc<dynamic>(sql, parameters);
                foreach (var item in req.deviceinfo)
                {
                    parameters.Add("@flag", "update");
                    parameters.Add("@username", item.Name);
                    parameters.Add("@deviceid", item.EnrollmentNumber);
                    parameters.Add("@comid", req.ComID);
                    var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                }
                

            }
            catch (Exception ex)
            {
                res.StatusCode = 500;
                res.Message = ex.Message;
            }
            return res;
        }

        public async Task<CommonResponse> CreateBulkAttendance(BulkAttendance bulkatten)
        {
            try
            {
                CommonResponse res = new CommonResponse();
                string sql = "sp_bulkattenNew";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", bulkatten.Flag);
                parameters.Add("@comid", bulkatten.ComID);
                parameters.Add("@attenplace", bulkatten.AttenPlace);
                parameters.Add("@staffid", bulkatten.StaffID);
                parameters.Add("@fiscalid", bulkatten.FiscalID);
                parameters.Add("@branchid", bulkatten.BranchID);
                parameters.Add("@remark", bulkatten.Remarks);
                foreach (JSonParam jSon in bulkatten.Param)
                {
                    string month = "";
                    string day = "";
                    var attendate = NepaliDateConverter.DateConverter.ConvertToNepali(DateTime.Parse(jSon.AttenDate).Year, DateTime.Parse(jSon.AttenDate).Month, DateTime.Parse(jSon.AttenDate).Day);
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
                    parameters.Add("@deviceid", jSon.UserID);
                    parameters.Add("@attendate", jSon.AttenDate);
                    parameters.Add("@attendatenepali", attendate.Year + "/" + month + "/" + day);
                    parameters.Add("@attentime", jSon.AttenTime);
                    var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                }
                return res;
            }
            catch (Exception ex)
            {
                return new CommonResponse()
                {
                    StatusCode = 500,
                    Message = ex.Message
                };
            }

            //res.StatusCode = data.FirstOrDefault().StatusCode;
            //res.Message = data.FirstOrDefault().Message;
            //return res;           
        }

        public async Task<AttenAdminRes> AttendanceSummaryAdmin(AttenAdminReq req)
        {
            AttenAdminRes res = new AttenAdminRes();
            res.AttenRes = null;
            //var sql = "sp_admin_attendance";
            try
            {
                var sql = "sp_admin_attendance_summary";
                var parameters = new DynamicParameters();
                parameters.Add("@comid", req.ComID);
                parameters.Add("@flag", req.Flag);
                parameters.Add("@departmentid", req.DepartmentID);
                parameters.Add("@subdepartmentid", req.SubDepartmentID);
                parameters.Add("@value", req.Value);
                parameters.Add("@branchid", req.BranchID);
                parameters.Add("@fiscalid", req.FiscalID);
                parameters.Add("@dflag", req.DFlag);

                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    res.AttenRes = data.ToList();
                    res.StatusCode = 200;
                    res.Message = "Success";
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    res.StatusCode = data.FirstOrDefault().StatusCode;
                    res.Message = data.FirstOrDefault().Message;
                }
                else
                {
                    res.StatusCode = 400;
                    res.Message = "No Data";
                }
            }
            catch (Exception ex)
            {
                res.StatusCode = 500;
                res.Message = ex.Message;
            }
            return res;
        }


        public async Task<AttendanceReportMonth> AttendanceReport(string ComID, int UserID, string Flag, string Value, string From, string To, string DFlag)
        {
            var sql = "sp_attendance_report";
            var leaveRep = new AttendanceReportMonth();
            leaveRep.AttenRepMonth = null;
            leaveRep.StatusCode = 400;
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", Flag);
                parameters.Add("@comid", ComID);
                parameters.Add("@userid", UserID);
                parameters.Add("@value", Value);
                parameters.Add("@fromdate", From);
                parameters.Add("@todate", To);
                parameters.Add("@dflag", DFlag);

                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    leaveRep.StatusCode = 200;
                    leaveRep.Message = "Success";
                    leaveRep.AttenRepMonth = data.ToList();
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    leaveRep.StatusCode = data.FirstOrDefault().StatusCode;
                    leaveRep.Message = data.FirstOrDefault().Message;
                }
                else
                {
                    leaveRep.Message = "NO data";
                }
                return leaveRep;
            }
            catch(Exception ex)
            {
                leaveRep.StatusCode = 500;
                leaveRep.Message = ex.Message;
                return leaveRep;
            }
            
        }


        public async Task<AttendanceSummary> AttendanceSummary(string ComID, int UserID, string Flag, string Value, string DFlag)
        {
            var sql = "sp_attendance_summary";
            var leaveRep = new AttendanceSummary();
            leaveRep.AttenSummary = null;
            leaveRep.StatusCode = 400;
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@flag", Flag);
                parameters.Add("@comid", ComID);
                parameters.Add("@userid", UserID);
                parameters.Add("@values", Value);
                parameters.Add("@dflag", DFlag);

                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                if (data.Count() != 0 && data.FirstOrDefault().Message == null)
                {
                    leaveRep.StatusCode = 200;
                    leaveRep.Message = "Success";
                    leaveRep.AttenSummary = data.ToList();
                }
                else if (data.Count() == 1 && data.FirstOrDefault().Message != null)
                {
                    leaveRep.StatusCode = data.FirstOrDefault().StatusCode;
                    leaveRep.Message = data.FirstOrDefault().Message;
                }
                else
                {
                    leaveRep.Message = "NO data";
                }
            }
            catch(Exception ex)
            {
                leaveRep.StatusCode = 500;
                leaveRep.Message = ex.Message;
            }
            
            return leaveRep;
        }
    }
}
