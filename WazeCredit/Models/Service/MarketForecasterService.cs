namespace WazeCredit.Models.Service
{
    public class MarketForecasterService : IMarketForecasterService
    {
        public MarketResult GertMarketPrediction()
        {
            return new MarketResult
            {
                MarketCondition = MarketCondition.StableUp
            };
        }
    }
}
