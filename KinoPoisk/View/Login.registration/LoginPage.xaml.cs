using System;
using Microsoft.Maui.Controls;
using KinoPoisk.DB;
using KinoPoisk.View.Client;
namespace KinoPoisk.View.Login.registration
{
    public partial class LoginPage : ContentPage
    {
        private DBALL db;

        public LoginPage(DBALL database)
        {
            InitializeComponent();
            db = database;
            // ���� /storage/emulated/0/Docments
            //File.Create("/storage/emulated/0/Documents/test.txt");
            

        }

        private async void Login(object sender, EventArgs e)
        {
            string login = LoginEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("������", "������� ����� � ������", "��");
                return;
            }

            var dbLocal = await db.GetDB();
            var user = await dbLocal.Authenticate(login, password);
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
                await DisplayAlert("������", "�������� ����� ��� ������", "��");
            }
        }

        private async void Registration(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage(db));
        }
    }
}
