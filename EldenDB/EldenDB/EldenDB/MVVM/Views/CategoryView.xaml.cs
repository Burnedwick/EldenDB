namespace EldenDB;

public partial class CategoryView : ContentPage
{
	public CategoryView(CategoryViewVM categoryViewVM)
	{
		InitializeComponent();
		this.BindingContext = categoryViewVM;
	}
}