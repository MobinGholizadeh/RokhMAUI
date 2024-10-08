﻿using RokhMAUI.Framework.Configuration;
using RokhMAUI.Framework.Configuration.Interface;
using RokhMAUI.Framework.DTOs;
using RokhMAUI.Framework.DTOs.Auth;
using RokhMAUI.Framework.DTOs.Auth.Rcc;
using RokhMAUI.Framework.DTOs.PersonPost;
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
		public async Task<ApiReponseDto> Login(LoginDto dto)
		{
			var data = new StringContent(dto.ToJson(), Encoding.UTF8, "application/json");
			var request = await _client.PostAsync("/api/v1/im/login/loginMobile", data);
			if (request.IsSuccessStatusCode)
			{
				var response = await request.Content.ReadFromJsonAsync<MobileAuthDto>();
				return new ApiReponseDto(response.Success, response.Message);
			}
			return new ApiReponseDto(false, "مشکلی در ارتباط با سرور وجود دارد");
		}

		public async Task<ApiReponseDto<List<PersonPostDto>>> VerifyCode(LoginDto dto)
		{
			var data = new StringContent(dto.ToJson(), Encoding.UTF8, "application/json");
			var request = await _client.PostAsync("/api/v1/im/login/verifyCode", data);
			if (request.IsSuccessStatusCode)
			{
				var response = await request.Content.ReadFromJsonAsync<AutheneticateResponseDto>();

				if (response.Items == null && !response.Success)
					return new ApiReponseDto<List<PersonPostDto>>(false, "کد تایید نامعتبر است");
				if (response.Items != null && response.Items.Any()) return new ApiReponseDto<List<PersonPostDto>>(true, "", true, response.Items);

				if (string.IsNullOrEmpty(response.AccessToken.Token)) return new ApiReponseDto<List<PersonPostDto>>(false, "کد تایید نامعتبر است");
				await _secureStorageService.SetValueAsync("token", response.AccessToken.Token);
				return new ApiReponseDto<List<PersonPostDto>>(response.Success, response.Message);
			}
			return new ApiReponseDto<List<PersonPostDto>>(false, "کد تایید نامعتبر است");
		}



		public async Task<ApiReponseDto> LoginAgentDesktop()
		{
			await SetToken();
			var request = await _client.PostAsync("/api/v1/cm/agentdesktop/login", null);
			if (request.IsSuccessStatusCode)
			{
				var response = await request.Content.ReadFromJsonAsync<AgentLoginDto>();
				if (response != null && !string.IsNullOrWhiteSpace(response.Authorization))
				{
					await _secureStorageService.SetValueAsync("rcc-token", response.Authorization);
					return new ApiReponseDto(true, "با موفقیت وارد شدید");
				}
				return new ApiReponseDto(false, "مشکلی در ارتباط با سرور وجود دارد");
			}
			return new ApiReponseDto(false, "مشکلی در ارتباط با سرور وجود دارد");
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
