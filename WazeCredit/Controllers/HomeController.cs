using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using WazeCredit.Models;
using WazeCredit.Models.Service;
using WazeCredit.Models.ViewModel;
using WazeCredit.Utility.AppSettingsClasses;

namespace WazeCredit.Controllers
{
    public class HomeController : Controller
    {
        public HomeMV homeMV;
        public AppSettingsMV appSettingsMV;
        private readonly IMarketForecasterService _marketForecasterService;
        private readonly SendGridSettings _sendGridOptions;
        private readonly TwilioSettings _twilioOptions;
        public HomeController(IMarketForecasterService marketForecasterService,
            
            IOptions<SendGridSettings> sendGridOptions,
            IOptions<TwilioSettings> twilioOptions)
        {
            homeMV = new HomeMV();
            appSettingsMV = new AppSettingsMV();
            _marketForecasterService = marketForecasterService;
            _sendGridOptions = sendGridOptions.Value;
            _twilioOptions = twilioOptions.Value;
            

        }

        public IActionResult Index()
        {
            //MarketForecasterService marketForecasterSvc = new MarketForecasterService();
            var marketResult = _marketForecasterService.GertMarketPrediction();

            switch (marketResult.MarketCondition)
            {
                case MarketCondition.StableUp:
                    homeMV.MarketForecast = "Market is stable";
                    break;
                case MarketCondition.StableDown:
                    homeMV.MarketForecast = "Market is not stable";
                    break;
                case MarketCondition.Volatile:
                    homeMV.MarketForecast = "Market is volatile";
                    break;
                default:
                    homeMV.MarketForecast = "Market conditions are unknown";
                    break;


            }

            return View(homeMV);
        }

        public IActionResult AllConfigurations([FromServices] IOptions<WazeForeCastSettings> wazeForeCastOptions, [FromServices] IOptions<StripeSettings> stripeOptions)
        {
            List<string> messages = new List<string>();
            messages.Add($"Waze Forecast Setting - Forecast Tracker: "+wazeForeCastOptions.Value.ForecastTrackerEnabled.ToString());
            messages.Add($"Stripe Setting - Publish key: "+stripeOptions.Value.PublishableKey.ToString());
            messages.Add($"Stripe Setting - Secret key: "+stripeOptions.Value.SecretKey.ToString());
            
            appSettingsMV.AppSettingsMessages = messages;

            return View(appSettingsMV);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
