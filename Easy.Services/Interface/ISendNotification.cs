using Easy.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Services.Interface
{
    interface ISendNotificationInterface
    {
        //public Task SendNotification();
        //Task<ResponseModel> SendNotification(PushNotification notificationModel);
        Task<String> SendNotificationByTopic(string topic);
        Task<String> SendNotificationByDeviceID(string DeviceID);
    }
}
