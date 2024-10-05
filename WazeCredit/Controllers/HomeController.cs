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
        private readonly IMarketForecasterService _marketForecasterService;
        private readonly StripeSettings _stripeOptions;
        private readonly SendGridSettings _sendGridOptions;
        private readonly TwilioSettings _twilioOptions;
        private readonly WazeForeCastSettings _wazeForeCastOptions;
        public HomeController(IMarketForecasterService marketForecasterService,
            IOptions<StripeSettings> stripeOptions,
            IOptions<SendGridSettings> sendGridOptions,
            IOptions<TwilioSettings> twilioOptions,
            IOptions<WazeForeCastSettings> wazeForeCastOptions)
        {
            homeMV = new HomeMV();
            _marketForecasterService = marketForecasterService;
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
