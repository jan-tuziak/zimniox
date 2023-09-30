namespace ZimnioX;

public partial class CryptoAsset : ContentView
{
	public CryptoAsset()
	{
		InitializeComponent();
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
}