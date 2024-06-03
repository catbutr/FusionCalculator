using FusionCalculator.Database;

namespace FusionCalculator;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
        var newVM = new FusionDatabaseRepository();
        BindingContext = newVM;
	}

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}