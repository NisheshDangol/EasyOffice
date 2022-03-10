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
        [HttpPost]
        [Route("~/api/create-lead")]
        public async Task<IActionResult> CreateLead(Lead lead)
        {
            var data = await _unitOfWork.PostServices.CreateLeads(lead);
            return Ok(data);
        }
        [HttpPost]
        [Route("~/api/create-follow-org")]
        public async Task<IActionResult> CreateFollowOrg(Followup followup)
        {
            var data = await _unitOfWork.PostServices.CreateFollowUp(followup);
            return Ok(data);
        }
    }
}
