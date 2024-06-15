using FusionCalculator.ViewModels;

namespace FusionCalculator;

public partial class DemonPage : ContentPage
{
	public DemonPage(DemonVM demonVM)
	{
		InitializeComponent();
		BindingContext = demonVM;
	}
}