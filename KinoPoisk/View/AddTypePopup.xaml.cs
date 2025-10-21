using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
namespace KinoPoisk.View;

public partial class AddTypePopup : Popup
{
    private DBALL db;
	public AddTypePopup(DBALL database)
	{
		InitializeComponent();
        db = database;
	}

    private async void SaveType(object sender, EventArgs e)
    {
        string title = TitleEntry.Text?.Trim();

        if (string.IsNullOrWhiteSpace(title) )
        {
            await Application.Current.MainPage.DisplayAlert("Ошибка", "Заполните все поля", "ОК");
            return;
        }

        var type = new TypeContent
        {
            Title = title,
        };

        await db.GetDB().Result.AddTypeContent(type);
        Close();
    }

    private void Cancel(object sender, EventArgs e)
    {
        Close();
    }
}