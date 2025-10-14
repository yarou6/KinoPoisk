using KinoPoisk.DB;

namespace KinoPoisk.View
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
                await DisplayAlert("������", "������� ����� � ������", "��");
                return;
            }

            bool success = await db.Register(login, password, isAdmin: false, hasSubscription);
            if (success)
            {
                await DisplayAlert("�����", "����������� ���������", "��");
                await Navigation.PushAsync(new LoginPage(db));
            }
            else
            {
                await DisplayAlert("������", "������������ � ����� ������� ��� ����������", "��");
            }
        }

        private async void Login(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoginPage(db));
        }
    }
}
