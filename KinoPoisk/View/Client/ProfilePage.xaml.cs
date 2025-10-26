using KinoPoisk.DB;

namespace KinoPoisk.View.Client;

public partial class ProfilePage : ContentPage
{
    private DBALL db;
    private User currentUser;

    public ProfilePage(DBALL database, User user)
    {
        InitializeComponent();
        db = database;
        currentUser = user;
        LoadData();
    }

    private async void LoadData()
    {
        var allContents = await db.GetContents();
        var allRatings = await db.GetRating();

        var favorites = allContents
            .Where(c => currentUser.FavoriteContentIds.Contains(c.Id))
            .ToList();
        FavoriteCollectionView.ItemsSource = favorites;

        var watched = allContents
            .Where(c => currentUser.WatchedContentIds.Contains(c.Id))
            .ToList();
        WatchedCollectionView.ItemsSource = watched;

        foreach (var r in allRatings)
        {
            r.Content = allContents.FirstOrDefault(c => c.Id == r.IdContent);
        }
        var myRatings = allRatings
            .Where(r => r.IdUser == currentUser.Id && r.Content != null)
            .Select(r => new
            {
                ContentName = r.Content.Name ?? "Без названия",
                ContentImage = r.Content.Image ?? "default_image",
                StarsText = $"⭐ {r.Stars:F1}/10",
                Feedback = string.IsNullOrWhiteSpace(r.Feedback) ? "Без отзыва" : r.Feedback
            }).ToList();
        RatingsCollectionView.ItemsSource = myRatings;
    }

    private async void Main(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage(db, currentUser));
    }
}