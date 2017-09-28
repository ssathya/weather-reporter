using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Models;

namespace Weather.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        #region Public Methods

        [HttpGet("[action]/{city}")]
        public async Task<IActionResult> City(string city)
        {
            var apiKey = @"2c1d6ac6bb2b27c9c594d3f1a4df4683";
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid={apiKey}&units=imperial");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);
                    return Ok(new
                    {
                        Temp = rawWeather.main.temp,
                        Summary = string.Join(",", rawWeather.weather.Select(x => x.main)),
                        City = rawWeather.name
                    });
                }
                catch (HttpRequestException ex)
                {
                    return BadRequest($"Error getting weather from OpenWeather: {ex.Message}");
                }
            }
        }

        #endregion Public Methods
    }
}