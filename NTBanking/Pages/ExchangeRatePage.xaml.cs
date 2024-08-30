using Microsoft.Maui.Controls;
using NTBanking.Models;
using NTBanking.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using NTBanking.Pages;

namespace NTBanking
{
    public partial class ExchangeRatePage : ContentPage
    {
        private readonly CurrencyService _currencyService;

        public ExchangeRatePage()
        {
            InitializeComponent();
            _currencyService = new CurrencyService();
            LoadExchangeRates();
        }

        // Chỗ này để load tỷ giá ngoại tệ 
        private async void LoadExchangeRates()
        {
            var xmlDocument = await _currencyService.GetExchangeRateAsync();
            if (xmlDocument != null)
            {
                var rates = _currencyService.ParseExchangeRate(xmlDocument);
                if (rates.Any())
                {
                    RatesListView.ItemsSource = rates;
                }
                else
                {
                    Console.WriteLine("No exchange rates data available.");
                }
            }
            else
            {
                Console.WriteLine("Failed to retrieve XML document.");
            }

        }
        private void UpdateDateTime(XDocument xmlDocument)
        {
            var dateTimeElement = xmlDocument.Descendants("DateTime").FirstOrDefault();
            if (dateTimeElement != null)
            {
                DateTimeLabel.Text = $"Cập nhật vào: {dateTimeElement.Value}";
            }
            else
            {
                DateTimeLabel.Text = "Ngày giờ không xác định";
            }
        }

        private async void OnHomeIconClicked(object sender, EventArgs e)
        {
            // điều hướng trang home
            await Navigation.PushAsync(new HomePage());
        }

        private async void OnNotificationIconClicked(object sender, EventArgs e)
        {
            // điều hướng trang thông báo
            await Navigation.PushAsync(new NotificationPage());
        }

        private async void OnCurrencyIconClicked(object sender, EventArgs e)
        {
            // điều hướng trang tỷ giá ngoại tệ
            await Navigation.PushAsync(new ExchangeRatePage());
        }

        private async void OnPersonIconClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PersonPage());
        }
    }
}
