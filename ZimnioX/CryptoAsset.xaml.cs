using Newtonsoft.Json;
using ZimnioX.Models;

namespace ZimnioX;

public partial class CryptoAsset : ContentView
{
	private double cryptoAmountDbl {  get; set; }
	private double cryptoRateDbl {  get; set; }
	private double cryptoSumDbl {  get; set; }
	public CryptoAsset()
	{
		InitializeComponent();
        //var task = LoadCryptoDict();
        //task.Wait();
        //var dict = task.Result;
        //var temp = 0;
    }

    private async Task<List<CryptoName>> LoadCryptoDict()
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("cryptoDict.json");
        using var reader = new StreamReader(stream);
        var contents = reader.ReadToEnd();
        return JsonConvert.DeserializeObject<List<CryptoName>>(contents);
    }

    public CryptoAssetModel GetModel()
	{
		return new CryptoAssetModel(cryptoName.Text, cryptoAmountDbl, cryptoRateDbl, cryptoSumDbl);
	}

    private void UpdateCryptoSum(object sender, TextChangedEventArgs e)
    {
        try 
		{ 
			cryptoAmountDbl = Double.Parse(cryptoAmount.Text);
            cryptoRateDbl = Double.Parse(cryptoRate.Text);
            cryptoSumDbl = cryptoAmountDbl * cryptoRateDbl;
        }
        catch 
		{
			cryptoSumDbl = 0;
			cryptoSum.Text = string.Empty;
		}        
    }
}