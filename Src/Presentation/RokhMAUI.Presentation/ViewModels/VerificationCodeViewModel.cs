using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RokhMAUI.Framework.Request;
using RokhMAUI.Presentation.Views;
using System.Text.Json;

namespace RokhMAUI.Presentation.ViewModels
{
	[QueryProperty("Mobile", "MobileNumber")]
	public partial class VerificationCodeViewModel : ObservableObject
	{
		private readonly ErpRequest _erpRequest;

		[ObservableProperty]
		string mobile;

		[ObservableProperty]
		private string digit1;

		[ObservableProperty]
		private string digit2;

		[ObservableProperty]
		private string digit3;

		[ObservableProperty]
		private string digit4;

		[ObservableProperty]
		private string digit5;

		[ObservableProperty]
		private string digit6;

		public VerificationCodeViewModel(ErpRequest erpRequest)
		{
			_erpRequest = erpRequest;
		}

		[RelayCommand]
		async void CheckVerificatoinCode()
		{
			var code = digit1 + digit2 + digit3 + digit4 + digit5 + digit6;
			if (!string.IsNullOrWhiteSpace(code))
			{
				var dto = new Framework.DTOs.Auth.LoginDto
				{
					Mobile = mobile,
					VerifyCode = code
				};
				var result = await _erpRequest.VerifyCode(dto);
				if (result.HasPersonPost)
				{
					var serializedItems = JsonSerializer.Serialize(result.Data);
					await Shell.Current.GoToAsync($"{nameof(PersonPostPage)}?serializedPersonPosts={serializedItems}");
				}
				await App.Current.MainPage.DisplayAlert("Message", result.Message, "OK");
			}
		}
	}
}
