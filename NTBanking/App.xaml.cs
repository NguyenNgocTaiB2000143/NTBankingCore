using Microsoft.Maui.Controls;
using System.IO;
using NTBanking.Data; 

namespace NTBanking
{
    public partial class App : Application
    {
        static DatabaseHelper? database;

        public static DatabaseHelper Database
        {
            get
            {
                if (database == null)
                {
                    // Cung cấp đường dẫn cơ sở dữ liệu
                    var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "NTBanking.db3");
                    database = new DatabaseHelper(dbPath);
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            
            MainPage = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = Color.FromArgb("#007BFF"), 
                BarTextColor = Color.FromArgb("#007BFF")
            };

            NavigationPage.SetHasNavigationBar(MainPage, false);
        }
    }
}
