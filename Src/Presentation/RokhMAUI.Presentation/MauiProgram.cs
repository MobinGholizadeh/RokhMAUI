using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using RokhMAUI.Framework.Configuration.Interface;
using RokhMAUI.Framework.Request;
using RokhMAUI.Presentation.Storage;
using RokhMAUI.Presentation.ViewModels;
using RokhMAUI.Presentation.Views;

namespace RokhMAUI.Presentation
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});
			builder.Services.AddScoped(_ => new HttpClient());
			builder.Services.AddTransient<ISecureStorageService, SecureStorageService>();
			builder.Services.AddSingleton<ErpRequest>();
			builder.Services.AddSingleton<RccReuqest>();

			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddSingleton<MainPageViewModel>();

			builder.Services.AddSingleton<VerificationCodePage>();
			builder.Services.AddSingleton<VerificationCodeViewModel>();


			builder.ConfigureLifecycleEvents(events =>
			{
#if ANDROID
				events.AddAndroid(android => android.OnCreate((activity, bundle) => MakeStatusBarTranslucent(activity)));

				static void MakeStatusBarTranslucent(Android.App.Activity activity)
				{
					activity.Window.SetFlags(Android.Views.WindowManagerFlags.LayoutNoLimits, Android.Views.WindowManagerFlags.LayoutNoLimits);

					activity.Window.ClearFlags(Android.Views.WindowManagerFlags.TranslucentStatus);

					activity.Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
				}
#endif
			});

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
