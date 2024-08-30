using Microsoft.Maui.Controls;
using NTBanking;
using NTBanking.Pages;
namespace NTBanking
{
    public partial class NotificationPage : ContentPage
    {
        public NotificationPage()
        {
            InitializeComponent();
        }

        private async void OnHomeIconClicked(object sender, EventArgs e)
        {
            // điều hướng trang Home
            await Navigation.PushAsync(new HomePage());
        }

        private async void OnNotificationIconClicked(object sender, EventArgs e)
        {
            // điều hướng trang thông báo
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
}
