using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RokhMAUI.Framework.Extensions;
using RokhMAUI.Framework.Request;
using RokhMAUI.Presentation.Views;

namespace RokhMAUI.Presentation.ViewModels
{
	[QueryProperty("Mobile", "MobileNumber")]
	public partial class VerificationCodeVM : ObservableObject
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

		public VerificationCodeVM(ErpRequest erpRequest)
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
					var serializedItems = result.Data.ToJson();
					await Shell.Current.GoToAsync($"{nameof(PersonPost)}?serializedPersonPosts={serializedItems}&code={code}&mobile{Mobile}");
					Digit1 = "";
					Digit2 = "";
					Digit3 = "";
					Digit4 = "";
					Digit5 = "";
					Digit6 = "";
				}
				await App.Current.MainPage.DisplayAlert("Message", result.Message, "OK");

			}
		}
	}
}
