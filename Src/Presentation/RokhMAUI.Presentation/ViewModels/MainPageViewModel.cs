using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RokhMAUI.Framework.DTOs.Auth;
using RokhMAUI.Framework.Request;
using RokhMAUI.Presentation.Views;

namespace RokhMAUI.Presentation.ViewModels
{
	public partial class MainPageViewModel : ObservableObject
	{
		private readonly RccReuqest _rccReuqest;
		private readonly ErpRequest _erpRequest;


		[ObservableProperty]
		private string mobile;

		public MainPageViewModel(RccReuqest rccReuqest, ErpRequest erpRequest)
		{
			_rccReuqest = rccReuqest;
			_erpRequest = erpRequest;
		}

		[RelayCommand]
		public async Task Login()
		{
			var result = await _erpRequest.Login(new LoginDto { Mobile = mobile });
			if (result.Success)
			{
				await Shell.Current.GoToAsync($"{nameof(VerificationCodePage)}?MobileNumber={mobile}");
			}
			await App.Current.MainPage.DisplayAlert("Message", result.Message, "OK");
		}


		public async Task LoginToAgentDesktop()
		{
			await _erpRequest.LoginAgentDesktop();
		}
	}
}
