using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using Microsoft.Maui.Graphics.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KinoPoisk.View;

public partial class AddContentPage : ContentPage
{
    private DBALL db;
    public List<GerneIs> gerneIss {  get; set; } 
    public AddContentPage(DBALL database)
    {
        InitializeComponent();
        db = database;
        LoadAuthors();
        LoadType();
        LoadGerne();
    }

    private async void Save(object sender, EventArgs e)
    {
        //TypeContent type = TypePicker.SelectedItem.;
        var dbLocal = await db.GetDB();
        var PostType = await dbLocal.GetTypeContentId(TypePicker.SelectedIndex);
        var PostAuthor = await dbLocal.GetAuthorId(AuthorPicker.SelectedIndex);
        List<Gerne> gernes= gerneIss.Where(s => s.IsChecked).Select(s => s.Gerne).ToList();

        int.TryParse(CountSeries.Text.Trim(), out int countSeries);
        Content content = new Content()
        {
            Name = NameEntry.Text.Trim(),
            Description = DescriptionEditor.Text.Trim(),
            IdTypeContent = PostType.Id,
            TypeContent = PostType,
            Age = AgeEntry.Text.Trim(),
            IdAuthor = PostAuthor.Id,
            Author = PostAuthor,
            Gernes = gernes,
            Data = Date.Date,
            CountSeries = countSeries,
            Subscription = SubscriptionSwitch.IsToggled,
            //Image =

        };
        await dbLocal.AddContent(content);
        await DisplayAlert("Победа", $"{content.Name} Добавлен","Ок");
        

    }

    private void LoadImage(object sender, EventArgs e)
    {

    }

    private async void AddAuthor(object sender, EventArgs e)
    {
        var popup = new AddAuthorPopup(db);

        await this.ShowPopupAsync(popup);

        LoadAuthors();
    }

    private async void LoadAuthors()
    {
        var dbLocal = await db.GetDB();
        var list = await dbLocal.GetAuthors();

        AuthorPicker.Items.Clear();

        for (int i = 0; i < list.Count; i++)
            AuthorPicker.Items.Add($"{list[i].Title} ({list[i].Country})");
    }

    private async void AddType(object sender, EventArgs e)
    {
        var popup = new AddTypePopup(db);

        await this.ShowPopupAsync(popup);
        LoadType();

    }

    private async void LoadType()
    {
        var dbLocal = await db.GetDB();
        var list = await dbLocal.GetTypeContent();

        TypePicker.Items.Clear();

        for (int i = 0; i < list.Count; i++)
            TypePicker.Items.Add(list[i].Title);
    }

    private async void AddGerne(object sender, EventArgs e)
    {
        var popup = new AddGernePopup(db);

        await this.ShowPopupAsync(popup);
        LoadGerne();

    }

    private async void LoadGerne()
    {
        var dbLocal = await db.GetDB();
        var list = await dbLocal.GetGernes();

        gerneIss = list.Select(s => new GerneIs { Gerne = s, IsChecked = false }).ToList();

        GenreCollection.ItemsSource = gerneIss;
    }
}