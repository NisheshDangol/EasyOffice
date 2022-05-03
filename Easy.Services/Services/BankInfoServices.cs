using Dapper;
using Easy.Connection.Dapper;
using Easy.Models.Models;
using Easy.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services.Services
{
    public class BankInfoServices : IBankInfoInterface
    {
        public async Task<Bank> BankInfo(string ComID, int EmpID)
        {
            var bank = new Bank();
            if (string.IsNullOrEmpty(ComID))
            {
                bank.BankInfo = null;
                bank.StatusCode = 400;
                bank.Message = "ComId is null";
            }
            else if(EmpID==0)
                {
                bank.BankInfo = null;
                bank.StatusCode = 400;
                bank.Message = "EmpId is null";
            }
            else
            {
                string sql = "sp_userinfo";
                var parameters = new DynamicParameters();
                parameters.Add("@flag", "bankinfo");
                parameters.Add("@com_id", ComID);
                parameters.Add("@emp_id", EmpID);
                var data = await DBHelper.RunProc<dynamic>(sql, parameters);
                
                if (data.Count() != 0 && data.FirstOrDefault().StatusCode== null)
                {

                    bank.BankInfo = data.ToList();
                    bank.StatusCode = 200;
                    bank.Message = "Success";

                }
                else
                {
                    bank.BankInfo = null;
                    bank.StatusCode = data.FirstOrDefault().StatusCode;
                    bank.Message = data.FirstOrDefault().Message;
                }
            }
            return bank;      
        }
    }
}
