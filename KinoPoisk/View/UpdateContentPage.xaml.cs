using KinoPoisk.DB;

namespace KinoPoisk.View;

public partial class UpdateContentPage : ContentPage
{
	DBALL db;
    public List<GerneIs> gerneIss { get; set; }
    public UpdateContentPage(DBALL database)
	{
		InitializeComponent();
		db = database;
    }
    private async void Save(object sender, EventArgs e)
    {
        //TypeContent type = TypePicker.SelectedItem.;
        var dbLocal = await db.GetDB();
        var PostType = await dbLocal.GetTypeContentId(TypePicker.SelectedIndex);
        var PostAuthor = await dbLocal.GetAuthorId(AuthorPicker.SelectedIndex);
        List<Gerne> gernes = gerneIss.Where(s => s.IsChecked).Select(s => s.Gerne).ToList();

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
        await DisplayAlert("Победа", $"{content.Name} Добавлен", "Ок");


    }
}