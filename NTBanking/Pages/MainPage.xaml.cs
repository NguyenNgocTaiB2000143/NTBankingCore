using Microsoft.Maui.Controls;
using NTBanking.Data;
using NTBanking.Services;
using System;

namespace NTBanking
{
    public partial class MainPage : ContentPage
    {
        private bool isPasswordVisible = false;
        private string _captchaCode = string.Empty;
        private readonly Capcha _capchaService;

        public MainPage()
        {
            InitializeComponent();

            _capchaService = new Capcha();

            if (Navigation != null)
            {
                NavigationPage.SetHasBackButton(this, false);
            }

            _capchaService.GenerateCaptcha(); // Khởi tạo mã CAPTCHA khi trang được tạo
            CaptchaLabel.Text = _captchaCode;

        }

        

       

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var phoneNumber = PhoneNumberEntry.Text;
            var password = PasswordEntry.Text;

            if (CaptchaEntryBox.Text != _captchaCode)
            {
                await DisplayAlert("Lỗi", "Mã CAPTCHA không chính xác.", "OK");
                _capchaService.GenerateCaptcha(); // Tạo lại mã CAPTCHA mới
                return;
            }

            if (await App.Database.LoginUserAsync(phoneNumber, password))
            {
                await DisplayAlert("Thành Công", "Đăng nhập thành công!", "OK");
                await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Lỗi", "Số điện thoại hoặc mật khẩu không đúng.", "OK");
            }
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private void OnTogglePasswordClicked(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;
            PasswordEntry.IsPassword = !isPasswordVisible;
            TogglePasswordButton.Source = isPasswordVisible ? "eye.png" : "eye_off.png";
        }
    }
}
