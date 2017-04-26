using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Service.Tests
{
    [TestFixture]
    public class ApiFixture
    {
        //private const string _BaseAddressURI = "http://localhost/TimeTrackerService/"; 
        private const string _BaseAddressURI = "https://timetrackerservice.azurewebsites.net/";

        [Explicit]
        [Test]
        public async Task GetUserNames()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_BaseAddressURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/TTWebAPI");
                if (response.IsSuccessStatusCode)
                {
                    string returnText = await response.Content.ReadAsStringAsync();
                    Assert.IsTrue(returnText.Contains("Christian Wilhite"));
                }
            }
        }

        [Explicit]
        [Test]
        public async Task GetProjectTime()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_BaseAddressURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/GetProjectTime");
                if (response.IsSuccessStatusCode)
                {
                    string returnText = await response.Content.ReadAsStringAsync();
                    Assert.AreEqual("28", returnText);
                }
                else
                {
                    Assert.Fail("Call failed");
                }
            }
        }

        [Explicit]
        [Test]
        public async Task UpdateProjectHours()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_BaseAddressURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/UpdateProjectHours");
                if (response.IsSuccessStatusCode)
                {
                    string returnText = await response.Content.ReadAsStringAsync();
                    Assert.AreEqual("true", returnText);
                }
                else
                {
                    Assert.Fail("Call failed");
                }
            }
        }

        [Explicit]
        [Test]
        public async Task UpdateHackathonProjectHours()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_BaseAddressURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/UpdateHackathonProjectHours");
                if (response.IsSuccessStatusCode)
                {
                    string returnText = await response.Content.ReadAsStringAsync();
                    Assert.AreEqual("true", returnText);
                }
                else
                {
                    Assert.Fail("Call failed");
                }
            }
        }

        [Explicit]
        [Test]
        public async Task UpdateTimeAwayProjectHours()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_BaseAddressURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/UpdateTimeAwayProjectHours");
                if (response.IsSuccessStatusCode)
                {
                    string returnText = await response.Content.ReadAsStringAsync();
                    Assert.AreEqual("true", returnText);
                }
                else
                {
                    Assert.Fail("Call failed");
                }
            }
        }

        [Explicit]
        [Test]
        public async Task GetTotalHours()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_BaseAddressURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/GetTotalHours");
                if (response.IsSuccessStatusCode)
                {
                    string returnText = await response.Content.ReadAsStringAsync();
                    Assert.AreEqual("52", returnText);
                }
                else
                {
                    Assert.Fail("Call failed");
                }
            }
        }

        [Explicit]
        [Test]
        public async Task GetActivitySummary()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_BaseAddressURI);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/GetActivitySummary");
                if (response.IsSuccessStatusCode)
                {
                    string returnText = await response.Content.ReadAsStringAsync();

                    Assert.IsTrue(returnText.Contains("Training, 0 hours"));
                }
            }
        }
    }
}
