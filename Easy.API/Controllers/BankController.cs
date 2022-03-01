using Easy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Easy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BankController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("~/api/bankinfo")]
        public async Task<IActionResult> BankList(string comID, string empID)
        {
            var data = await _unitOfWork.bankInfoServices.BankInfo(comID,empID);
            return Ok(data);
        }
    }
}
