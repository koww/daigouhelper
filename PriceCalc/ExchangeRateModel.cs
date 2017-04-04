using System;
using System.Runtime.Serialization;

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
}
