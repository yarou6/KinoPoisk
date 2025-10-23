using KinoPoisk.DB;
namespace KinoPoisk
{
    public partial class App : Application
    {
        public DBALL db  = new DBALL();

        public App()
        {
            InitializeComponent();

            db.InitAdmin();

            MainPage = new NavigationPage(new View.Login.registration.LoginPage(db));
        }
    }
}