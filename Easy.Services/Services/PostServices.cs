using Dapper;
using Easy.Connection;
using Easy.Connection.Dapper;
using Easy.Models.Models;
using Easy.Services.Interface;
using MailKit.Net.Smtp;
using MimeKit;
using Models.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Dapper.SqlMapper;

namespace Easy.Services.Services
{
    public class PostServices : IPostInterface
    {
        private readonly SmtpSettings _settings;
        public PostServices(SmtpSettings smtpSettings)
        {
            _settings = smtpSettings;
        }

        public async Task<CommonResponse> CreateNotification(Notification notifi)
        {
            CommonResponse response = new CommonResponse();
            response.StatusCode = 400;
            if (string.IsNullOrEmpty(notifi.ComID)) response.Message = "Input CompanyId";
            else
            {
                string sql = "sp_notification";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@comid", notifi.ComID);
                parameters.Add("@title", notifi.Title);
                parameters.Add("@description", notifi.Description);
                parameters.Add("@image", notifi.Image);
                parameters.Add("@publisheddate", notifi.PublishedDate);
                parameters.Add("@userid", notifi.UserID);
                parameters.Add("@acBtn", notifi.AcBtn);
                parameters.Add("@redurl", notifi.RedUrl);
                parameters.Add("@fiscalid", notifi.FiscalID);
                parameters.Add("@createdby", notifi.CreatedBy);
                parameters.Add("@flag", "CreateNotifi");
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                response.StatusCode = data.FirstOrDefault().StatusCode;
                response.Message = data.FirstOrDefault().Message;

            }
            return response;
        }

        public async Task<CommonResponse> ContactUpdate(UpdateContact contact)
        {
            var common = new CommonResponse();

            string sql = "sp_contect";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyid", contact.ComID);
            parameters.Add("@employeeid", contact.UserID);
            parameters.Add("@ID", contact.ContactID);
            parameters.Add("@firstname", contact.FirstName);
            parameters.Add("@middlename", contact.MiddleName);
            parameters.Add("@lastname", contact.LastName);
            parameters.Add("@email", contact.Email);
            parameters.Add("@website", contact.Website);
            parameters.Add("@phone", contact.Phone);
            parameters.Add("@jobtitle", contact.JobTitle);
            parameters.Add("@jobOrg", contact.JobOrg);
            parameters.Add("@address", contact.Address);
            parameters.Add("@district", contact.District);
            parameters.Add("@gender", contact.Gender);
            if (!string.IsNullOrEmpty(contact.Image))
            {
                var imageUrl = Convert.FromBase64String(contact.Image);
                Image image = Image.FromStream(new MemoryStream(imageUrl));
                var imagename = DateTime.Now.Ticks;
                image.Save("Images/Contacts/" + imagename + ".jpg", ImageFormat.Jpeg);
                parameters.Add("@image", imagename + ".jpg");
            }
            parameters.Add("@fb", contact.Fb);
            parameters.Add("@source", contact.Source);
            parameters.Add("@remarks", contact.Remarks);
            parameters.Add("@branchID", contact.BranchID);
            parameters.Add("@fiscalID", contact.FiscalID);
            parameters.Add("@flag", "UpdateContact");
            var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);

            common.StatusCode = data.FirstOrDefault().StatusCode;
            common.Message = data.FirstOrDefault().Message;
            return common;


        }

