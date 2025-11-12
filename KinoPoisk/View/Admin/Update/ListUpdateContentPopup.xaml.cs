using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using System.Threading.Tasks;

namespace KinoPoisk.View.Admin.Update;

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
		
        if (sender is Frame frame && frame.BindingContext is Content selectedContent)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict["currentContent"] = selectedContent;
            await Shell.Current.GoToAsync("///Update", dict);

        }Close();
    }
}