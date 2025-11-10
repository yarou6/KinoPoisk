using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using System.Threading.Tasks;

namespace KinoPoisk.View.Update;

public partial class ListUpdateContentPopup : Popup
{
    Page parentPage;
    public ListUpdateContentPopup(Page parent)
	{
		InitializeComponent();
		parentPage = parent;

        LoadContents();
    }

    private async void LoadContents()
    {
        var dbLocal = await DBALL.GetDB();
        var contents = await dbLocal.GetContents();

        if (contents != null && contents.Count > 0)
        {
            CarouselMovies.ItemsSource = contents;
        }
        else
        {
            await parentPage.DisplayAlert("Нет данных", "Контент отсутствует в базе", "OK");
        }
    }

    private async void MoviesSeries(object sender, TappedEventArgs e)
    {
		Close();
		//if (sender is Frame frame && frame.BindingContext is Content selectedContent)
			//await parentPage.Navigation.PushAsync(new UpdateContentPage(db, selectedContent));
			
    }
}