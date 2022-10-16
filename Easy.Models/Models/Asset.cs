using Easy.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Models.Models
{
    public class AssetAdminReq
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public int VendorID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Flag { get; set; }
        public string AssetType { get; set; }
        public string Image { get; set; }
        public string ExpiryDate { get; set; }
        public int NoOfItem { get; set; }
        public string Quality { get; set; }
        public List<AssetSpecification> Specification { get; set; }
        public AssetTransaction BuyInf { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int AssetID { get; set; }
        public int Status { get; set; }
        public string IsExpired { get; set; }
    }

    public class AssetVendorReq
    {
        public string ComID { get; set; }
        public int StaffID { get; set; }
        public string Name { get; set; }
        public string Flag { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string ContactPerson { get; set; }
        public string PAN { get; set; }
        public string VendorID { get; set; }
        public int BranchID { get; set; }
        public int FiscalID { get; set; }
        public int Status { get; set; }
    }

    public class AssetSpecification
    {
        public string Spec { get; set; }
    }

    public class AssetTransaction
    {
        public string Type { get; set; }
        public string Date { get; set; }
        public int PerPrice { get; set; }
    }

    public class AssetRes : CommonResponse
    {
        public List<dynamic> AssetLst { get; set; }
    }
}
