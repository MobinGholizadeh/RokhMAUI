using RokhMAUI.Framework.Request;
using RokhMAUI.Presentation.ViewModels;

namespace RokhMAUI.Presentation.Views;

public partial class PersonPostPage : ContentPage
{
	private ErpRequest _erpRequest;
	public PersonPostPage(PersonPostViewModel vm)
	{
		InitializeComponent();
		HandlerChanged += OnHandlerChanged;
		BindingContext = vm;
	}
	void OnHandlerChanged(object sender, EventArgs e)
	{
		if (Handler?.MauiContext?.Services != null)
		{
			_erpRequest = Handler.MauiContext.Services.GetService<ErpRequest>();
		}
		else
		{
			System.Diagnostics.Debug.WriteLine("Services not available.");
		}
	}
}
