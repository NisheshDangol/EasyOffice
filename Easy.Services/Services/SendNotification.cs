using CorePush.Google;
using Easy.Models.Models;
using Easy.Services.Interface;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Options;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;



namespace Easy.Services.Services
{
    public class SendNotificationService:ISendNotificationInterface
    {
        private readonly FcmNotificationSetting _fcmNotificationSetting;
        public SendNotificationService(FcmNotificationSetting settings)
        {
            _fcmNotificationSetting = settings;
        }


        public async Task<String> SendNotificationByTopic(PushNotificationByTopic topic)
        {
            String sResponseFromServer = "Error";
            try
            {
                string server_api_key = _fcmNotificationSetting.ServerKey;
                string sender_id = _fcmNotificationSetting.SenderId;

                dynamic data = new
                {
                    // if you want to test for single device
                    to = "/topics/"+topic,

                    // registration_ids = singlebatch, // this is for multiple user 

                    notification = new
                    {
                        // Notification title
                        title = topic.Topic,

                        // Notification body data
                        body = topic.Body,

                        // When click on notification user redirect to this link
                        link = "https://www.dynagroseed.com/app/uploads/2018/02/testing-clipart-quiet-testing-sign-v0ryt0-297x300.jpg",

                        //icon for notification
                        //icon: "https://www.dynagroseed.com/app/uploads/2018/02/testing-clipart-quiet-testing-sign-v0ryt0-297x300.jpg"
                    }
                };

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(json);

                WebRequest tRequest;
                tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", server_api_key));

                tRequest.Headers.Add(string.Format("Sender: id={0}", sender_id));

                tRequest.ContentLength = byteArray.Length;
                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                sResponseFromServer = tReader.ReadToEnd();

                tReader.Close();
                dataStream.Close();
                tResponse.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return(sResponseFromServer);
            
        }

        public async Task<String> SendNotificationByDeviceID(PushNotificationByDeviceId DeviceID)
        {
            String sResponseFromServer = "Error";
            try
            {
                string server_api_key = _fcmNotificationSetting.ServerKey;
                string sender_id = _fcmNotificationSetting.SenderId;

                dynamic data = new
                {
                    // if you want to test for single device
                    to = DeviceID,

                    // registration_ids = singlebatch, // this is for multiple user 

                    notification = new
                    {
                        // Notification title
                        title = DeviceID.Title,

                        // Notification body data
                        body = DeviceID.Body,

                        // When click on notification user redirect to this link
                        link = "https://www.dynagroseed.com/app/uploads/2018/02/testing-clipart-quiet-testing-sign-v0ryt0-297x300.jpg",

                        //icon for notification
                        //icon: "https://www.dynagroseed.com/app/uploads/2018/02/testing-clipart-quiet-testing-sign-v0ryt0-297x300.jpg"
                    }
                };

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(data);
                Byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(json);

                WebRequest tRequest;
                tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", server_api_key));

                tRequest.Headers.Add(string.Format("Sender: id={0}", sender_id));

                tRequest.ContentLength = byteArray.Length;
                Stream dataStream = tRequest.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                WebResponse tResponse = tRequest.GetResponse();

                dataStream = tResponse.GetResponseStream();

                StreamReader tReader = new StreamReader(dataStream);

                sResponseFromServer = tReader.ReadToEnd();

                tReader.Close();
                dataStream.Close();
                tResponse.Close();
            }
            catch (Exception)
            {
                throw;
            }
            return sResponseFromServer;
        }
    }
}
