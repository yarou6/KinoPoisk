using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using System.Threading.Tasks;
namespace KinoPoisk.View;
public partial class AddGernePopup : Popup
{
    private DBALL db;
    public AddGernePopup(DBALL database)
    {
        InitializeComponent();
        db = database;
    }

    private async void SaveGerne(object sender, EventArgs e)
    {
        string title = TitleEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(title))
        {
            await Application.Current.MainPage.DisplayAlert("Ошибка", "Заполните все поля", "ОК");
            return;
        }

        var genre = new Gerne
        {
            Title = title,
        };

        await db.GetDB().Result.AddGenre(genre);
        Close();
    }

    private void Cancel(object sender, EventArgs e)
    {
        Close();
    }
}