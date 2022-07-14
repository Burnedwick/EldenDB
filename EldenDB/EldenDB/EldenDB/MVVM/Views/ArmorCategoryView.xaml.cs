namespace EldenDB;

public partial class ArmorCategoryView : ContentPage
{
	public ArmorCategoryView(ArmorCategoryViewVM categoryViewVM)
	{
		InitializeComponent();
		this.BindingContext = categoryViewVM;
	}
}