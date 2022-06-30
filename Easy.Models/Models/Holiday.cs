using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Holiday:CommonResponse
    {
        public List<dynamic> Holidays { get; set; }
    }

    public class HolidayReq
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public string Flag { get; set; }
        public string Name { get; set; }
        public string EnglishDate { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int Status { get; set; }
        public int HolidayID { get; set; }
    }
}
