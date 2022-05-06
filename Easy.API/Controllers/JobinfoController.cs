using Easy.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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
        [Route("~/api/job-information")]
        [HttpGet]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetJobInfo(string ComID, int UserID)
        {
            var data= await _unitOfWork.jobInfoServices.Jobinfo(ComID, UserID);
            return Ok(data);
        }
    }
}
