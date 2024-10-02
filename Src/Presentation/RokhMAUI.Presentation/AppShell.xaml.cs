using RokhMAUI.Presentation.Views;

namespace RokhMAUI.Presentation
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(VerificationCode), typeof(VerificationCode));
			Routing.RegisterRoute(nameof(PersonPost), typeof(PersonPost));
			Routing.RegisterRoute(nameof(UserChats), typeof(UserChats));


		}
	}
}
