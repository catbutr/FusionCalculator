using FusionCalculator.Database;
using FusionCalculator.ViewModels;

namespace FusionCalculator;

public partial class SkillListPage : ContentPage
{
	public SkillListPage()
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