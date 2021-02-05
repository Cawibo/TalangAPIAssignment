using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WhatCatAmI.Models;

namespace WhatCatAmI.Controllers
{
    [ApiController]
    [Route("Cat")]
    public class CatController : Controller
    {
        private readonly CatContext _context;
        private readonly Random rand = new Random();

        public CatController(CatContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var nCats = _context.CatItems.Count();
            var cat = _context.CatItems.Skip(rand.Next(nCats - 1)).Take(1).First();

            if (cat == null)
                return NotFound();

            return Ok(cat);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var cat = _context.CatItems.ToList().Find(item => item.Name == name);

            if (cat == null)
            {
                var httpClient = new HttpClient();
                var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri("https://api.thecatapi.com/v1/images/search/"),
                    Method = HttpMethod.Get,
                    Headers = { Authorization = new AuthenticationHeaderValue("47b09c96-2991-45ee-be60-3fbcc06323c8") }
                };
                var response = await httpClient.SendAsync(request);
                var json = await response.Content.ReadAsStringAsync();
                json = json.Trim(new char[]{
                    '[', ']'
                }); // escapes the json list
                var data = JsonConvert.DeserializeObject<CatImage>(json);

                cat = new CatItem { Url = data.Url, Name = name };

                _context.CatItems.Add(cat);
                _context.SaveChanges();
            }

            return Ok(cat);
        }
    }
}