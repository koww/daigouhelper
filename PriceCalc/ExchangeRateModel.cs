using System;

namespace PriceCalc
{
    public class Rates
    {
        public double CNY { get; set; }
    }

    public class ExchangeRateObject
    {
        public string @base { get; set; }
        public string date { get; set; }
        public Rates rates { get; set; }
    }
}
