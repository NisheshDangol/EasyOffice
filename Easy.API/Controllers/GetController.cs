using Easy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Easy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("~/api/GetDoc")]
        public async Task<IActionResult> GetDoc(string ComId, string EmpId)
        {
            var data= await _unitOfWork.GetServices.listdoc(ComId, EmpId);
            return Ok(data);

        }
    }
}
