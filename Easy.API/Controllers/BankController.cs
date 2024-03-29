﻿using Easy.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;


namespace Easy.API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("CorsPolicy")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BankController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("~/api/bank-information")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> BankList(string ComID, int UserID)
        {
            var data = await _unitOfWork.bankInfoServices.BankInfo(ComID,UserID);
            return Ok(data);
        }
    }
}
