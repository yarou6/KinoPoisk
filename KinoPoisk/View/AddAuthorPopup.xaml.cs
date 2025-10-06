using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
namespace KinoPoisk.View;
public partial class AddAuthorPopup : Popup
{
    public event Action<DB.Author>? AuthorAdded;

    public AddAuthorPopup()
    {
        InitializeComponent();
    }

    private void SaveAuthor(object sender, EventArgs e)
    {
        string title = TitleEntry.Text?.Trim();
        string country = CountryEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(country))
        {
            Application.Current.MainPage.DisplayAlert("Ошибка", "Заполните все поля", "ОК");
            return;
        }

        var author = new DB.Author
        {
            Id = 0, 
            Title = title,
            Country = country
        };

        AuthorAdded?.Invoke(author); 
        Close();
    }

    private void Cancel(object sender, EventArgs e)
    {
        Close();
    }
}