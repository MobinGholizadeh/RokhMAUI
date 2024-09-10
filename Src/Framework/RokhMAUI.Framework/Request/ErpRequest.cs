using RokhMAUI.Framework.Configuration;
using RokhMAUI.Framework.Configuration.Interface;
using RokhMAUI.Framework.DTOs.Auth;
using RokhMAUI.Framework.DTOs.Auth.Rcc;
using RokhMAUI.Framework.Extensions;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace RokhMAUI.Framework.Request
{
	public class ErpRequest
	{
		private readonly HttpClient _client;
		private readonly ISecureStorageService _secureStorageService;
		public ErpRequest(HttpClient httpClient, ISecureStorageService secureStorageService)
		{
			_client = httpClient;
			_client.BaseAddress = new Uri(RokhConfig.ErpBaseUrl);
			_client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("fa"));
			_secureStorageService = secureStorageService;
		}
		public async Task Login(LoginDto dto)
		{
			var data = new StringContent(dto.ToJson(), Encoding.UTF8, "application/json");
			var request = await _client.PostAsync("/api/v1/im/login", data);
			if (request.IsSuccessStatusCode)
			{
				var response = await request.Content.ReadFromJsonAsync<AutheneticateResponseDto>();
				await _secureStorageService.SetValueAsync("token", response.AccessToken.Token);
				await _secureStorageService.SetValueAsync("fullName", response.fullName);
			}
		}

		public async Task LoginAgentDesktop()
		{
			await SetToken();
			var request = await _client.PostAsync("/api/v1/cm/agentdesktop/login", null);
			if (request.IsSuccessStatusCode)
			{
				var response = await request.Content.ReadFromJsonAsync<AgentLoginDto>();
				await _secureStorageService.SetValueAsync("rcc-token", response.Authorization);
			}
		}

		private async Task SetToken()
		{
			var token = await _secureStorageService.GetValueAsync("token");
			if (token == null)
				throw new Exception("token is empty");
			_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
		}
	}
}
