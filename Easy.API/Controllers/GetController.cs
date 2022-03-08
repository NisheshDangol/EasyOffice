using Easy.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetDoc(string ComId, int EmpId)
        {
            var data= await _unitOfWork.GetServices.listdoc(ComId, EmpId);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/org-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> OrgList(string CompanyId, int IsOurClient, int UserId)
        {
            var data= await _unitOfWork.GetServices.orglist(CompanyId, IsOurClient, UserId);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/all-org-list")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> AllOrgList(string CompanyId, string EmployeeId, DateTime fromDate, DateTime toDate)
        {
            var data= await _unitOfWork.GetServices.allorglist(CompanyId, EmployeeId,fromDate,toDate);
            return Ok(data);

        }
        [HttpGet]
        [Route("~/api/org-type")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> OrgType(string CompanyId, string BranchId)
        {
            var data= await _unitOfWork.GetServices.orgtype(CompanyId, BranchId);
            return Ok(data);

        }
    }
}
