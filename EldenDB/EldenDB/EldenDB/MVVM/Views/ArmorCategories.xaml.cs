namespace EldenDB;

public partial class ArmorCategories : ContentPage
{
	public ArmorCategories(ArmorCategoriesVM armorCategoriesVM)
	{
		InitializeComponent();
		this.BindingContext = armorCategoriesVM;
	}
}