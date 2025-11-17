using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using KinoPoisk.View.Admin.Add;

namespace KinoPoisk.View.Admin.Update;

public partial class UpdateContentPage : ContentPage, IQueryAttributable
{
    Content currentContent;
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

        for (int i = 0; i < currentContent.Gernes.Count; i++)
        {
            if (gerneIss.FirstOrDefault(s => s.Gerne.Id == currentContent.Gernes[i].Id) != null)
            {
                gerneIss[i].IsChecked = true;
            }
        }
        GenreCollection.ItemsSource = gerneIss;

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

    private void LoadImage(object sender, EventArgs e)
    {

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