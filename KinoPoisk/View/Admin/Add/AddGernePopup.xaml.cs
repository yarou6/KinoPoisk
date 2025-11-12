using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using System.Threading.Tasks;
namespace KinoPoisk.View.Admin.Add;
public partial class AddGernePopup : Popup
{
    public AddGernePopup()
    {
        InitializeComponent();
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

        var dbLocal = await DBALL.GetDB();
        await dbLocal.AddGenre(genre);
        Close();
    }

    private void Cancel(object sender, EventArgs e)
    {
        Close();
    }
}