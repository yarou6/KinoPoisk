using System;
using Microsoft.Maui.Controls;
using KinoPoisk.DB;

namespace KinoPoisk.View
{
    public partial class LoginPage : ContentPage
    {
        private DBALL db;

        public LoginPage(DBALL database)
        {
            InitializeComponent();
            db = database;
            // путь /storage/emulated/0/Docments
            File.Create("");
        }

        private async void Login(object sender, EventArgs e)
        {
            string login = LoginEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Ошибка", "Введите логин и пароль", "ОК");
                return;
            }

            var user = await db.Authenticate(login, password);
            if (user != null)
            {
                if (user.IsAdmin)
                {
                    await Navigation.PushAsync(new AdminPage(db, user));
                }
                else
                {
                    await Navigation.PushAsync(new MainPage(db, user));
                }
            }
            else
            {
                await DisplayAlert("Ошибка", "Неверный логин или пароль", "ОК");
            }
        }

        private async void Registration(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage(db));
        }
    }
}