        public async Task<CommonResponse> CreateCompany(OrgnizationGet orgnization)
        {
            CommonResponse res = new CommonResponse();
            res.StatusCode = 400;
            res.Message = "";
            if (string.IsNullOrEmpty(orgnization.ComID)) res.Message = "ComID is Empty";
            else if (orgnization.UserID == 0) res.Message = "EmpID is Empty ";
            else if (orgnization.BranchID == 0) res.Message = "BranchID is Empty";
            else if (orgnization.FiscalID == 0) res.Message = "FiscalID is Empty";
            else
            {
                string sql = "sp_organization";

                var parameter = new DynamicParameters();
                parameter.Add("@com_id", orgnization.ComID);
                parameter.Add("@createdby", orgnization.UserID);
                parameter.Add("@organizationname", orgnization.OrgName);
                parameter.Add("@organizationtype", orgnization.OrgType);
                parameter.Add("@address", orgnization.Address);
                parameter.Add("@district", orgnization.District);
                parameter.Add("@landline", orgnization.LandLine);
                parameter.Add("@phoneno", orgnization.Phone);
                parameter.Add("@cpersonname", orgnization.ContactPerson);
                parameter.Add("@cpersoncontact", orgnization.PersonContact);
                parameter.Add("@email", orgnization.Email);
                parameter.Add("@pan", orgnization.PAN);
                parameter.Add("@website", orgnization.Website);
                parameter.Add("@fb", orgnization.Fb);
                parameter.Add("@latitude", orgnization.Latitude);
                parameter.Add("@longitude", orgnization.Longitude);
                parameter.Add("@source", orgnization.Source);
                parameter.Add("@isourclient", orgnization.IsOurClient);
                parameter.Add("@currentsystem", orgnization.CurrentSystem);
                parameter.Add("@branchid", orgnization.BranchID);
                parameter.Add("@fiscalid", orgnization.FiscalID);
                parameter.Add("@AssignedTo", orgnization.StaffID);
                parameter.Add("@flag", "createorg");
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameter);
                res.StatusCode = data.FirstOrDefault().StatusCode;
                res.Message = data.FirstOrDefault().Message;
            }
            return res;
        }

        public async Task<CommonResponse> CreateContact(ContactCreate contact)
        {
            var common = new CommonResponse();
            string sql = "sp_contect";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyid", contact.ComID);
            parameters.Add("@employeeid", contact.UserID);
            parameters.Add("@firstname", contact.FirstName);
            parameters.Add("@middlename", contact.MiddleName);
            parameters.Add("@lastname", contact.LastName);
            parameters.Add("@email", contact.Email);
            parameters.Add("@website", contact.Website);
            parameters.Add("@phone", contact.Phone);
            parameters.Add("@jobtitle", contact.JobTitle);
            parameters.Add("@jobOrg", contact.JobOrg);
            parameters.Add("@address", contact.Address);
            parameters.Add("@district", contact.District);
            parameters.Add("@gender", contact.Gender);
            if (!string.IsNullOrEmpty(contact.Image))
            {
                var imageUrl = Convert.FromBase64String(contact.Image);
                Image image = Image.FromStream(new MemoryStream(imageUrl));
                var imgname = DateTime.Now.Ticks;
                image.Save("Images/Contacts/" + imgname + ".jpg", ImageFormat.Jpeg);

                parameters.Add("@image", imgname + ".jpg");
            }
            parameters.Add("@fb", contact.Fb);
            parameters.Add("@source", contact.Source);
            parameters.Add("@remarks", contact.Remarks);
            parameters.Add("@branchID", contact.BranchID);
            parameters.Add("@fiscalID", contact.FiscalID);
            parameters.Add("@flag", "Create");
            var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);

            common.StatusCode = data.FirstOrDefault().StatusCode;
            common.Message = data.FirstOrDefault().Message;

            return common;
        }

        public async Task<CommonResponse> CreateFollowUp(Followup followup)
        {
            var common = new CommonResponse();
            common.StatusCode = 400;
            if (string.IsNullOrEmpty(followup.ComID)) common.Message = "Input Companyid";
            else
            {
                string sql = "sp_followup";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@companyid", followup.ComID);
                parameters.Add("@createdby", followup.UserID);
                parameters.Add("@organizationid", followup.ContactID);
                parameters.Add("@totype", followup.ToType);
                parameters.Add("@productid", followup.ProductID);
                parameters.Add("@followdate", followup.FollowDate);
                parameters.Add("@followtime", followup.FollowTime);
                parameters.Add("@assignedto", followup.StaffID);
                parameters.Add("@remarks", followup.Remarks);
                parameters.Add("@followstatus", followup.FollowStatus);
                parameters.Add("@followtype", followup.FollowType);
                parameters.Add("@branchid", followup.BranchID);
                parameters.Add("@fiscal_id", followup.FiscalID);
                parameters.Add("@flag", "createfollow");
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);

                common.StatusCode = data.FirstOrDefault().StatusCode;
                common.Message = data.FirstOrDefault().Message;
            }

            return common;

        }

        public async Task<CommonResponse> CreateLeads(Lead lead)
        {
            CommonResponse response = new CommonResponse();
            response.StatusCode = 400;
            if (string.IsNullOrEmpty(lead.ComID)) response.Message = "Input CompanyId";
            else if (lead.UserID == 0) response.Message = "Input EmpID";
            else if (lead.OrgID == 0) response.Message = "Input OrgID";
            else if (lead.ProductID == 0) response.Message = "Input ProductID";
            else if (lead.BranchID == 0) response.Message = "Input BranchID";
            else if (lead.FiscalID == 0) response.Message = "Input FiscalID";
            else
            {
                string sql = "sp_leads";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CompanyId", lead.ComID);
                parameters.Add("@EmpId", lead.UserID);
                parameters.Add("@OrganizationId", lead.OrgID);
                parameters.Add("@ProductId", lead.ProductID);
                parameters.Add("@EnquiryDate", lead.EnquiryDate);
                parameters.Add("@EnquiryTime", lead.EnquiryTime);
                parameters.Add("@Assignedto", lead.StaffID);
                parameters.Add("@Remarks", lead.Remarks);
                parameters.Add("@LeadStatus", lead.LeadStatus);
                parameters.Add("@BranchId", lead.BranchID);
                parameters.Add("@FiscalId", lead.FiscalID);
                parameters.Add("@flag", "CreateLead");
                parameters.Add("@LeadSource", lead.LeadSource);
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                response.StatusCode = data.FirstOrDefault().StatusCode;
                response.Message = data.FirstOrDefault().Message;
            }
            return response;
        }

        public async Task<CommonResponse> CustomerSupport(CustomerSupport customerSupport)
        {
            var data12 = new CommonResponse();
            string sql = "sp_customer_support";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@companyid", customerSupport.ComID);
            parameters.Add("@createdby", customerSupport.UserID);
            parameters.Add("@organizationid", customerSupport.OrgID);
            parameters.Add("@productid", customerSupport.ProductID);
            parameters.Add("@issue", customerSupport.Issue);
            parameters.Add("@issuedate", customerSupport.IssueDate);
            parameters.Add("@starttime", customerSupport.StartTime);
            parameters.Add("@endtime", customerSupport.EndTime);
            if (customerSupport.Attachment != null && customerSupport.Attachment.Count() != 0
                && !string.IsNullOrEmpty(customerSupport.Attachment.FirstOrDefault().AttachmentUrl))
            {
                parameters.Add("@attach", 0);
            }
            parameters.Add("@assignedto", customerSupport.StaffID);
            parameters.Add("@supportstatus", customerSupport.SupportStatus);
            parameters.Add("@supportmedium", customerSupport.SupportMedium);
            parameters.Add("@clientcomment", customerSupport.ClientComment);
            parameters.Add("@remarks", customerSupport.Remarks);
            parameters.Add("@branch", customerSupport.BranchID);
            parameters.Add("@fiscal", customerSupport.FiscalID);
            parameters.Add("@flag", "Create");
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            data12.Message = data.FirstOrDefault().Message;
            data12.StatusCode = data.FirstOrDefault().StatusCode;

            if (customerSupport.Attachment != null && customerSupport.Attachment.Count() != 0
                && !string.IsNullOrEmpty(customerSupport.Attachment.FirstOrDefault().AttachmentUrl))
            {
                foreach (var imagedate in customerSupport.Attachment)
                {

                    var imageUrl = Convert.FromBase64String(imagedate.AttachmentUrl);
                    Image image = Image.FromStream(new MemoryStream(imageUrl));
                    var ImageName = DateTime.Now.Ticks;
                    image.Save("Images/CustomerSupport/" + ImageName + ".jpg", ImageFormat.Jpeg);
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@attachment", data.FirstOrDefault().AttachmentUnique);
                    param.Add("@attachmenturl", ImageName + ".jpg");
                    param.Add("@customersuppid", data.FirstOrDefault().CustomerSuppID);
                    param.Add("@flag", "addattachment");
                    await DBHelper.RunProc<dynamic>(sql, param);
                }
            }
            return data12;
        }

        public async Task<CommonResponse> CreateLeave(Leave leave)
        {
            var res = new CommonResponse();
            res.Message = "";
            res.StatusCode = 400;
            var sql = "sp_leave";
            var parameters = new DynamicParameters();
            parameters.Add("@flag", "createleave");
            parameters.Add("@ComID", leave.ComID);
            parameters.Add("@UserID", leave.UserID);
            parameters.Add("@LeaveTypeID", leave.LeaveTypeID);
            parameters.Add("@DayTypeID", leave.DayTypeID);
            parameters.Add("@Title", leave.Title);
            parameters.Add("@Cause", leave.Cause);
            parameters.Add("@FromDate", leave.FromDate);
            parameters.Add("@ToDate", leave.ToDate);
            parameters.Add("@IsFieldWork", leave.IsFieldWork);
            parameters.Add("@LeaveAssignedTo", leave.LeaveAssignedTo);
            parameters.Add("@FiscalID", leave.FiscalID);
            parameters.Add("@BranchID", leave.BranchID);
            parameters.Add("@Notifi", leave.Notify);
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            res.Message = data.FirstOrDefault().Message;
            res.StatusCode = data.FirstOrDefault().StatusCode;
            if (data.FirstOrDefault().email != null)
            {
                var message = new MimeMessage();
                message.From.Add(MailboxAddress.Parse(_settings.SenderEmail));
                message.To.Add(MailboxAddress.Parse(data.FirstOrDefault().email));
                message.Subject = "LEAVE";
                message.Body = new TextPart("plain")
                {
                    Text = "Leave Email"
                };
                var client = new SmtpClient();

                try
                {
                    client.Connect(_settings.Server, _settings.Port, true);
                    client.Authenticate(new NetworkCredential(_settings.SenderEmail, _settings.Password));
                    client.Send(message);
                    client.Disconnect(true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    client.Dispose();
                }
            }
            return res;
        }

        public async Task<CommonResponse> UpdateLeaveStatus(string ComID, int UserID, int LeaveID, int Status)
        {
            string sql = "sp_leave";
            var parameters = new DynamicParameters();
            parameters.Add("@flag", "updateleavestatus");
            parameters.Add("@ComID", ComID);
            parameters.Add("@UserID", UserID);
            parameters.Add("@LeaveID", LeaveID);
            parameters.Add("@status", Status);
            var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
            var res = new CommonResponse();
            res.Message = data.FirstOrDefault().Message;
            res.StatusCode = data.FirstOrDefault().StatusCode;
            return res;
        }

        public async Task<CommonResponse> CreateAttendance(CreateAttendance attendance)
        {
            string sql = "sp_attendance";
            var parameters = new DynamicParameters();
            parameters.Add("@flag", "createattendance");
            parameters.Add("@comid", attendance.ComID);
            parameters.Add("@userid", attendance.UserID);
            parameters.Add("@departmentid", attendance.DepartmentID);
            parameters.Add("@subdepartmentid", attendance.SubDepartmentID);
            parameters.Add("@designationid", attendance.DesignationID);
            var attendate = NepaliDateConverter.DateConverter.ConvertToNepali(DateTime.Parse(attendance.AttenDate).Year, DateTime.Parse(attendance.AttenDate).Month, DateTime.Parse(attendance.AttenDate).Day);
            parameters.Add("@attendate", attendance.AttenDate);
            string month = "";
            string day = "";
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

            parameters.Add("@attendatenepali", attendate.Year + "/" + month + "/" + day);
            parameters.Add("@attentime", attendance.AttenTime);
            parameters.Add("@attenstatus", attendance.AttenStatus);
            parameters.Add("@attenplace", attendance.AttenPlace);
            parameters.Add("@attenvia", attendance.AttenVia);
            parameters.Add("@fiscalid", attendance.FiscalID);
            parameters.Add("@branchid", attendance.BrachID);
            var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
            return new CommonResponse()
            {
                StatusCode = data.FirstOrDefault().StatusCode,
                Message = data.FirstOrDefault().Message
            };
        }

        public async Task<CommonResponse> CreateBulkAttendance(BulkAttendance bulkatten)
        {
            try
            {
                var param = bulkatten.Param;
                CommonResponse res = new CommonResponse();
                List<dynamic> data = new List<dynamic>();
                //string jsonstring = JsonConvert.SerializeObject(bulkatten.Param);
                //XmlNode xmlNode = JsonConvert.DeserializeXmlNode(jsonstring);
                string sql = "sp_bulkattenxml";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "createattendance");
                parameters.Add("@comid", bulkatten.ComID);
                //parameters.Add("@attenstatus", attendance.AttenStatus);
                parameters.Add("@attenplace", bulkatten.AttenPlace);
                parameters.Add("@staffid", bulkatten.StaffID);
                parameters.Add("@fiscalid", bulkatten.FiscalID);
                parameters.Add("@branchid", bulkatten.BranchID);
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
                    parameters.Add("@userid", jSon.UserID);
                    parameters.Add("@attendate", jSon.AttenDate);
                    parameters.Add("@attendatenepali", attendate.Year + "/" + month + "/" + day);
                    parameters.Add("@attentime", jSon.AttenTime);
                    await DBHelper.RunProc<dynamic>(sql, parameters);
                }
                return new CommonResponse()
                {
                    StatusCode = 200,
                    Message = "Success"
                };
            }
            catch (Exception ex)
            {
                return new CommonResponse()
                {
                    StatusCode = 200,
                    Message = ex.Message
                };
            }

            //res.StatusCode = data.FirstOrDefault().StatusCode;
            //res.Message = data.FirstOrDefault().Message;
            //return res;           
        }

        public async Task<AdminDepartmentRes> AdminDepartment(AdminDepartmentReq req)
        {
            AdminDepartmentRes res = new AdminDepartmentRes();
            res.list = null;
            var sql = "sp_admin_department";
            var parameters = new DynamicParameters();
            parameters.Add("@flag", req.Flag);
            parameters.Add("@staffid", req.StaffID);
            parameters.Add("@department", req.Department);
            parameters.Add("@depheadid", req.DepHeadID);
            parameters.Add("@branchid", req.BranchID);
            parameters.Add("@fiscalid", req.FiscalID);
            parameters.Add("@departmentid", req.DepartmentID);
            parameters.Add("@status", req.Status);
            parameters.Add("@comid", req.ComID);
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if (data.Count() != 0 && data.FirstOrDefault().Message == null)
            {
                res.list = data.ToList();
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
            return res;
        }

        public async Task<SubDepartment> SubDepartment(SubDepartmentReq req)
        {
            SubDepartment res = new SubDepartment();
            res.SubDepList = null;
            var sql = "sp_admin_sub_department";
            var parameters = new DynamicParameters();
            parameters.Add("@flag", req.Flag);
            parameters.Add("@staffid", req.StaffID);
            parameters.Add("@subdepartname", req.SubDepartName);
            parameters.Add("@subdepheadid", req.SubDepHeadID);
            parameters.Add("@departid", req.DepartID);
            parameters.Add("@branchid", req.BranchID);
            parameters.Add("@fiscalid", req.FiscalID);
            parameters.Add("@subdepartid", req.SubDepartID);
            parameters.Add("@status", req.Status);
            parameters.Add("@comid", req.ComID);
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if (data.Count() != 0 && data.FirstOrDefault().Message == null)
            {
                res.SubDepList = data.ToList();
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
            return res;
        }

        public async Task<Designation> Designation(DesignationReq req)
        {
            Designation res = new Designation();
            res.DesignationList = null;
            var sql = "sp_admin_designation";
            var parameters = new DynamicParameters();
            parameters.Add("@flag", req.Flag);
            parameters.Add("@staffid", req.StaffID);
            parameters.Add("@desigid", req.DesigID);
            parameters.Add("@designation", req.Designation);
            parameters.Add("@departid", req.DepartID);
            parameters.Add("@branchid", req.BranchID);
            parameters.Add("@fiscalid", req.FiscalID);
            parameters.Add("@subdepartid", req.SubDepartID);
            parameters.Add("@status", req.Status);
            parameters.Add("@comid", req.ComID);
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if (data.Count() != 0 && data.FirstOrDefault().Message == null)
            {
                res.DesignationList = data.ToList();
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
            return res;
        }


        public async Task<Product> ProductAdmin(ProductReq req)
        {
            Product res = new Product();
            res.ProductList = null;
            var sql = "sp_admin_product";
            var parameters = new DynamicParameters();
            parameters.Add("@flag", req.Flag);
            parameters.Add("@staffid", req.StaffID);
            parameters.Add("@productid", req.ProductID);
            parameters.Add("@product", req.Product);
            parameters.Add("@description", req.Description);
            parameters.Add("@prodid", req.ProdID);
            parameters.Add("@branchid", req.BranchID);
            parameters.Add("@fiscalid", req.FiscalID);
            parameters.Add("@comid", req.ComID);
            parameters.Add("@status", req.Status);
            if (!string.IsNullOrEmpty(req.PImage))
            {
                var img = Convert.FromBase64String(req.PImage);
                Image image = Image.FromStream(new MemoryStream(img));
                var imgname = DateTime.Now.Ticks;
                if (!Directory.Exists("assets\\photo\\product"))
                {
                    Directory.CreateDirectory("assets\\product");
                    image.Save("assets\\photo\\product\\" + imgname + ".jpg", ImageFormat.Jpeg);
                }
                image.Save("assets\\photo\\product\\" + imgname + ".jpg", ImageFormat.Jpeg);
                parameters.Add("@pimage", imgname + ".jpg");
            }
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if (data.Count() != 0 && data.FirstOrDefault().Message == null)
            {
                res.ProductList = data.ToList();
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
            return res;
        }


        public async Task<Shift> ShiftAdmin(ShiftReq req)
        {
            Shift res = new Shift();
            res.ShiftList = null;
            var sql = "sp_admin_shift";
            var parameters = new DynamicParameters();
            parameters.Add("@comid", req.ComID);
            parameters.Add("@staffid", req.StaffID);
            parameters.Add("@flag", req.Flag);
            parameters.Add("@shift", req.Shift);
            parameters.Add("@start", req.Start);
            parameters.Add("@end", req.End);
            parameters.Add("@allowlatein", req.AllowLateIn);
            parameters.Add("@allowearlyout", req.AllowEarlyOut);
            parameters.Add("@lunchstart", req.LunchStart);
            parameters.Add("@lunchend", req.LunchEnd);
            parameters.Add("@branchid", req.BranchID);
            parameters.Add("@fiscalid", req.FiscalID);
            parameters.Add("@shiftid", req.ShiftID);
            parameters.Add("@status", req.Status);
            parameters.Add("@hdhour", req.HDHour);
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if (data.Count() != 0 && data.FirstOrDefault().Message == null)
            {
                res.ShiftList = data.ToList();
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
            return res;
        }

        public async Task<User> UserAdmin(UserReq req)
        {
            var res = new User();
            res.UserList = null;
            var sql = "sp_admin_user";
            var parameters = new DynamicParameters();
            parameters.Add("@comid", req.ComID);
            parameters.Add("@flag", req.Flag);
            parameters.Add("@staffid", req.StaffID);
            parameters.Add("@userid", req.UserID);
            parameters.Add("@usercode", req.UserCode);
            parameters.Add("@devicecode", req.DeviceCode);
            parameters.Add("@mobileid", req.MobileID);
            parameters.Add("@username", req.UserName);
            parameters.Add("@password", req.Password);
            parameters.Add("@email", req.Email);
            parameters.Add("@contact", req.Contact);
            parameters.Add("@phone", req.Phone);
            parameters.Add("@address", req.Address);
            parameters.Add("@district", req.District);
            parameters.Add("@dateofbirth", req.DateOfBirth);
            parameters.Add("@citizenship", req.CitizenshipNo);
            parameters.Add("@pan", req.PAN);
            parameters.Add("@gender", req.Gender);
            parameters.Add("@bloodgroup", req.BloodGroup);
            parameters.Add("@firstname", req.FirstName);
            parameters.Add("@lastname", req.LastName);
            parameters.Add("@religion", req.Religion);
            parameters.Add("@maritialstatus", req.MaritialStatus);
            
            parameters.Add("@enrolldate", req.EnrollDate);
            parameters.Add("@workingstatus", req.WorkingStatus);
            parameters.Add("@leavedate", req.LeaveDate);
            parameters.Add("@jobtype", req.JobType);
            parameters.Add("@shift", req.Shift);
            parameters.Add("@shifttype", req.ShiftType);
            parameters.Add("@grade", req.Grade);
            parameters.Add("@department", req.Department);
            parameters.Add("@subdepartment", req.SubDepartment);
            parameters.Add("@designation", req.Designation);
            parameters.Add("@workingdays", req.WorkintDays);
            parameters.Add("@ismanager", req.IsManager);
            parameters.Add("@fiscalid", req.FiscalID);
            parameters.Add("@branchid", req.BranchID);
            parameters.Add("@status", req.Status);
            parameters.Add("@uid", req.UID);
            parameters.Add("@middlename", req.MiddleName);
            if (!string.IsNullOrEmpty(req.Image))
            {
                var img = Convert.FromBase64String(req.Image);
                Image image = Image.FromStream(new MemoryStream(img));
                var imgname = DateTime.Now.Ticks;
                if (!Directory.Exists("E:\\easysoftware\\API\\gharelukam\\assets\\photo\\user"))
                {
                    Directory.CreateDirectory("E:\\easysoftware\\API\\gharelukam\\assets\\photo\\user");
                    image.Save("E:\\easysoftware\\API\\gharelukam\\assets\\photo\\user\\" + imgname + ".jpg", ImageFormat.Jpeg);
                }
                else
                {
                    image.Save("E:\\easysoftware\\API\\gharelukam\\assets\\photo\\user\\" + imgname + ".jpg", ImageFormat.Jpeg);
                }                
                parameters.Add("@image", imgname + ".jpg");
            }
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if (data.Count() != 0 && data.FirstOrDefault().Message == null)
            {
                res.UserList = data.ToList();
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
            return res;
        }


        public async Task<Branch> BranchAdmin(BranchReq req)
        {
            var res = new Branch();
            res.BranchLst = null;
            var sql = "sp_admin_branch";
            var parameters = new DynamicParameters();
            parameters.Add("@comid", req.ComID);
            parameters.Add("@flag", req.Flag);
            parameters.Add("@staffid", req.StaffID);
            parameters.Add("@name", req.Name);
            parameters.Add("@address", req.Address);
            parameters.Add("@district", req.District);
            parameters.Add("@fiscalid", req.FiscalID);
            parameters.Add("@status", req.Status);
            parameters.Add("@branchid", req.BranchID);

            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if (data.Count() != 0 && data.FirstOrDefault().Message == null)
            {
                res.BranchLst = data.ToList();
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
            return res;
        }

        public async Task<FiscalYear> FiscalAdmin(FiscalYearReq req)
        {
            var res = new FiscalYear();
            res.FiscalYearlst = null;
            var sql = "sp_admin_fiscal";
            var parameters = new DynamicParameters();
            parameters.Add("@comid", req.ComID);
            parameters.Add("@flag", req.Flag);
            parameters.Add("@staffid", req.StaffID);            
            parameters.Add("@fiscalyear", req.FiscalYear);            
            parameters.Add("@iscurrent", req.IsCurrent);            
            parameters.Add("@startdate", req.StartDate);            
            parameters.Add("@enddate", req.EndDate);            
            parameters.Add("@fiscalid", req.FiscalID);            
            parameters.Add("@status", req.Status);
            parameters.Add("@branchid", req.BranchID);
            parameters.Add("@fid", req.FID);

            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if (data.Count() != 0 && data.FirstOrDefault().Message == null)
            {
                res.FiscalYearlst = data.ToList();
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
            return res;
        }

        public async Task<DocumentRes> DocumentAdmin(DocumentReq req)
        {
            var res = new DocumentRes();
            res.Doclst = null;
            var sql = "sp_admin_document";
            var parameters = new DynamicParameters();
            parameters.Add("@comid", req.ComID);
            parameters.Add("@flag", req.Flag);
            parameters.Add("@staffid", req.StaffID);
            parameters.Add("@userid", req.UserID);
            parameters.Add("@filename", req.FileName);
            parameters.Add("@filemedium", req.FileMedium);
            if(req.FileMedium == 2)
            {
                var file = Convert.FromBase64String(req.FilePath);
                if (!Directory.Exists("E:\\easysoftware\\API\\gharelukam\\assets\\file\\"))
                {
                    Directory.CreateDirectory("E:\\easysoftware\\API\\gharelukam\\assets\\file\\");                    
                }
                var f = new FileStream("E:\\easysoftware\\API\\gharelukam\\assets\\file\\" + req.FileName+req.FileType, FileMode.Create,FileAccess.Write);
                //var f = new FileStream("assets\\file\\" + req.FileName+"."+req.FileType, FileMode.Create,FileAccess.Write);
                f.Write(file);
                f.Close();
                
                parameters.Add("@filepath",req.FileName+"."+req.FileType);
            }
            else
            {
                parameters.Add("@filepath", req.FilePath);
            }
            parameters.Add("@filetype", req.FileType);
            parameters.Add("@branchid", req.BranchID);
            parameters.Add("@fiscalid", req.FiscalID);
            parameters.Add("@status", req.Status);
            parameters.Add("@docid", req.DocID);
            

            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if (data.Count() != 0 && data.FirstOrDefault().Message == null)
            {
                res.Doclst = data.ToList();
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
            return res;
        }

        public async Task<BankAdminRes> BankAdmin(BankAdminReq req)
        {
            BankAdminRes res = new BankAdminRes();
            res.BankLst = null;
            var sql = "sp_admin_bank";
            var parameters = new DynamicParameters();
            parameters.Add("@flag", req.Flag);
            parameters.Add("@staffid", req.StaffID);
            parameters.Add("@userid", req.UserID);
            parameters.Add("@bankname", req.BankName);
            parameters.Add("@acname", req.AcName);
            parameters.Add("@acno", req.AcNo);
            parameters.Add("@branch", req.Branch);
            parameters.Add("@branchid", req.BranchID);
            parameters.Add("@fiscalid", req.FiscalID);            
            parameters.Add("@status", req.Status);
            parameters.Add("@comid", req.ComID);
            parameters.Add("@bankid", req.BankID);
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if (data.Count() != 0 && data.FirstOrDefault().Message == null)
            {
                res.BankLst = data.ToList();
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
            return res;
        }


        public async Task<LeaveType> LeaveType(LeaveTypeReq req)
        {
            LeaveType res = new LeaveType();
            res.LeaveLst = null;
            var sql = "sp_admin_leave";
            var parameters = new DynamicParameters();
            parameters.Add("@flag", req.Flag);
            parameters.Add("@staffid", req.StaffID);
            parameters.Add("@comid", req.ComID);
            parameters.Add("@name", req.Name);
            parameters.Add("@balance", req.Balance);
            parameters.Add("@ispaid", req.IsPaid);
            parameters.Add("@iscarryable", req.IsCarryable);
            parameters.Add("@gender", req.Gender);
            parameters.Add("@description", req.Description);
            parameters.Add("@branchid", req.BrancID);
            parameters.Add("@fiscalid", req.FiscalID);
            parameters.Add("@status", req.Status);
            parameters.Add("@leaveid", req.LeaveID);
            
            var data = await DBHelper.RunProc<dynamic>(sql, parameters);
            if (data.Count() != 0 && data.FirstOrDefault().Message == null)
            {
                res.LeaveLst = data.ToList();
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
            return res;
        }
    }
}
