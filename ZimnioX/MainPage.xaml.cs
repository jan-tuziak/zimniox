using CommunityToolkit.Maui.Views;
using System.ComponentModel;

namespace ZimnioX
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void AddCustomControl_Clicked(object sender, EventArgs e)
        {           
            var listOfCryptoAssets = container.Children.OfType<ListOfCryptoAssets>().FirstOrDefault();
            listOfCryptoAssets.AddNewCryptoAsset();
        }

        private void GeneratePdf(object sender, EventArgs e)
        {

        }

        private void OpenSettings(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings());
        }
    }
}