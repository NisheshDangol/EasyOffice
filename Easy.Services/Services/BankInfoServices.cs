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
            if (ComID =="")
            {
                bank.BankInfo = null;
                bank.StatusCode = 201;
                bank.Message = "comId is null";
            }
            else if(EmpID==0)
                {
                bank.BankInfo = null;
                bank.StatusCode = 202;
                bank.Message = "EmpId is null";
            }
            else
            {
                string sql = "select bank_name as BankName, ac_name as AcNumber, ac_no as AcName, branch as Branch from tbl_bank_information where com_id ='" + ComID + "' and employee_id = '" + EmpID + "' and status=1";
                var data = await DBHelper.RunQuery<BankInfo>(sql);
                if (data.Count() != 0)
                {

                    bank.BankInfo = data.ToList();
                    bank.StatusCode = 200;
                    bank.Message = "Success";

                }
                else
                {
                    bank.BankInfo = null;
                    bank.StatusCode = 400;
                    bank.Message = "No Data";
                }
            }
            return bank;
            
            
            
        }
    }
}
