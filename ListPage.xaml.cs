using FusionCalculator.Database;
using FusionCalculator.Resources.Constants;
using FusionCalculator.ViewModels;
using System.Reflection;
using System.Reflection.Metadata;
namespace FusionCalculator;

public partial class ListPage : ContentPage
{
	public ListPage()
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
}