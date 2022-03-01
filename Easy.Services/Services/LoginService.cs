using Dapper;
using Easy.Connection;
using Easy.Connection.Dapper;
using Easy.Models.DTO;
using Easy.Models.Models;
using Easy.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services.Services
{
    public class LoginService : ILoginInterface
    {
        public async Task<ListOutPut> CheckSession(CheckSession login)
        {
            string sqluser = "sp_user";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@com_id", login.companyid);
            parameters.Add("@username", login.username);
            parameters.Add("@device_id", login.deviceID);
            parameters.Add("@notification_token", login.notificationToken);
            parameters.Add("@flag", 2);
            var common = await DBHelper.RunProc<LoginViewModel>(sqluser, parameters);
            if (common.FirstOrDefault().firstName!=null && common.Count() != 0)
            {
                return new ListOutPut
                {
                    logins = common.ToList(),
                    Message = "Success",
                    Status_Code = 200
                };
            }
            else
            {
                return new ListOutPut
                {
                    logins = null,
                    Message = "No Data Found.",
                    Status_Code = 400
                };
            }
        }

        public async Task<ListOutPut> Login(Login login)
        {

                    string sqluser = "sp_user";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@com_id", login.CompanyId);
                    parameters.Add("@username", login.UserName);
                    parameters.Add("@password", login.Password);
                    parameters.Add("@notification_token", login.NotificationToken);
                    parameters.Add("@device_id", login.DeviceId);
                    parameters.Add("@flag",1);
                    var common= await DBHelper.RunProc<LoginViewModel>(sqluser, parameters);
                    if(common.FirstOrDefault().firstName != null && common.Count() != 0)
                    {
                        return new ListOutPut
                        {
                            logins = common.ToList(),
                            Message = "Success",
                            Status_Code = 200
                        };
                    }
                    else
                    {
                        return new ListOutPut
                        {
                            logins = null,
                            Message = "No Data Found.",
                            Status_Code = 400
                        };
                    }
                
                
            
        }
            
    }
}
