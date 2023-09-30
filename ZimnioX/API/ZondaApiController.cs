using System.Text.Json;
using ZimnioX.Models.Zonda;

namespace ZimnioXApi.Controllers
{
	public class ZondaApiController
	{
		private HttpClient _client;
		private const string ZondaApiUrl = "https://api.zondacrypto.exchange/rest/trading/ticker/";

        public ZondaApiController()
		{
			_client = new HttpClient();
		}

		public async Task<ZondaTicker> GetZondaCryptoRate(Currencies.Crypto cryptoCurrency,
			Currencies.BaseCurrencies currency)
		{
			var response = await _client.GetAsync(ZondaApiUrl + cryptoCurrency.ToString()
				+ "-"
				+ currency.ToString());

			response.EnsureSuccessStatusCode();

			var responseBody = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ZondaTicker>(responseBody);
		}
	}
}

