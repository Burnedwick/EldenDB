namespace EldenDB;

public partial class WeaponDetailView : ContentPage
{
	public WeaponDetailView(WeaponDetailVM weaponDetailVM)
	{
		InitializeComponent();
		this.BindingContext = weaponDetailVM;
	}
}