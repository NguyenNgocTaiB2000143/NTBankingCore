using Microsoft.Maui.Controls;
using System;
using NTBanking;
using NTBanking.Pages;


namespace NTBanking
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
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
}
