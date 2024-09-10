using RokhMAUI.Framework.Configuration;
using RokhMAUI.Framework.Configuration.Interface;
namespace RokhMAUI.Framework.Request
{
	public class RccReuqest
	{
		private readonly HttpClient _client;
		private readonly ISecureStorageService _secureStorageService;
		public RccReuqest(HttpClient httpClient,ISecureStorageService secureStorageService)
		{
			_client = httpClient;
			_client.BaseAddress = new Uri(RokhConfig.RccBaseUrl);
			_secureStorageService = secureStorageService;
		}
	}
}
