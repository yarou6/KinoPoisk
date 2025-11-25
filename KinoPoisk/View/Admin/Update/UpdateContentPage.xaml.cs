using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using KinoPoisk.View.Admin.Add;
using Microsoft.Maui.Storage;

namespace KinoPoisk.View.Admin.Update;

public partial class UpdateContentPage : ContentPage, IQueryAttributable
{
    Content currentContent;

    private FileResult? fileResult;
    public List<GerneIs> gerneIss { get; set; }
    public UpdateContentPage()
	{
        InitializeComponent();
    }

    private void FillFields()
    {
        if (currentContent == null)
            return;
       
        NameEntry.Text = currentContent.Name;
        DescriptionEditor.Text = currentContent.Description;
        AgeEntry.Text = currentContent.Age?.ToString();

        //Из item выберать колекцию и дальше по id сопоставлять с defoult с currentContent

        if (gerneIss != null && currentContent.Gernes != null)
        {
            foreach (var item in gerneIss)
            {
                item.IsChecked = currentContent.Gernes.Any(g => g.Id == item.Gerne.Id);
            }
            GenreCollection.ItemsSource = null;
            GenreCollection.ItemsSource = gerneIss;
        }

        if (AuthorPicker.ItemsSource != null && currentContent.Author != null)
        {
            var selectedAuthor = AuthorPicker.ItemsSource.Cast<Author>().FirstOrDefault(a => a.Id == currentContent.Author.Id);
            if (selectedAuthor != null)
                AuthorPicker.SelectedItem = selectedAuthor;
        }

        if (TypePicker.ItemsSource != null && currentContent.TypeContent != null)
        {
            var selectedType = TypePicker.ItemsSource.Cast<TypeContent>().FirstOrDefault(t => t.Id == currentContent.TypeContent.Id);
            if (selectedType != null)
                TypePicker.SelectedItem = selectedType;
        }

        Date.Date = currentContent.Data;
        CountSeries.Text = currentContent.CountSeries.ToString();
        SubscriptionSwitch.IsToggled = currentContent.Subscription;
        SelectedImage.Source = currentContent.Image;
    }

    private async void Save(object sender, EventArgs e)
    {
        if (currentContent == null)
            return;

        currentContent.Name = NameEntry.Text.Trim();
        currentContent.Description = DescriptionEditor.Text.Trim();
        currentContent.Age = AgeEntry.Text.Trim();
        currentContent.Data = Date.Date;
        currentContent.CountSeries = int.TryParse(CountSeries.Text, out int series) ? series : 0;
        currentContent.Subscription = SubscriptionSwitch.IsToggled;

        if (fileResult != null)
        {
            var destinationPath = Path.Combine(FileSystem.Current.AppDataDirectory,currentContent.Name + fileResult.FileName);

            using (var sourceStream = await fileResult.OpenReadAsync())
            using (var destinationStream = File.Open(destinationPath, FileMode.Create))
            {
                await sourceStream.CopyToAsync(destinationStream);
            }
            currentContent.Image = destinationPath;
        }



        var dbLocal = await DBALL.GetDB();
        await dbLocal.UpdateContent(currentContent);

        await DisplayAlert("Сохранено", "Изменения успешно сохранены", "ОК");
        await Navigation.PopAsync();
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

        FillFields();
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
            Stream stream = await fileResult.OpenReadAsync();
            SelectedImage.Source = ImageSource.FromStream(() => stream);
            this.fileResult = fileResult;
        }
        else await DisplayAlert("Файл", "Вы не выбрали изображение", "Ладно");
    }

    private async Task UpdateContent()
    {
        var popup = new ListUpdateContentPopup(this);

        await this.ShowPopupAsync(popup);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue("currentContent", out object movie))
        {
            currentContent = (Content)movie;
        }
    }

    public async void RefreshData()
    {
        await UpdateContent();

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