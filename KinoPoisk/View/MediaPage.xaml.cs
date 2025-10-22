using KinoPoisk.DB;
namespace KinoPoisk.View;

public partial class MediaPage : ContentPage
{
    private Content movie;
    public MediaPage(Content content)
	{
		InitializeComponent();

        movie = content;

        Title = movie.Name;

        MovieName.Text = movie.Name;
        MovieDescription.Text = movie.Description;
        MovieImage.Source = movie.Image;
        MovieRating.Text = $"⭐ {movie.CountSeries}/10";
    }

    private void Profile(object sender, EventArgs e)
    {
        DisplayAlert("Профиль", "Открыть профиль", "OK");
    }
}