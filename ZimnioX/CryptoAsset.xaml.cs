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