using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using Microsoft.Maui.Graphics.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KinoPoisk.View.Admin.Add;

public partial class AddContentPage : ContentPage
{
    public List<GerneIs> gerneIss {  get; set; } 
    public string Im { get; set; }
    public AddContentPage()
    {
        InitializeComponent();
     
    }

    private async void Save(object sender, EventArgs e)
    {
        var dbLocal = await DBALL.GetDB();
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
            Image = SelectedImage.ToString()

        };
        await dbLocal.AddContent(content);
        await DisplayAlert("Победа", $"{content.Name} Добавлен","Ок");
        

    }

    private async void LoadImage(object sender, EventArgs e)
    {
        var type = new Dictionary<DevicePlatform, IEnumerable<string>>();
        type[DevicePlatform.Android] = new List<string>
        {
            "image/png",
            "image/jpg",
            "image/jpeg",
            "image/webp"
        };
        type[DevicePlatform.WinUI] = new List<string>
        {
            ".png",
            ".jpg",
            ".jpeg",
            ".webp"
        };
        PickOptions pickOptions = new PickOptions();
        pickOptions.FileTypes = new FilePickerFileType(type);
        FileResult? fileResult = await FilePicker.Default.PickAsync(pickOptions);
        if (fileResult != null)
        {
            Stream inputStream = await fileResult.OpenReadAsync();
            SelectedImage.Source = ImageSource.FromStream(() => inputStream);
        }
        else await DisplayAlert("Файл", "Вы не выбрали изображение", "Ладно");

    }

    private async void AddAuthor(object sender, EventArgs e)
    {
        var popup = new AddAuthorPopup();

        await this.ShowPopupAsync(popup);

        LoadAuthors();
    }

    private async void LoadAuthors()
    {
        var dbLocal = await DBALL.GetDB();
        AuthorPicker.ItemsSource = await dbLocal.GetAuthors();
    }

    private async void AddType(object sender, EventArgs e)
    {
        var popup = new AddTypePopup();

        await this.ShowPopupAsync(popup);
        LoadType();

    }

    private async void LoadType()
    {
        var dbLocal = await DBALL.GetDB();
        TypePicker.ItemsSource = await dbLocal.GetTypeContent();

    }

    private async void AddGerne(object sender, EventArgs e)
    {
        var popup = new AddGernePopup();

        await this.ShowPopupAsync(popup);
        LoadGerne();

    }

    private async void LoadGerne()
    {
        var dbLocal = await DBALL.GetDB();
        var list = await dbLocal.GetGernes();

        gerneIss = list.Select(s => new GerneIs { Gerne = s, IsChecked = false }).ToList();

        GenreCollection.ItemsSource = gerneIss;
    }
     
    public async void RefreshData()
    {
        LoadAuthors();
        LoadType();
        LoadGerne();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        RefreshData();
    }
}