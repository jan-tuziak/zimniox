using Newtonsoft.Json;

namespace ZimnioX.Models
{
    public class CryptoName

    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("short")]
        public string Short{ get; set; }
    }
}