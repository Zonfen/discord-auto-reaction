using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace discord_auto_react
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static int version = 8;
        private static string baseUrl = "https://discord.com/api/v/" + version + "/" ;
        private static string authToken = "";

        async static Task Main()
        {
            try
            {

                HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
                response.EnsureSuccessStatusCode();
                var values = new Dictionary<string, string>
                {
                    { "thing1", "hello" },
                    { "thing2", "world" }
                };

                var content = new FormUrlEncodedContent(values);

                var responseString = await response.Content.ReadAsStringAsync();

                Initiate();

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
        }   

        private static void Initiate()
        {
            Console.WriteLine("Hello World!");
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

            var content = new FormUrlEncodedContent(payload);

            await client.PostAsync(baseUrl + uri, content);

            return "";
        }
    }
}
