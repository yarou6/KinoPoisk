using KinoPoisk.DB;
using KinoPoisk.View;
using KinoPoisk.View.Client;
using KinoPoisk.View.Admin.Add;
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
            Routing.RegisterRoute("Media", typeof(MediaPage));

            Routing.RegisterRoute("Author", typeof(AddAuthorPopup));
            Routing.RegisterRoute("Genre", typeof(AddGernePopup));
            Routing.RegisterRoute("Type", typeof(AddTypePopup));
        }
    }
}
