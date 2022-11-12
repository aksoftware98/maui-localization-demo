using AKSoftware.Localization.MultiLanguages;

namespace MauiMultiLanguages;

public partial class MainPage : ContentPage
{
	int count = 0;
	private ILanguageContainerService _language;
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCounterClicked(object sender, EventArgs e)
	{
        _language = this.Handler.MauiContext.Services.GetService<ILanguageContainerService>();
        count++;

		if (count == 1)
			CounterBtn.Text = _language["SingleButtonClickText"];
		else
			CounterBtn.Text = _language["MultiButtonClickText", new
			{
                clicks = count
			}];

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

