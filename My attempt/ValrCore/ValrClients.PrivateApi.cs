using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
// using KrakenCore.Models;

namespace ValrCore{
    public partial class ValrClient{
        public Task<ValrCore<Dictionary<string, decimal>>> GetAccountBalance(){
            return QueryPrivate<Dictionary<string, decimal>>("/0/private/Balance");
        }

        public Task<ValrResponse<TradeBalanceInfo>> GetTradeBalance(string assetClass = null, string asset = ""){ //Asset is the currency
            return QueryPrivate<TradeBalanceInfo>("/0/private/TradeBalance", new Dictionary<string,string> (2 + AdditionalPrivateQueryArgs){
                ["aclass"] = assetClass, ["asset"] = asset
            });
        }

        public Task<ValrResponse<OpenOrders>> GetOpenOrders(bool includeTrades = false, string userRef = null)
        {
            return QueryPrivate<OpenOrders>(
                "/0/private/OpenOrders",
                new Dictionary<string, string>(2 + AdditionalPrivateQueryArgs)
                {
                    ["trades"] = includeTrades ? "true" : null,
                    ["userref"] = userRef
                }
            );
        }

         public Task<ValrResponse<ClosedOrders>> GetClosedOrders(
            bool includeTrades = false,
            string userRef = null,
            long? start = null,
            long? end = null,
            int? offset = null,
            string closeTime = null)
        {
            return QueryPrivate<ClosedOrders>(
                "/0/private/ClosedOrders",
                new Dictionary<string, string>(6 + AdditionalPrivateQueryArgs)
                {
                    ["trades"] = includeTrades ? "true" : null,
                    ["userref"] = userRef,
                    ["start"] = start?.ToString(Culture),
                    ["end"] = end?.ToString(Culture),
                    ["ofs"] = offset?.ToString(Culture),
                    ["closetime"] = closeTime
                }
            );
        }

         public Task<ValrResponse<Dictionary<string, OrderInfo>>> QueryOrdersInfo(
            string transactionIds,
            bool includeTrades = false,
            string userRef = null)
        {
            return QueryPrivate<Dictionary<string, OrderInfo>>(
                "/0/private/QueryOrders",
                new Dictionary<string, string>(3 + AdditionalPrivateQueryArgs)
                {
                    ["trades"] = includeTrades ? "true" : null,
                    ["userref"] = userRef,
                    ["txid"] = transactionIds
                }
            );
        }

        public Task<ValrResponse<TradesHistory>> GetTradesHistory(
            string type = null,
            bool includeTrades = false,
            long? start = null,
            long? end = null,
            int? offset = null)
        {
            return QueryPrivate<TradesHistory>(
                "/0/private/TradesHistory",
                new Dictionary<string, string>(5 + AdditionalPrivateQueryArgs)
                {
                    ["type"] = type,
                    ["trades"] = includeTrades ? "true" : null,
                    ["start"] = start?.ToString(Culture),
                    ["end"] = end?.ToString(Culture),
                    ["ofs"] = offset?.ToString(Culture)
                },
                2
            );
        }

        public Task<ValrResponse<Dictionary<string, PositionInfo>>> GetOpenPositions(
            string transactionIds,
            bool doCalculations = false)
        {
            return QueryPrivate<Dictionary<string, PositionInfo>>(
                "/0/private/OpenPositions",
                new Dictionary<string, string>(2 + AdditionalPrivateQueryArgs)
                {
                    ["txid"] = transactionIds,
                    ["docalcs"] = doCalculations ? "true" : null
                }
            );
        }

        public Task<ValrResponse<LedgersInfo>> GetLedgersInfo(
            string assetClass = null,
            string assets = null,
            string type = null,
            string start = null,
            string end = null,
            string offset = null)
        {
            return QueryPrivate<LedgersInfo>(
                "/0/private/Ledgers",
                new Dictionary<string, string>(6 + AdditionalPrivateQueryArgs)
                {
                    ["aclass"] = assetClass,
                    ["asset"] = assets,
                    ["type"] = type,
                    ["start"] = start,
                    ["end"] = end,
                    ["ofs"] = offset
                },
                2
            );
        }

         public Task<ValrResponse<Dictionary<string, LedgerInfo>>> QueryLedgers(string ids)
        {
            return QueryPrivate<Dictionary<string, LedgerInfo>>(
                "/0/private/QueryLedgers",
                new Dictionary<string, string>(1 + AdditionalPrivateQueryArgs)
                {
                    ["id"] = ids
                }
            );
        }

         public Task<ValrResponse<TradeVolume>> GetTradeVolume(string pair = null, bool includeFeeInfo = false)
        {
            return QueryPrivate<TradeVolume>(
                "/0/private/TradeVolume",
                new Dictionary<string, string>(2 + AdditionalPrivateQueryArgs)
                {
                    ["pair"] = pair,
                    ["fee-info"] = includeFeeInfo ? "true" : null
                }
            );
        }

         public Task<ValrResponse<AddOrderResult>> AddStandardOrder(
            string pair,
            string type,
            string orderType,
            decimal volume,
            decimal? price = null,
            decimal? price2 = null,
            string leverage = null,
            string orderFlags = null,
            string startTime = null,
            string expireTime = null,
            string userRef = null,
            bool validate = false)
        {
            return QueryPrivate<AddOrderResult>(
                "/0/private/AddOrder",
                new Dictionary<string, string>(12 + AdditionalPrivateQueryArgs)
                {
                    ["pair"] = pair,
                    ["type"] = type,
                    ["ordertype"] = orderType,
                    ["price"] = price?.ToString(Culture),
                    ["price2"] = price2?.ToString(Culture),
                    ["volume"] = volume.ToString(Culture),
                    ["leverage"] = leverage,
                    ["oflags"] = orderFlags,
                    ["starttm"] = startTime,
                    ["expiretm"] = expireTime,
                    ["userref"] = userRef,
                    ["validate"] = validate ? "true" : null
                },
                0
            );
        }

          public Task<ValrResponse<CancelOrderResult>> CancelOpenOrder(string transactionId)
        {
            return QueryPrivate<CancelOrderResult>(
                "/0/private/CancelOrder",
                new Dictionary<string, string>(1 + AdditionalPrivateQueryArgs)
                {
                    ["txid"] = transactionId
                },
                0
            );
        }

    }
}