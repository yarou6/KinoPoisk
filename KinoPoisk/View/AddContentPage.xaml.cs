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
    }

    private async void Save(object sender, EventArgs e)
    {
        //TypeContent type = TypePicker.SelectedItem.;
        var PostType = await db.GetDB().Result.GetTypeContentId(TypePicker.SelectedIndex);
        var PostAuthor = await db.GetDB().Result.GetAuthorId(AuthorPicker.SelectedIndex);
        List<Gerne> gernes= gerneIss.Where(s => s.IsChecked).Select(s => s.Gerne).ToList();
        

        int.TryParse(AgeEntry.Text.Trim(), out int age);
        Content content = new Content()
        {
            Name = NameEntry.Text.Trim(),
            Description = DescriptionEditor.Text.Trim(),
            IdTypeContent = PostType.Id,
            TypeContent = PostType,
            Age = age,
            IdAuthor = PostAuthor.Id,
            Author = PostAuthor,
            Gernes = gernes,
            //Data = ,
            //CountSeries = ,
            //Subscription = 

        };
        await db.GetDB().Result.AddContent(content);
        await DisplayAlert("Победа", $"{content.Name} Добавлен","Ок");
        try { File.WriteAllText(FileSystem.Current.AppDataDirectory + "/test.txt", JsonSerializer.Serialize((DBDTO)db));} catch(Exception ex) { }
        

    }

    private void LoadImage(object sender, EventArgs e)
    {

    }

    private async void AddAuthor(object sender, EventArgs e)
    {
        var popup = new AddAuthorPopup(db);

        await this.ShowPopupAsync(popup);


        var list = await db.GetDB().Result.GetAuthors();

        AuthorPicker.Items.Clear();

        for (int i = 0; i < list.Count; i++)
            AuthorPicker.Items.Add($"{list[i].Title} ({list[i].Country})");
    }

    private async void AddType(object sender, EventArgs e)
    {
        var popup = new AddTypePopup(db);

        await this.ShowPopupAsync(popup);

        var list = await db.GetDB().Result.GetTypeContent();

        TypePicker.Items.Clear();

        for (int i = 0; i < list.Count; i++)
            TypePicker.Items.Add(list[i].Title);


    }

    private async void AddGerne(object sender, EventArgs e)
    {
        var popup = new AddGernePopup(db);

        await this.ShowPopupAsync(popup);
        var list = await db.GetDB().Result.GetGernes();

        gerneIss = list.Select(s => new GerneIs { Gerne = s, IsChecked = false }).ToList(); 

        GenreCollection.ItemsSource = gerneIss;


    }
}