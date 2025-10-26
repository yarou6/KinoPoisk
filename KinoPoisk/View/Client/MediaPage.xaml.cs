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

    public void Load()
    {
        Title = movie.Name;

        string genres = movie.Gernes != null && movie.Gernes.Any()
            ? string.Join(", ", movie.Gernes.Select(g => g.Title))
            : "Не указан(ы)";

        bool isFilm = movie.TypeContent?.Title?.ToLower().Contains("фильм") == true;

        BindingContext = new
        {
            Name = movie.Name,
            Description = movie.Description,
            RatingText = $"⭐ {movieR.Stars}/10",
            YearText = $"Год производства: {movie.Data:yyyy}",
            CountryText = $"Страна: {movie.Author?.Country ?? "Не указана"}",
            AuthorText = $"Автор: {movie.Author?.Title ?? "Неизвестен"}",
            GenreText = $"Жанры: {genres}",
            AgeText = $"Возраст: {movie.Age}",
            SeriesText = $"Количество серий: {(isFilm ? "—" : movie.CountSeries.ToString())}"
        };

        MovieImage.Source = movie.Image;
    }

    private async void Profile(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage());
    }
}