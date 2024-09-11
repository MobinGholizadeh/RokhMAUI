using RokhMAUI.Framework.DTOs.Auth;
using RokhMAUI.Framework.Request;

namespace RokhMAUI.Presentation
{
	public partial class MainPage : ContentPage
	{
		private RccReuqest _rccReuqest;
		private ErpRequest _erpRequest;

		private string Mobile;
		public MainPage()
		{
			InitializeComponent();
			HandlerChanged += OnHandlerChanged;
		}

		void OnHandlerChanged(object sender, EventArgs e)
		{
			_rccReuqest = Handler.MauiContext.Services.GetService<RccReuqest>();
			_erpRequest = Handler.MauiContext.Services.GetService<ErpRequest>();
		}
		void OnMobileChanged(object sender, TextChangedEventArgs e)
		{
			Mobile = e.NewTextValue;
		}
		private async void OnCounterClicked(object sender , EventArgs e)
		{
			var tt = await _erpRequest.Login(new LoginDto()
			{
				Mobile = Mobile
			});
			await DisplayAlert("پیغام", tt.Message, "OK");

			await _erpRequest.LoginAgentDesktop();

			SemanticScreenReader.Announce(CounterBtn.Text);
		}
	}

}
