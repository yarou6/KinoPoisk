using KinoPoisk.DB;
using KinoPoisk.View;
using KinoPoisk.View.Client;
using KinoPoisk.View.Login.registration;

namespace KinoPoisk
{
    public partial class AppShell : Shell
    {
        public DBALL db  = new DBALL();
        public AppShell()
        {
            InitializeComponent();

            db.InitAdmin();

            Routing.RegisterRoute("Registre", typeof(RegistrationPage));
            Routing.RegisterRoute("Login", typeof(LoginPage));
            Routing.RegisterRoute("Admin", typeof(AdminPage));
            Routing.RegisterRoute("Main", typeof(MainPage));
        }
    }
}
