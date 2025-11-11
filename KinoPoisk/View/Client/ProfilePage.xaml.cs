using KinoPoisk.DB;

namespace KinoPoisk.View.Client;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
        LoadData();
    }

    private async void LoadData()
    {
        var db = await DBALL.GetDB();
        var allContents = await db.GetContents();
        var allRatings = await db.GetRating();

        var favorites = allContents
            .Where(c => User.GetUser().FavoriteContentIds.Contains(c.Id))
            .ToList();
        FavoriteCollectionView.ItemsSource = favorites;

        var watched = allContents
            .Where(c => User.GetUser().WatchedContentIds.Contains(c.Id))
            .ToList();
        WatchedCollectionView.ItemsSource = watched;

        foreach (var r in allRatings)
        {
            r.Content = allContents.FirstOrDefault(c => c.Id == r.IdContent);
        }
        var myRatings = allRatings
            .Where(r => r.IdUser == User.GetUser().Id && r.Content != null)
            .Select(r => new
            {
                ContentName = r.Content.Name ?? "Без названия",
                ContentImage = r.Content.Image ?? "default_image",
                StarsText = $"⭐ {r.Stars:F1}/10",
                Feedback = string.IsNullOrWhiteSpace(r.Feedback) ? "Без отзыва" : r.Feedback
            }).ToList();
        RatingsCollectionView.ItemsSource = myRatings;
    }
    public void RefreshData()
    {
        LoadData();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (Navigation.NavigationStack.OfType<ProfilePage>().FirstOrDefault() is ProfilePage profilePage)
        {
            profilePage.RefreshData();
        }
    }
    //private async void Main(object sender, EventArgs e)
    //{
    //    //await Navigation.PushAsync(new MainPage(db, currentUser));
    //}
}