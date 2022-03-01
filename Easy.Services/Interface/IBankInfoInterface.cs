using Easy.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services.Interface
{
    public interface IBankInfoInterface
    {
        Task<Bank> BankInfo(string comID,string empID);
    }
}
