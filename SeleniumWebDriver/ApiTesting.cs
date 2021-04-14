using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

//  "joke": "Programming is 10% science, 20% ingenuity, and 70% getting the ingenuity to work with the science.",
namespace SeleniumWebDriver
{
    class ApiTesting
    {
        [Test]
        public async System.Threading.Tasks.Task GetApiTestAsync()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://v2.jokeapi.dev/joke/programming,Misc?type=single"),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                var responseCode = response.StatusCode.ToString();
                Assert.AreEqual("OK", responseCode, $"Status Code: {responseCode}");

                dynamic resp = JsonConvert.DeserializeObject(body);
                Console.WriteLine(resp.joke);
            }
        }

        [Test]
        public void PostApiTest()
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://jsonplaceholder.typicode.com/users");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = "{ \"id\":11}";
                streamWriter.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            var responseCode = httpResponse.StatusCode.ToString();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Assert.AreEqual("Created", responseCode, $"Response: {responseCode}");
                Console.WriteLine(responseCode);
            }
        }
    }

}

