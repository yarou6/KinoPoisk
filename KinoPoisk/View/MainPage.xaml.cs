using KinoPoisk.DB;
namespace KinoPoisk.View
{
    public partial class MainPage : ContentPage
    {
        private User currentUser;
        private DBALL db;

        public MainPage(DBALL database, User user)
        {
            InitializeComponent();
            db = database;
            currentUser = user;

            WelcomeLabel.Text = $"Добро пожаловать, {currentUser.Login}!";
            RoleLabel.Text = currentUser.IsAdmin ? "Роль: Админ" : "Роль: Пользователь";
            SubscriptionLabel.Text = currentUser.HasSubscription ? "Подписка: есть" : "Подписка: нет";

            SubscriptionButton.IsVisible = currentUser.HasSubscription;

         
        }

        private async void Sub(object sender, EventArgs e)
        {
            await DisplayAlert("Подписка", "Здесь будет контент для подписчиков", "ОК");
        }
    }
}
