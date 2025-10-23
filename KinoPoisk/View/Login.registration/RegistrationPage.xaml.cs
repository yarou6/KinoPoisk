using KinoPoisk.DB;
using KinoPoisk.View;

namespace KinoPoisk.View.Login.registration
{
    public partial class RegistrationPage : ContentPage
    {
        private DBALL db;

        public RegistrationPage(DBALL database)
        {
            InitializeComponent();
            db = database;
        }

        private async void Registration(object sender, EventArgs e)
        {
            string login = LoginEntry.Text;
            string password = PasswordEntry.Text;
            bool hasSubscription = SubscriptionSwitch.IsToggled;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Ошибка", "Введите логин и пароль", "ОК");
                return;
            }

            var dbLocal = await db.GetDB();
            bool success = await dbLocal.Register(login, password, isAdmin: false, hasSubscription);
            if (success)
            {
                await DisplayAlert("Успех", "Регистрация выполнена", "ОК");
                await Navigation.PushAsync(new LoginPage(db));
            }
            else
            {
                await DisplayAlert("Ошибка", "Пользователь с таким логином уже существует", "ОК");
            }
        }

        private async void Login(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage(db));
        }
    }
}
