﻿using Easy.Services.Services;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services
{
    public interface IUnitOfWork
    {
        LoginService service { get; }
        BankInfoServices bankInfoServices { get; }
        JobInfoServices jobInfoServices { get; }
        GetServices GetServices { get; }
        PostServices PostServices { get; }  
        SendNotificationService SendNotificationServices { get; }
        BlogService blogservice { get; }
        AttendanceService attendanceService { get; }
        AssetService assetService { get; }
    }
}
