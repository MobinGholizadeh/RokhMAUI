using RokhMAUI.Presentation.Views;

namespace RokhMAUI.Presentation
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(VerificationCodePage), typeof(VerificationCodePage));
		}
	}
}
