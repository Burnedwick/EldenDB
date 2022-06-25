namespace EldenDB;

public partial class WeaponCategories : ContentPage
{
	public WeaponCategories(WeaponCategoriesVM weaponCategoriesVM)
	{
		InitializeComponent();
		this.BindingContext = weaponCategoriesVM;
	}
}