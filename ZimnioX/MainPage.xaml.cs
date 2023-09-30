using System.ComponentModel;

namespace ZimnioX
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void NumericEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Get the Entry control
            var entry = (Entry)sender;

            // Remove any non-numeric characters
            var newText = new string(entry.Text.Where(char.IsDigit).ToArray());

            // Update the Entry's text with the cleaned numeric value
            entry.Text = newText;
        }

        private void AddCustomControl_Clicked(object sender, EventArgs e)
        {           
            var listOfCryptoAssets = container.Children.OfType<ListOfCryptoAssets>().FirstOrDefault();
            listOfCryptoAssets.AddNewCryptoAsset();
        }
    }
}