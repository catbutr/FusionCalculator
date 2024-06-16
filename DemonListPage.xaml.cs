using FusionCalculator.Database;
using FusionCalculator.Resources.Constants;
using FusionCalculator.ViewModels;
using Maui.DataGrid;
using System.Reflection;
using System.Reflection.Metadata;
namespace FusionCalculator;

public partial class DemonListPage : ContentPage
{
    public DemonListPage()
    {
        InitializeComponent();
        //var assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
        //using (Stream stream = assembly.GetManifestResourceStream("FusionData.db"))
        //{
        //    using (MemoryStream memoryStream=new MemoryStream())
        //    {
        //        stream.CopyTo(memoryStream);
        //        File.WriteAllBytes(Constants.DatabasePath, memoryStream.ToArray());
        //    }
        //}
        var newVM = new DemonListVM();
        BindingContext = newVM;
    }

    private async void OnCounterClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OpenDemonPage(object sender, EventArgs e)
    {
        var button = sender as Button;
        var DataGrid = FindByName("DataGrid") as DataGrid;
        var items = DataGrid.ItemsSource as List<DemonVM>;
        DataGrid.SelectedItem = items.Single(n => n.demonName == button.Text);
        await Navigation.PushAsync(new DemonPage((DemonVM)DataGrid.SelectedItem), true);
    }
}