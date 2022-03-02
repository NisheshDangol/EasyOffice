using Dapper;
using Easy.Connection;
using Easy.Connection.Dapper;
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
        private readonly ITokenInterface _tokenInterface;

        public LoginService(ITokenInterface tokenInterface)
        {
            _tokenInterface = tokenInterface;
        }
        public async Task<ListOutPut> CheckSession(CheckSession Login)
        {
            string sqluser = "sp_user";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@com_id", Login.CompanyId);
            parameters.Add("@username", Login.Username);
            parameters.Add("@device_id", Login.DeviceID);
            parameters.Add("@notification_token", Login.NotificationToken);
            parameters.Add("@flag", 2);
            var common = await DBHelper.RunProc<LoginViewModel>(sqluser, parameters);
            if (common.Count() != 0 && common.FirstOrDefault().UID !=0)
            {
                return new ListOutPut
                {
                    Token = _tokenInterface.TokenGenerateString(Login.Username),
                    Logins = common.ToList(),
                    Message = "Success",
                    StatusCode = 200
                };
            }
            else
            {
                return new ListOutPut
                {
                    Logins = null,
                    Message = "No User Found.",
                    StatusCode = 400
                };
            }
        }

        public async Task<ListOutPut> Login(Login Login)
        {
            var logout = new ListOutPut();

                    string sqluser = "sp_user";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@com_id", Login.CompanyId);
                    parameters.Add("@username", Login.UserName);
                    parameters.Add("@password", Login.Password);
                    parameters.Add("@notification_token", Login.NotificationToken);
                    parameters.Add("@device_id", Login.DeviceId);
                    parameters.Add("@flag",1);
                    var common= await DBHelper.RunProc<LoginViewModel>(sqluser, parameters);
                    
                    if (common.Count() != 0 && common.FirstOrDefault().UID != 0)
                    {
                logout.Token = _tokenInterface.TokenGenerateString(Login.UserName);
                logout.Logins = common.ToList();
                logout.StatusCode = 200;
                logout.Message = "Success";
                    }
                    else
                    {
                logout.Token = null;
                logout.Logins = null;
                logout.Message = common.FirstOrDefault().Message;
                logout.StatusCode = common.FirstOrDefault().StatusCode;
            }
            return logout;
                
            
        }
            
    }
}
