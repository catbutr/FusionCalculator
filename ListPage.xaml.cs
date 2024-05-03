namespace FusionCalculator;

public partial class ListPage : ContentPage
{
	public ListPage()
	{
		InitializeComponent();
	}

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}