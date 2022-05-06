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
        public async Task<CheckSessionOutput> CheckSession(CheckSession Login)
        {
            string sqluser = "sp_userinfo";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@com_id", Login.ComID);
            parameters.Add("@username", Login.UserName);
            parameters.Add("@device_id", Login.DeviceID);
            parameters.Add("@notification_token", Login.NotificationToken);
            parameters.Add("@flag", "CheckSession");
            var common = await DBHelper.RunProc<dynamic>(sqluser, parameters);
            if (common.Count() != 0 && common.FirstOrDefault().UID !=null)
            {
                return new CheckSessionOutput
                {
                    Logins = common.ToList(),
                    Message = "Success",
                    StatusCode = 200
                };
            }
            else
            {
                return new CheckSessionOutput
                {
                    Logins = null,
                    Message = common.FirstOrDefault().Message,
                    StatusCode = common.FirstOrDefault().StatusCode
                };
            }
        }

        public async Task<ListOutPut> Login(Login Login)
        {
            var logout = new ListOutPut();
            string sqluser = "sp_userinfo";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@com_id", Login.CompanyId);
            parameters.Add("@username", Login.UserName);
            parameters.Add("@password", Login.Password);
            parameters.Add("@notification_token", Login.NotificationToken);
            parameters.Add("@device_id", Login.DeviceId);
            parameters.Add("@flag","Login");
            var common= await DBHelper.RunProc<dynamic>(sqluser, parameters);
            if (common.Count() == 0 || common.FirstOrDefault().StatusCode != null)
            {
                logout.Token = null;
                logout.Logins = null;
                logout.Message = common.FirstOrDefault().Message;
                logout.StatusCode = common.FirstOrDefault().StatusCode;
            }
            else
            {
                logout.Token = _tokenInterface.TokenGenerateString(Login.UserName);
                logout.Logins = common.ToList();
                logout.StatusCode = 200;
                logout.Message = "Success";
            }
            return logout;  
        }
            
        public async Task<CommonResponse> ChangePassword(ChangePsw changePsw)
        {
            CommonResponse res = new CommonResponse();
            res.Message = "";
            res.StatusCode = 400;
            if (changePsw.UserID == 0) res.Message = "UserID is empty";
            else if (string.IsNullOrEmpty(changePsw.OldPwd)) res.Message = "OldPwd is empty";
            else if (string.IsNullOrEmpty(changePsw.NewPwd)) res.Message = "NewPwd is empty";
            else
            {
                string sql = "sp_userinfo";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@flag", "ChangePwd");
                parameters.Add("@user_id", changePsw.UserID);
                parameters.Add("@oldpassword", changePsw.OldPwd);
                parameters.Add("@password", changePsw.NewPwd);
                var data = await DBHelper.RunProc<CommonResponse>(sql, parameters);
                res.Message = data.FirstOrDefault().Message;
                res.StatusCode = data.FirstOrDefault().StatusCode;
            }
            return res;
        }
    }
}
