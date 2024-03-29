﻿using Easy.Models.Models;
using Easy.Services;
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
        [Route("~/api/checksession")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> CheckSession(CheckSession login)
        {
            var data = await _unitOfWork.service.CheckSession(login);
            return Ok(data);
        }

        [Route("~/api/change-password")]
        //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePsw changePsw)
        {
            var data = await _unitOfWork.service.ChangePassword(changePsw);
            return Ok(data);
        }
    }
}
