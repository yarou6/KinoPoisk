using CommunityToolkit.Maui.Views;

namespace KinoPoisk.View;

public partial class AddContentPage : ContentPage
{
	public AddContentPage()
	{
		InitializeComponent();
	}

    private void Save(object sender, EventArgs e)
    {

    }

    private void LoadImage(object sender, EventArgs e)
    {

    }

    private async void AddAuthor(object sender, EventArgs e)
    {
        var popup = new AddAuthorPopup();
        popup.AuthorAdded += (author) =>
        {
            AuthorPicker.Items.Add($"{author.Title} ({author.Country})");
            AuthorPicker.SelectedIndex = AuthorPicker.Items.Count - 1;
        };

        await this.ShowPopupAsync(popup);
    }
}