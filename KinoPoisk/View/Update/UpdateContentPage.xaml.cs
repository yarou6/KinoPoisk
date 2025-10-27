using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using KinoPoisk.View.Add;
namespace KinoPoisk.View.Update;

public partial class UpdateContentPage : ContentPage
{
	DBALL db;
    Content currentContent;
    public List<GerneIs> gerneIss { get; set; }
    public UpdateContentPage(DBALL database, Content content)
	{
		InitializeComponent();
		db = database;
        currentContent = content;
        LoadAuthors();
        LoadType();
        LoadGerne();
        FillFields();
    }

    private void FillFields()
    {
        if (currentContent == null)
            return;

        NameEntry.Text = currentContent.Name;
        DescriptionEditor.Text = currentContent.Description;
        AgeEntry.Text = currentContent.Age?.ToString();

        //Из item выберать колекцию и дальше по id сопоставлять с defoult с currentContent
        GenreCollection.ItemsSource = currentContent.Gernes;
        AuthorPicker.SelectedItem = currentContent.Author;
        TypePicker.SelectedItem = currentContent.TypeContent;

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
        // currentContent.Image = 

        var dbLocal = await db.GetDB();
        await dbLocal.UpdateContent(currentContent);

        await DisplayAlert("Сохранено", "Изменения успешно сохранены", "ОК");
        await Navigation.PopAsync();
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

    private void LoadImage(object sender, EventArgs e)
    {

    }
}