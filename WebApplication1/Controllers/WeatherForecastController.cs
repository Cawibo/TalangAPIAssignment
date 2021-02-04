using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : Controller
    {
        
        
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly CatContext _context;

        public WeatherForecastController(CatContext context)
        {
            _context = context;
        }
        

        /*
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    */

        private Dictionary<string, string> nameStorage = new Dictionary<string, string>();

        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var potentialCat = _context.CatItems.ToList().Find(item => item.Name == name);

            if (potentialCat == null)
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
                json = json.Substring(1, json.Length - 2);
                var data = JsonConvert.DeserializeObject<CatImage>(json);

                _context.CatItems.Add(new CatItem {Url = data.url, Name = name, Data = data });
                _context.SaveChanges();

                return View("~/Views/Index.cshtml", data.url);
            }

            ;
            return View("~/Views/Index.cshtml", potentialCat.Url);
        }
    }
}
