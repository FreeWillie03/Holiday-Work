using ValrCore.Utils;
using Newtonsoft.Json;

namespace ValrCore {
    public class CurrencyPair{
         public CurrencyPair[] currenciePairs {get;set;}
    }
   

    public class CurrencyPair{
        public string Symbol {get; set;}
        public string BaseCurrency {get; set;}
        public string QuoteCurrency {get; set;}
        public string ShortName {get;set;}
        public bool Active {get;set;}
        public float MinBaseAmount {get; set;}
        public int MaxBaseAmount {get;set;}
        public int MinQuoteAmount {get;set;}
    }
}