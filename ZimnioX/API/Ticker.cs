using System;
namespace ZimnioX.Models.Zonda
{
	public class Ticker
	{
        public Market Market { get; set; }
        public string Time { get; set; }
        public string HighestBid { get; set; }
        public string LowestAsk { get; set; }
        public string Rate { get; set; }
        public string PreviousRate { get; set; }
    }
}

