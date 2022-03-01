using Easy.Models.Models;
using Easy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Easy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Route("~/api/login")]
        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            var data = await _unitOfWork.service.Login(login);
            return Ok(data);
        }
        [Route("~/api/check-session")]
        [HttpPost]
        public async Task<IActionResult> CheckSession(CheckSession login)
        {
            var data = await _unitOfWork.service.CheckSession(login);
            return Ok(data);
        }
    }
}
