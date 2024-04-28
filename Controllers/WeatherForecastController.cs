using Microsoft.AspNetCore.Mvc;
using ShoppingCartEmailService.Model;
using ShoppingCartEmailService.Services;

namespace ShoppingCartEmailService.Controllers
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
        private readonly IMailService mailService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMailService mailService)
        {
            _logger = logger;
            this.mailService = mailService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        [HttpPost("Send")]
        public async Task<IActionResult> Send([FromForm] MailRequest request)
        {
            mailService.SendEmailAsync(request);
            return Ok();
        }

    }

    //[ApiController]
    //[Route("[controller]")]
    //public class EmailController : ControllerBase
    //{

    //    private readonly IMailService mailService;
    //    public EmailController(IMailService mailService)
    //    {
    //        this.mailService = mailService;
    //    }

    //    [HttpPost("Send")]
    //    public async Task<IActionResult> Send([FromForm] MailRequest request)
    //    {
    //        try
    //        {
    //            await mailService.SendEmailAsync(request);
    //            return Ok();
    //        }
    //        catch (Exception ex)
    //        {

    //            throw ex;
    //        }

    //    }

    //    private static readonly string[] Summaries = new[]
    //    {
    //            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //    };

    //    private readonly ILogger<EmailController> _logger;

    //    public EmailController(ILogger<EmailController> logger)
    //    {
    //        _logger = logger;
    //    }

    //    [HttpGet(Name = "GetWeatherForecast")]
    //    public IEnumerable<WeatherForecast> Get()
    //    {
    //        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //        {
    //            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
    //            TemperatureC = Random.Shared.Next(-20, 55),
    //            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
    //        }).ToArray();
    //    }
    //}
}
