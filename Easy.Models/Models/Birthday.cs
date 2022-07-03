using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Birthday:CommonResponse
    {
        public List<dynamic> BirthdayLst { get; set; }
    }

    public class BirthdayReq
    {
        public string ComID { get; set; }
        public string RFlag { get; set; }
        public string Value { get; set; }
        public int Status { get; set; }
        public int BranchID { get; set; }
    }
}
