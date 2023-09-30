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
}