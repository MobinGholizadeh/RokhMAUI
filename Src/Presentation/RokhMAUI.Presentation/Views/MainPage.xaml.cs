using RokhMAUI.Framework.Request;
using RokhMAUI.Presentation.ViewModels;

namespace RokhMAUI.Presentation
{
	public partial class MainPage : ContentPage
	{
		private RccReuqest _rccReuqest;
		private ErpRequest _erpRequest;

		public MainPage(MainPageViewModel vm)
		{
			InitializeComponent();
			HandlerChanged += OnHandlerChanged;
			BindingContext = vm;
		}

		void OnHandlerChanged(object sender, EventArgs e)
		{
			if (Handler?.MauiContext?.Services != null)
			{
				_rccReuqest = Handler.MauiContext.Services.GetService<RccReuqest>();
				_erpRequest = Handler.MauiContext.Services.GetService<ErpRequest>();
			}
			else
			{
				System.Diagnostics.Debug.WriteLine("Services not available.");
			}
		}
	}
}

