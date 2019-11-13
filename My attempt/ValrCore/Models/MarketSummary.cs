using ValrCore.Models;
public class MarketSummary{
    public market[] MarketSummary {get;}
}

public class CurrencySummary{
    public market CurrencySummary {get;set;}
}

public class market {
    public CurrencyPairs symbol {get;} 
    public OrderBook askPrice {get;}
    public OrderBook bidPrice {get;}
    public float lastTradedPrice {get;}
    public float previousClosePrice {get;}
    public float baseVolume {get;}
    public CurrencyPair highPrice {get;}
    public CurrencyPair lowPrice {get;}
    public TimestampedDictionary created {get;}
    public float changeFromPrevious {get;set;}
   
}