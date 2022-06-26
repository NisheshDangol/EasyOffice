﻿using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Designation:CommonResponse
    {
        public List<dynamic> DesignationList { get; set; }
    }

    public class DesignationReq
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public int DepartID { get; set; }
        public int SubDepartID { get; set; }
        public string Designation { get; set; }
        public string MaxSal { get; set; }
        public string MinSal { get; set; }
        public string Flag { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int DesigID { get; set; }
        public int Status { get; set; }
    }
}
