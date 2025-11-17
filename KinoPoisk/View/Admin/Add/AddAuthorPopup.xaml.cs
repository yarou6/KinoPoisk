using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using System.Threading.Tasks;
namespace KinoPoisk.View.Admin.Add;
public partial class AddAuthorPopup : Popup
{
    public AddAuthorPopup()
    {
        InitializeComponent();
    }

    private async void SaveAuthor(object sender, EventArgs e)
    {
        string title = TitleEntry.Text?.Trim();
        string country = CountryEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(country))
        {
            await Application.Current.MainPage.DisplayAlert("Ошибка", "Заполните все поля", "ОК");
            return;
        }

        var author = new Author
        {
            Title = title,
            Country = country
        };

        var dbLocal = await DBALL.GetDB();
        await dbLocal.AddAuthor(author);
        Close();

    }

    private void Cancel(object sender, EventArgs e)
    {
        Close();
    }
}