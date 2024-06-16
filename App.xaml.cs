using FusionCalculator.Database;
using System.Reflection;

namespace FusionCalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }
    }
}
