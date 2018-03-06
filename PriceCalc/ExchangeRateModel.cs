using System;
using System.Runtime;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Net;

namespace PriceCalc
{
    [DataContract]
    public class Rates
    {
        [DataMember]
        public double CNY { get; set; }
    }

    [DataContract]
    public class ExchangeRateObject
    {
        [DataMember]
        public string @base { get; set; }

        [DataMember]
        public string date { get; set; }

        [DataMember]
        public Rates rates { get; set; }
    }

    public static class ExchangeRateManager{
        private const double defaultRate = 6.7;
        private const string apiEndpoint = "http://api.fixer.io/latest?base=USD&symbols=CNY";
        public static double GetExchangeRate(bool useDefault = false){
            if(useDefault){
                return defaultRate;
            }else{
                using (var client = new WebClient())
                {
                    var jsonStr = client.DownloadString(apiEndpoint);
                    ExchangeRateObject obj = JsonConvert.DeserializeObject<ExchangeRateObject>(jsonStr);
                    return obj == null ? defaultRate : obj.rates.CNY;
                }
            }
        }
    }
}
