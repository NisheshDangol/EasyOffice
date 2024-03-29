﻿using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class FiscalYear:CommonResponse
    {
        public List<dynamic> FiscalYearlst { get; set; }
    }

    public class FiscalYearReq
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public string Flag { get; set; }
        public string FiscalYear { get; set; }
        public int IsCurrent { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int Status { get; set; }
        public int FID { get; set; }
    }
}
