using ZimnioX.Models;

namespace ZimnioX;

public partial class ListOfCryptoAssets : ContentView
{
	public ListOfCryptoAssets()
	{
		InitializeComponent();
	}

	public void AddNewCryptoAsset()
	{
		container.Children.Add(new CryptoAsset());
	}

	public List<CryptoAssetModel> GetData()
	{
		var data = new List<CryptoAssetModel>();
		foreach (var item in container.Children)
		{
			var asset = item as CryptoAsset;
			data.Add(asset.GetModel());
		}

		return data;
	}
}