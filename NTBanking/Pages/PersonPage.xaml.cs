using NTBanking.Services;

namespace NTBanking.Pages;

public partial class PersonPage : ContentPage
{
    private readonly Capcha _capchaService;

    public PersonPage()
	{
		InitializeComponent();

	}



    private async void OnLogoutClicked(object sender, EventArgs e)
    {

        await Navigation.PopToRootAsync();
        _capchaService.GenerateCaptcha();


    }

    private async void OnHomeIconClicked(object sender, EventArgs e)
    {
        // ?i?u h??ng ??n trang Home
        await Navigation.PushAsync(new HomePage());
    }

    private async void OnNotificationIconClicked(object sender, EventArgs e)
    {
        // ?i?u h??ng ??n trang thông báo
        await Navigation.PushAsync(new NotificationPage());
    }

    private async void OnCurrencyIconClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ExchangeRatePage());
    }

    private async void OnPersonIconClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PersonPage());
    }

}