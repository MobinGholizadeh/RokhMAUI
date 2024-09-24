using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace RokhMAUI.Presentation.ViewModels
{
	[QueryProperty("mobile", "mobile")]
	public partial class VerificationCodeViewModel : ObservableObject
	{
		[ObservableProperty]
		string code;

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


		[RelayCommand]
		void CheckVerificatoinCode()
		{

		}
	}
}
