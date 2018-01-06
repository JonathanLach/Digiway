using DigiwayUWP.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DigiwayUWP.DataAccessObjects
{
    public class FCMPushNotification
    {
        private static string FireBase_URL = "https://fcm.googleapis.com/fcm/";
        private static string key_server = "AAAAzLED4p4:APA91bFXR4HpR_fEwVu1u-o2mZv0Da6Mxa2krIKxqCTs38qzlaSh-jLhTMqgaQxFp8SalmTBejxQwQXd9W_CUFwb-DQ3Q1WUbzhjS5yrFNVi-jZ1uwb84pp5ftl4-xyCpE4W6IifLlL4";
        private static string senderId = "879143150238";
        private string deviceId = "testid";

        public async Task SendPush(string title ,string message)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(FireBase_URL);
            client.DefaultRequestHeaders
                                    .Accept
                                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));//ACCEPT header

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("key", "=" + key_server);
            client.DefaultRequestHeaders.Add("Sender", "id=" + senderId);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "relativeAddress");
            var data = new
            {
                to = deviceId,
                notification = new
                {
                    body = message,
                    title = title,
                }
            };

            var json = JsonConvert.SerializeObject(data);
            request.Content = new StringContent(json,
                                                Encoding.UTF8,
                                                "application/json");
            await client.PostAsync("send", request.Content);
        }
    }
}
