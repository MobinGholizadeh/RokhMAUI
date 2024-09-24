using RokhMAUI.Presentation.ViewModels;

namespace RokhMAUI.Presentation.Views;

public partial class VerificationCodePage : ContentPage
{
	public VerificationCodePage(VerificationCodeViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}

	private void Entry_TextChanged(object sender, TextChangedEventArgs e)
	{
		var currentEntry = sender as Entry;

		if (currentEntry.Text.Length == 1) // Move to next Entry if a character is entered
		{
			MoveFocusToNextEntry(currentEntry);
		}
		else if (string.IsNullOrEmpty(currentEntry.Text)) // Move to previous Entry if deleted
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