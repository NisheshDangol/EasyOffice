using Easy.Models.Models;
using Easy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EasyOfficeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AssetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("~/api/admin/asset")]
        public async Task<IActionResult> AssetAdmin(AssetAdminReq req)
        {
            var data = await _unitOfWork.assetService.AdminAsset(req);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/admin/asset/vendor")]
        public async Task<IActionResult> AssetVendor(AssetVendorReq req)
        {
            var data = await _unitOfWork.assetService.AdminAssetVendor(req);
            return Ok(data);
        }
    }
}
