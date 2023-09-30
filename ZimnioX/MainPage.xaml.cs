using CommunityToolkit.Maui.Views;
using System.ComponentModel;
using System.Globalization;
using ZimnioX.Models;

namespace ZimnioX
{
    public partial class MainPage : ContentPage
    {
        public ListOfCryptoAssets listOfCryptoAssets;

        public MainPage()
        {
            InitializeComponent();
            listOfCryptoAssets = container.Children.OfType<ListOfCryptoAssets>().FirstOrDefault();
            listOfCryptoAssets.PropertyChanged += UpdateSum;
        }

        private void UpdateSum(object sender, PropertyChangedEventArgs e)
        {
            var data = listOfCryptoAssets.GetData();
            try
            {
                var sum = Math.Truncate(data.Sum(x => x.Sum) * 100 / 100);
                TotalSum.Text = string.Format("{0:N2}", sum) + " PLN";
            } 
            catch
            {
                TotalSum.Text = "0,00 PLN";
            }

        }

        private void AddCustomControl_Clicked(object sender, EventArgs e)
        {           
            listOfCryptoAssets.AddNewCryptoAsset();
        }

        private void GeneratePdf(object sender, EventArgs e)
        {
            // Get data from fields
            var allData = GetAllData();

            // Build HTML string
            string html = BuildHtmlString(allData);

            // Save string to file
            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            path = Path.Combine(path, $"{allData.JobId}_{allData.DateTime.Replace(":", "")}.html");
            File.WriteAllText(path, html);
        }

        private string BuildHtmlString(AllData allData)
        {
            string htmlContent = "<html><body>";
            htmlContent += $"<h1>Szacowanie wartości kryptoaktywów</h1>";
            htmlContent += $"<h2>Unikalny id raportu: {new Guid()}</h2>";
            htmlContent += $"<h3>Data wygenerowania raportu: {allData.DateTime}</h3>";
            htmlContent += $"<p>Numer sprawy: {allData.JobId}</p>";
            htmlContent += $"<p>Właściciel kryptoaktywa: {allData.Owner}</p>";
            htmlContent += $"<p>Szacunkowa średnia wartość kryptoaktyw: {TotalSum.Text}</p>";

            int index = 0;
            foreach(var asset in allData.CryptoAssets)
            {
                htmlContent += $"<h4>Kryptoaktywo #{index+1}</h4>";
                htmlContent += $"<p>Nazwa: {asset.Name}</p>";
                htmlContent += $"<p>Ilość: {asset.Quantity}</p>";
                htmlContent += $"<p>Kurs: {asset.Rate}</p>";
                index++;
            }

            htmlContent += "</body></html>";

            return htmlContent;
        }

        private void OpenSettings(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Settings());
        }

        private AllData GetAllData()
        {
            return new AllData(DateTime.Now.ToString(CultureInfo.CurrentCulture), institute.Text, jobId.Text, owner.Text, listOfCryptoAssets.GetData());
        }
    }
}