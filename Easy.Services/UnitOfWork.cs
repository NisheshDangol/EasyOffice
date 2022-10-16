using Easy.Models.Models;
using Easy.Services.Interface;
using Easy.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Models.Model;
using Service.Services;
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
        private readonly SmtpSettings _settings;
        private readonly IConfiguration _config;

        public UnitOfWork(ITokenInterface tokenInterface, IOptions<FcmNotificationSetting> settings, IOptions<SmtpSettings> setting, IConfiguration config)
        {
            _tokenInterface = tokenInterface;
            _fcmNotificationSetting = settings.Value;
            _settings = setting.Value;
            _config = config;
        }
        public LoginService service => new LoginService(_tokenInterface);

        public BankInfoServices bankInfoServices => new BankInfoServices();

        public JobInfoServices jobInfoServices => new JobInfoServices();

        public GetServices GetServices => new GetServices();

        public PostServices PostServices => new PostServices(_settings);

        public SendNotificationService SendNotificationServices => new SendNotificationService(_fcmNotificationSetting);

        public BlogService blogservice => new BlogService();

        public AttendanceService attendanceService => new AttendanceService();

        public AssetService assetService => new AssetService(_config);
    }
}
