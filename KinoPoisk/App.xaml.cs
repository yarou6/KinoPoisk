using KinoPoisk.DB;
namespace KinoPoisk
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}