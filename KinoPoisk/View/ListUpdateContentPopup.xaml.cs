using CommunityToolkit.Maui.Views;
using KinoPoisk.DB;
using System.Threading.Tasks;

namespace KinoPoisk.View;

public partial class ListUpdateContentPopup : Popup
{
	DBALL db;
	public ListUpdateContentPopup(DBALL database)
	{
		InitializeComponent();
		db = database;
	}

    private async void MoviesSeries(object sender, TappedEventArgs e)
    {
		var popup = new UpdateContentPage(db);
		//popup.sH
    }
}