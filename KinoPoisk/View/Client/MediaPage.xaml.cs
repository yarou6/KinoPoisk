using KinoPoisk.DB;
namespace KinoPoisk.View.Client;

public partial class MediaPage : ContentPage
{
    private Content movie;
    private DBALL db;
    private User currentUser;
    public MediaPage(Content content, DBALL database, User user)
    {
        InitializeComponent();
        movie = content;
        db = database;
        currentUser = user;
        Load();
    }

    public async void Load()
    {
        Title = movie.Name;

        string genres = movie.Gernes != null && movie.Gernes.Any()
            ? string.Join(", ", movie.Gernes.Select(g => g.Title))
            : "Не указан(ы)";

        bool isFilm = movie.TypeContent?.Title?.ToLower().Contains("фильм") == true;

        var allRatings = await db.GetRating();
        double avgStars = movie.GetAverageRating(allRatings);

        BindingContext = new
        {
            Name = movie.Name,
            Description = movie.Description,
            RatingText = $"⭐ {avgStars:F1}/10",
            YearText = $"Год производства: {movie.Data:yyyy}",
            CountryText = $"Страна: {movie.Author?.Country ?? "Не указана"}",
            AuthorText = $"Автор: {movie.Author?.Title ?? "Неизвестен"}",
            GenreText = $"Жанры: {genres}",
            AgeText = $"Возраст: {movie.Age}",
            SeriesText = $"Количество серий: {(isFilm ? "—" : movie.CountSeries.ToString())}"
        };

        MovieImage.Source = movie.Image;
    }
    private async void RateMovie(object sender, EventArgs e)
    {
        string starsStr = await DisplayPromptAsync("Оценка", "Введите оценку от 0 до 10:");
        if (!double.TryParse(starsStr, out double stars) || stars < 0 || stars > 10)
        {
            await DisplayAlert("Ошибка", "Введите корректное число от 0 до 10", "OK");
            return;
        }

        string feedback = FeedbackEntry.Text ?? "";

        await db.AddOrUpdateRating(movie.Id, currentUser.Id, stars, feedback);

        double avgStars = movie.GetAverageRating(await db.GetRating());

        await DisplayAlert("Спасибо!", $"Ваша оценка сохранена. Средний рейтинг: {avgStars:F1}/10", "OK");

        Load();
    }

    private async void ToggleFavorite(object sender, EventArgs e)
    {
        await db.ToggleFavorite(currentUser.Id, movie.Id);
        await DisplayAlert("Готово", "Фильм добавлен/удален из избранного.", "OK");
    }

    private async void MarkWatched(object sender, EventArgs e)
    {
        await db.MarkAsWatched(currentUser.Id, movie.Id);
        await DisplayAlert("Готово", "Фильм отмечен как просмотренный.", "OK");
    }
    private async void Profile(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage(db, currentUser));
    }

    private async void Main(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage(db, currentUser));
    }
}