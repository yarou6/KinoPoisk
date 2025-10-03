using KinoPoisk.DB;
namespace KinoPoisk
{
    public partial class App : Application
    {
        public static DBALL db { get; private set; } = new DBALL();

        public App()
        {
            InitializeComponent();

            db.InitAdmin();

            MainPage = new NavigationPage(new View.LoginPage(db));
        }
    }
}