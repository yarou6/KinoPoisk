using KinoPoisk.DB;

namespace KinoPoisk.View.Update;

public partial class UpdateContentPage : ContentPage
{
	DBALL db;
    Content currentContent;
    public UpdateContentPage(DBALL database, Content content)
	{
		InitializeComponent();
		db = database;
        currentContent = content;

        FillFields();
    }

    private void FillFields()
    {
        if (currentContent == null)
            return;

        NameEntry.Text = currentContent.Name;
        DescriptionEditor.Text = currentContent.Description;
        AgeEntry.Text = currentContent.Age?.ToString();
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

    private void AddType(object sender, EventArgs e)
    {

    }

    private void AddGerne(object sender, EventArgs e)
    {

    }

    private void AddAuthor(object sender, EventArgs e)
    {

    }

    private void LoadImage(object sender, EventArgs e)
    {

    }
}