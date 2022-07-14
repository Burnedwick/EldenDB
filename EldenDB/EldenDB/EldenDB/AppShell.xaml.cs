namespace EldenDB;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		//this.FlyoutBehavior = FlyoutBehavior.Flyout;
		//Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(WeaponCategories), typeof(WeaponCategories));
		Routing.RegisterRoute(nameof(WeaponDetailView), typeof(WeaponDetailView));
		Routing.RegisterRoute(nameof(CategoryView), typeof(CategoryView));
		Routing.RegisterRoute(nameof(ArmorCategories), typeof(ArmorCategories));
		Routing.RegisterRoute(nameof(ArmorCategoryView), typeof(ArmorCategoryView));
	}
}