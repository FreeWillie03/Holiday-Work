using ValrCore.Utils;
using Newtonsoft.Json;

namespace ValrCore {
    public List<Currencies> currencies = new List<Currencies>();

    public class Currencies{
        public string Symbol {get; set;}

        public bool isActive {get;set;}

        public string ShortName {get;set;}

        public string LongName {get; set;}
    }
}