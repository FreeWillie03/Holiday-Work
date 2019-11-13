using ValrCore.Utils;
using Newtonsoft.Json;

namespace ValrCore {
    public class OrderTypes{
         public OrderType[] OrderTypes {get;set;}
    }

// Not sure about this one.
    public class OrderTypesCurrencyPair{
        public OrderType[] OrderTypes {get;set;}
    }
    public class OrderType{
      public string post_only_limit {get;set;}
      public string limit {get;set;}
      public string market{get;set;}
      public string simple{get;set;}
    }
}