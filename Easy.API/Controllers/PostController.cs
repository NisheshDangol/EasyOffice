using Easy.Models.Models;
using Easy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Easy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("~/api/create-organization")]
        public async Task<IActionResult> CreateOrganization(OrgnizationGet orgnization)
        {
            var data = await _unitOfWork.PostServices.CreateCompany(orgnization);
            return Ok(data);
        }
    }
}
