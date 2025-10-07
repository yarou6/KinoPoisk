using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;

namespace KinoPoisk.View;

public partial class AddContentPage : ContentPage
{
    private DBALL db;
    public AddContentPage(DBALL database)
    {
        InitializeComponent();
        db = database;
    }

    private void Save(object sender, EventArgs e)
    {

    }

    private void LoadImage(object sender, EventArgs e)
    {

    }

    private async void AddAuthor(object sender, EventArgs e)
    {
        var popup = new AddAuthorPopup(db);

        await this.ShowPopupAsync(popup);


        var list = await db.GetAuthors();
        
        AuthorPicker.Items.Clear();

        for (int i = 0; i < list.Count; i++)
            AuthorPicker.Items.Add($"{list[i].Title} ({list[i].Country})");
    }
}