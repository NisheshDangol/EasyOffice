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
        public async Task<Bank> BankInfo(string comID, string empID)
        {
            var bank = new Bank();
            if (comID =="")
            {
                bank.BankInfo = null;
                bank.Status_Code = 201;
                bank.Message = "comId is null";
            }
            else if(empID=="")
                {
                bank.BankInfo = null;
                bank.Status_Code = 202;
                bank.Message = "EmpId is null";
            }
            else
            {
                string sql = "select bank_name, ac_name, ac_no, branch from tbl_bank_information where com_id ='" + comID + "' and employee_id = '" + empID + "' and status=1";
                var data = await DBHelper.RunQuery<BankInfo>(sql);
                if (data.Count() != 0)
                {

                    bank.BankInfo = data.ToList();
                    bank.Status_Code = 200;
                    bank.Message = "Success";

                }
                else
                {
                    bank.BankInfo = null;
                    bank.Status_Code = 400;
                    bank.Message = "No Data";
                }
            }
            return bank;
            
            
            
        }
    }
}
