﻿using Easy.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        public LoginService service => new LoginService();
    }
}