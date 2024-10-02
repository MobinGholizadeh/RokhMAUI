using RokhMAUI.Framework.Request;
using RokhMAUI.Presentation.ViewModels;

namespace RokhMAUI.Presentation.Views;

public partial class VerificationCode : ContentPage
{
	private ErpRequest _erpRequest;

	public VerificationCode(VerificationCodeVM vm)
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

	private void Entry_TextChanged(object sender, TextChangedEventArgs e)
	{
		var currentEntry = sender as Entry;

		if (currentEntry.Text.Length == 1)
		{
			MoveFocusToNextEntry(currentEntry);
		}
		else if (string.IsNullOrEmpty(currentEntry.Text))
		{
			MoveFocusToPreviousEntry(currentEntry);
		}
	}


	private void MoveFocusToNextEntry(Entry currentEntry)
	{
		if (currentEntry == Digit1) Digit2.Focus();
		else if (currentEntry == Digit2) Digit3.Focus();
		else if (currentEntry == Digit3) Digit4.Focus();
		else if (currentEntry == Digit4) Digit5.Focus();
		else if (currentEntry == Digit5) Digit6.Focus();
	}

	private void MoveFocusToPreviousEntry(Entry currentEntry)
	{
		if (currentEntry == Digit2 && string.IsNullOrEmpty(Digit2.Text)) Digit1.Focus();
		else if (currentEntry == Digit3 && string.IsNullOrEmpty(Digit3.Text)) Digit2.Focus();
		else if (currentEntry == Digit4 && string.IsNullOrEmpty(Digit4.Text)) Digit3.Focus();
		else if (currentEntry == Digit5 && string.IsNullOrEmpty(Digit5.Text)) Digit4.Focus();
		else if (currentEntry == Digit6 && string.IsNullOrEmpty(Digit6.Text)) Digit5.Focus();
	}
}