using System;

namespace ZimnioX.Models.Zonda
{
    public class Market
    {
        public string Code { get; set; }
        public First First { get; set; }
        public Second Second { get; set; }
        public int AmountPrecision { get; set; }
        public int PricePrecision { get; set; }
        public int RatePrecision { get; set; }
    }
}

