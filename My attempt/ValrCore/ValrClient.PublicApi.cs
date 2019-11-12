using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ValrCore
{
    public partial class ValrClient
    {
       
        public Task<ValrResponse<ServerTime>> GetServerTime()
        {
            return QueryPublic<ServerTime>("/0/public/Time");
        }

        
        public Task<ValrResponse<Dictionary<string, AssetInfo>>> GetAssetInfo(
            string info = null,
            string assetClass = null,
            string assets = null)
        {
            return QueryPublic<Dictionary<string, AssetInfo>>(
                "/0/public/Assets",
                new Dictionary<string, string>(3)
                {
                    ["info"] = info,
                    ["aclass"] = assetClass,
                    ["asset"] = assets
                }
            );
        }

              public Task<ValrResponse<Dictionary<string, AssetPair>>> GetTradableAssetPairs(
            string info = null,
            string pairs = null)
        {
            return QueryPublic<Dictionary<string, AssetPair>>(
                "/0/public/AssetPairs",
                new Dictionary<string, string>(2)
                {
                    ["info"] = info,
                    ["pair"] = pairs
                }
            );
        }

  
        public Task<ValrResponse<Dictionary<string, TickerInfo>>> GetTickerInformation(string pairs)
        {
            return QueryPublic<Dictionary<string, TickerInfo>>(
                "/0/public/Ticker",
                new Dictionary<string, string>(1)
                {
                    ["pair"] = pairs
                }
            );
        }

        
        public Task<ValrResponse<TimestampedDictionary<string, Ohlc[]>>> GetOhlcData(string pair, int? interval = null, long? since = null)
        {
            return QueryPublic<TimestampedDictionary<string, Ohlc[]>>(
                "/0/public/OHLC",
                new Dictionary<string, string>(3)
                {
                    ["pair"] = pair,
                    ["interval"] = interval?.ToString(Culture),
                    ["since"] = since?.ToString(Culture)
                }
            );
        }

      
        public Task<ValrResponse<Dictionary<string, OrderBook>>> GetOrderBook(string pair, int? count = null)
        {
            return QueryPublic<Dictionary<string, OrderBook>>(
                "/0/public/Depth",
                new Dictionary<string, string>(2)
                {
                    ["pair"] = pair,
                    ["count"] = count?.ToString(Culture)
                }
            );
        }

             public Task<ValrResponse<TimestampedDictionary<string, Trade[]>>> GetRecentTrades(string pair, long? since = null)
        {
            return QueryPublic<TimestampedDictionary<string, Trade[]>>(
                "/0/public/Trades",
                new Dictionary<string, string>(2)
                {
                    ["pair"] = pair,
                    ["since"] = since?.ToString(Culture)
                }
            );
        }

        public Task<ValrResponse<TimestampedDictionary<string, Spread[]>>> GetRecentSpreadData(string pair, long? since = null)
        {
            return QueryPublic<TimestampedDictionary<string, Spread[]>>(
                "/0/public/Spread",
                new Dictionary<string, string>(2)
                {
                    ["pair"] = pair,
                    ["since"] = since?.ToString(Culture)
                }
            );
        }
    }
}
