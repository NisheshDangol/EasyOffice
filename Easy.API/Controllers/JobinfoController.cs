using Easy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Easy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobinfoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public JobinfoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Route("~/api/getjobinfo")]
        [HttpGet]
        public async Task<IActionResult> GetJobInfo(string Comid, string EmpId)
        {
            var data= await _unitOfWork.jobInfoServices.jobinfo(Comid, EmpId);
            return Ok(data);
        }
    }
}
