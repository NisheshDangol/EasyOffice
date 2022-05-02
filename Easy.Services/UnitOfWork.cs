using Easy.Models.Models;
using Easy.Services.Interface;
using Easy.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
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
        private readonly ITokenInterface _tokenInterface;
        private readonly FcmNotificationSetting _fcmNotificationSetting;

        public UnitOfWork(ITokenInterface tokenInterface, IOptions<FcmNotificationSetting> settings)
        {
            _tokenInterface = tokenInterface;
            _fcmNotificationSetting = settings.Value;
        }
        public LoginService service => new LoginService(_tokenInterface);

        public BankInfoServices bankInfoServices => new BankInfoServices();

        public JobInfoServices jobInfoServices => new JobInfoServices();

        public GetServices GetServices => new GetServices();

        public PostServices PostServices => new PostServices();

        public SendNotificationService SendNotificationServices => new SendNotificationService(_fcmNotificationSetting);
    }
}
