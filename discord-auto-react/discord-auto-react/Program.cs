using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace discord_auto_react
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static int version = 8;
        private static string baseUrl = "https://discord.com/api/v" + version + "/" ;
        private static string authToken = "";

        async static Task Main()
        {
            try
            {
                var responseString = await Login("tonypepic@hotmail.com", "Thefed911@");

                Console.WriteLine("Testing what the response string is: ", responseString);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }   

        private static void PostReaction()
        {

        }

        private async static Task<string> Login(string username, string password)
        {
            string uri = "auth/login";
            var payload = new Dictionary<string, string>
            {
                { "captcha_key", "null" },
                { "gift_code_sku_id", "null" },
                { "login", username },
                { "login_source", "null" },
                { "password", password },
                { "undelete", "false" }
            };

            var httpRequestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(baseUrl + uri),
                Headers = {
                    { HttpRequestHeader.Accept.ToString(), "application/json" },
                    { "X-Version", "1" }
                },
                Content = new StringContent(JsonConvert.SerializeObject(payload))
            };

            var response = client.SendAsync(httpRequestMessage).Result;

            return response.ToString();
        }
    }
}
