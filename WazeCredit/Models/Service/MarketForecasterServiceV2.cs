namespace WazeCredit.Models.Service
{
    public class MarketForecasterServiceV2 : IMarketForecasterService
    {
        public MarketResult GertMarketPrediction()
        {
            return new MarketResult
            {
                MarketCondition = MarketCondition.StableDown
            };
        }
    }
}
