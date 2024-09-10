using RokhMAUI.Framework.DTOs.Auth;
using RokhMAUI.Framework.Request;

namespace RokhMAUI.Presentation
{
	public partial class MainPage : ContentPage
	{
		private RccReuqest _rccReuqest;
		private ErpRequest _erpRequest;
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

		private async void OnCounterClicked(object sender, EventArgs e)
		{
			await _erpRequest.Login(new LoginDto()
			{
				UserName = "admin",
				Password = "admin12345"
			});
			await _erpRequest.LoginAgentDesktop();

			SemanticScreenReader.Announce(CounterBtn.Text);
		}
	}

}
