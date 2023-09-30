namespace ZimnioX;

public partial class Settings : ContentPage
{
	public Settings()
	{
		InitializeComponent();
	}

    private void GoBack(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }
}