using Easy.Models.Models;
using Easy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CorePush.Google;

namespace Easy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpPost]
        [Route("~/api/push-notification-by-topic")]
        public async Task<IActionResult> SendNotificationByTopic(PushNotificationByTopic topic)
        {
            var data = await _unitOfWork.SendNotificationServices.SendNotificationByTopic(topic);
            return Ok(data);
        }

        [HttpPost]
        [Route("~/api/push-notification-by-deviceID")]
        public async Task<IActionResult> SendNotificationByDeviceID(PushNotificationByDeviceId DeviceID)
        {
            var data = await _unitOfWork.SendNotificationServices.SendNotificationByDeviceID(DeviceID);
            return Ok(data);
        }
    }
}
