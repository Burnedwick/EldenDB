namespace EldenDB;

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
			});
		builder.Services.AddSingleton<DBService>();
		builder.Services.AddSingleton<DBData>();
		//Counter page
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<MainPageVM>();

		builder.Services.AddTransient<DBMainPage>();
		builder.Services.AddTransient<DBMainPageVM>();

		builder.Services.AddTransient<WeaponCategories>();
		builder.Services.AddTransient<WeaponCategoriesVM>();

		builder.Services.AddTransient<WeaponDetailView>();
		builder.Services.AddTransient<WeaponDetailVM>();

		builder.Services.AddTransient<CategoryView>();
		builder.Services.AddTransient<CategoryViewVM>();

		return builder.Build();
	}
}
