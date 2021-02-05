using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WhatCatAmI.Models;

namespace WhatCatAmI.Controllers
{
    [Route("")]
    [Route("Home")]
    public class HomeController : Controller
    {
        private static async Task<CatItem> FetchCat(string name = "")
        {
            var httpClient = new HttpClient();
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri("https://localhost:44394/cat/" + name),
                Method = HttpMethod.Get
            };
            var response = await httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<CatItem>(json);

                return data;
            }

            return new CatItem()
            {
                Name = "404Kitten",
                Url = "https://image.shutterstock.com/image-photo/cute-kitten-sitting-striped-advertising-600w-1046885917.jpg"
            };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cat = await FetchCat();

            return View(cat);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Index(string name)
        {
            var cat = await FetchCat(name);

            return View(cat);
        }
    }
}