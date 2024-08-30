using NTBanking.Data; 
using NTBanking.Models;

namespace NTBanking
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnRegisterClicked(object sender, EventArgs e)
        {
            string phoneNumber = PhoneNumberEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Đăng Ký Thất Bại", "Số điện thoại hoặc mật khẩu không được để trống.", "OK");
                return;
            }

            var existingUser = await App.Database.GetUserAsync(phoneNumber);
            if (existingUser == null)
            {
                var user = new User
                {
                    PhoneNumber = phoneNumber,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
                };

                await App.Database.SaveUserAsync(user);
                await DisplayAlert("Đăng Ký Thành Công", "Tài khoản của bạn đã được tạo.", "OK");
                await Navigation.PopAsync();
            }


            else
            {
                await DisplayAlert("Đăng Ký Thất Bại", "Số điện thoại này đã được đăng ký.", "OK");
            }
            if (password.Length < 6)
            {
                await DisplayAlert("Đăng Ký Thất Bại", "Mật khẩu phải có ít nhất 6 ký tự.", "OK");
                return;
            }

        }
        private async void OnBackToLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

    }
}