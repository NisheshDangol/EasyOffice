using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class Product: CommonResponse
    {
        public List<dynamic> ProductList { get; set; }
    }

    public class ProductReq
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public string Flag { get; set; }
        public int ProductID { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public string PImage { get; set; }
        public int ProdID { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
    }
}
