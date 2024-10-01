using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using RokhMAUI.Framework.Configuration.Interface;
using RokhMAUI.Framework.Request;
using RokhMAUI.Presentation.Storage;
using RokhMAUI.Presentation.ViewModels;
using RokhMAUI.Presentation.Views;
#if WINDOWS
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
#endif


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


			//I made these settings down below to make windows to run in Fullscreen mode on startup
#if WINDOWS
        builder.ConfigureLifecycleEvents(events =>
        {
            events.AddWindows(wndLifeCycleBuilder =>
            {
                wndLifeCycleBuilder.OnWindowCreated(window =>
                {
                    IntPtr nativeWindowHandle = WinRT.Interop.WindowNative.GetWindowHandle(window);
                    WindowId win32WindowsId = Win32Interop.GetWindowIdFromWindow(nativeWindowHandle);
                    AppWindow winuiAppWindow = AppWindow.GetFromWindowId(win32WindowsId);
                    if(winuiAppWindow.Presenter is OverlappedPresenter p)
                        p.Maximize();
                    else
                    {
                        const int width = 1200;
                        const int height = 800;
                        winuiAppWindow.MoveAndResize(new RectInt32(1920 / 2 - width / 2, 1080 / 2 - height / 2, width, height));
                    }
                });
            });
        });
#endif

			builder.Services.AddScoped(_ => new HttpClient());
			builder.Services.AddTransient<ISecureStorageService, SecureStorageService>();

			builder.Services.AddSingleton<ErpRequest>();
			builder.Services.AddSingleton<RccReuqest>();

			builder.Services.AddSingleton<MainPage>();
			builder.Services.AddSingleton<MainPageVM>();

			builder.Services.AddScoped<VerificationCode>();
			builder.Services.AddScoped<VerificationCodeVM>();

			builder.Services.AddScoped<PersonPost>();
			builder.Services.AddScoped<PersonPostVM>();

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
