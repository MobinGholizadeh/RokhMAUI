using Microsoft.Extensions.Logging;
using RokhMAUI.Framework.Configuration.Interface;
using RokhMAUI.Framework.Request;
using RokhMAUI.Presentation.Storage;

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
#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
