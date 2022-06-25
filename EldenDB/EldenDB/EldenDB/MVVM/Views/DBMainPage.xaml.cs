namespace EldenDB;

public partial class DBMainPage : ContentPage
{
	public DBMainPage(DBMainPageVM mainPageVM)
	{
		InitializeComponent();
		this.BindingContext = mainPageVM;
	}
}