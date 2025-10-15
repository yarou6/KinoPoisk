using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using Microsoft.Maui.Graphics.Text;
using System.Threading.Tasks;

namespace KinoPoisk.View;

public partial class AddContentPage : ContentPage
{
    private DBALL db;
    public AddContentPage(DBALL database)
    {
        InitializeComponent();
        db = database;
    }

    private async void Save(object sender, EventArgs e)
    {
        //TypeContent type = TypePicker.SelectedItem.;
        var PostType = await db.GetTypeContentId(TypePicker.SelectedIndex);
        var PostAuthor = await db.GetAuthorId(AuthorPicker.SelectedIndex);
        int.TryParse(AgeEntry.Text.Trim(), out int age);
        Content content = new Content()
        {
            Name = NameEntry.Text.Trim(),
            Description = DescriptionEditor.Text.Trim(),
            //IdTypeContent = PostType.Id,
            //TypeContent = PostType,
            Age = age,
            IdAuthor = PostAuthor.Id,
            Author = PostAuthor,
            //Data = ,
            //CountSeries = ,
            //IdGerne = ,
            //Gerne = ,
            //Subscription = 

        };
        await db.AddContent(content);
        await DisplayAlert("Победа", $"{content.Name} Добавлен","Ок");


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