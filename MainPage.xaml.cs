using FusionCalculator.Database;
using FusionCalculator.Utils;

namespace FusionCalculator
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            await ResourceFilesUtils.CopyFileToAppDataDirectory("fusiondata.db");
            await Navigation.PushAsync(new DemonListPage(), true);
        }

        private async void OnSkillButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SkillListPage(), true);
        }
    }

}
