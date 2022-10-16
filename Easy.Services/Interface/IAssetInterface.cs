using Easy.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services.Interface
{
    public interface IAssetInterface
    {
        Task<AssetRes> AdminAsset(AssetAdminReq req);
        Task<AssetRes> AdminAssetVendor(AssetVendorReq req);
    }
}
