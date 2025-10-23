using KinoPoisk.DB;
namespace KinoPoisk.View.Client;

public partial class MediaPage : ContentPage
{
    private Content movie;
    private Rating movieR;
    public MediaPage(Content content, Rating rating)
	{
		InitializeComponent();
        movie = content;
        movieR = rating;
        Load();
        
    }
    public async void Load()
    {
        Title = movie.Name;

        MovieName.Text = movie.Name;
        MovieDescription.Text = movie.Description;
        MovieImage.Source = movie.Image;
        MovieRating.Text = $"⭐ {movieR.Stars}/10";
    }

    private async void Profile(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage());
    }
}