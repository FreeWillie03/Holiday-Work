using ValrCore.Utils;
using Newtonsoft.Json;

namespace ValrCore.Models
{
    //[JsonConverter(typeof(OrderBookConverter))]
    public class OrderBook
    {
        public Order[] Asks { get; set; }

   
        public Order[] Bids { get; set; }
    }

    [JsonConverter(typeof(JArrayToObjectConverter))]
    public class Order
    {
        public decimal Side { get; set; }

        public decimal Quantity { get; set; }

        public long Price { get; set; }

        public string CurrencyPAir {get;set;}

        public int OrderCount {get;set;}
    }
}