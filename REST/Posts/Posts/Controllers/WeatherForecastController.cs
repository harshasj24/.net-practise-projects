using Microsoft.AspNetCore.Mvc;

namespace Posts.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            Dictionary<object, object> res = new Dictionary<object, object>();
                res.Add("name", "Harsha");
                res.Add("age", 12);
                res.Add("address", "asdfgh jkl zxcv bnm qwer tyu iop");

            return Ok (res);
        }
    }
}