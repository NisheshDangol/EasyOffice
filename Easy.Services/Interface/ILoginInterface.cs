using Easy.Connection;
using Easy.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services.Interface
{
    public interface ILoginInterface
    {
        Task<ListOutPut> Login(Login login);
        Task<CheckSessionOutput> CheckSession(CheckSession login);
        Task<CommonResponse> ChangePassword(int UserID, string OldPwd, string NewPwd);
    }
}
