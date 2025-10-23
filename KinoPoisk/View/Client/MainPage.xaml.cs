using KinoPoisk.DB;
namespace KinoPoisk.View.Client;
public partial class MainPage : ContentPage
{
    private User currentUser;
    private DBALL db;
    public MainPage(DBALL database, User user)
    {
        InitializeComponent();
        db = database;
        currentUser = user;
         
        WelcomeLabel.Text = $"Добро пожаловать, {currentUser.Login}!";
        RoleLabel.Text = currentUser.IsAdmin ? "Роль: Админ" : "Роль: Пользователь";
        SubscriptionLabel.Text = currentUser.HasSubscription ? "Подписка: есть" : "Подписка: нет";
         
        InitSampleData();
    }
    private async void InitSampleData()
        {
        //var contents = await db.GetContents();

        //var film1 = new Content
        //{
        //    Id = 1,
        //    Name = "Inception",
        //    Description = "Фантастический триллер о снах и реальности.",
        //    Image = "inception",
        //    Data = new DateTime(2010, 7, 16),
        //    Age = "16",
        //    Subscription = false,
        //    CountSeries = 1
        //};

        //var film2 = new Content
        //{
        //    Id = 2,
        //    Name = "Interstellar",
        //    Description = "Путешествие за пределы галактики ради спасения человечества.",
        //    Image = "interstellar",
        //    Data = new DateTime(2014, 11, 7),
        //    Age = "12",
        //    Subscription = true,
        //    CountSeries = 1
        //};

        //var film3 = new Content
        //{
        //    Id = 3,
        //    Name = "Breaking Bad",
        //    Description = "Учитель химии становится наркобароном.",
        //    Image = "breakingbad",
        //    Data = new DateTime(2008, 1, 20),
        //    Age = "18",
        //    Subscription = true,
        //    CountSeries = 5
        //};
        //var film4 = new Content
        //{
        //    Id = 4,
        //    Name = "The Matrix",
        //    Description = "Культовый научно-фантастический боевик о виртуальной реальности.",
        //    Image = "matrix",
        //    Data = new DateTime(1999, 3, 31),
        //    Age = "16",
        //    Subscription = false,
        //    CountSeries = 1
        //};

        //var film5 = new Content
        //{
        //    Id = 5,
        //    Name = "The Witcher",
        //    Description = "Фэнтези-сериал о ведьмаке, который охотится на чудовищ.",
        //    Image = "witcher",
        //    Data = new DateTime(2019, 12, 20),
        //    Age = "18",
        //    Subscription = true,
        //    CountSeries = 2
        //};

        //var film6 = new Content
        //{
        //    Id = 6,
        //    Name = "Stranger Things",
        //    Description = "Детективно-фантастический сериал с мистическими событиями в маленьком городе.",
        //    Image = "strangerthings",
        //    Data = new DateTime(2016, 7, 15),
        //    Age = "14",
        //    Subscription = true,
        //    CountSeries = 4
        //};

        //await db.AddContent(film1);
        //await db.AddContent(film2);
        //await db.AddContent(film3);
        //await db.AddContent(film4);
        //await db.AddContent(film5);
        //await db.AddContent(film6);

        //await db.AddRating(new Rating { Id = 1, Stars = 9 });
        //await db.AddRating(new Rating { Id = 2, Stars = 10 });
        //await db.AddRating(new Rating { Id = 3, Stars = 9.5 });
        //await db.AddRating(new Rating { Id = 4, Stars = 8.5 });
        //await db.AddRating(new Rating { Id = 5, Stars = 9 });
        //await db.AddRating(new Rating { Id = 6, Stars = 8.7 });
        LoadTopRatedContent();
        }
        private async Task LoadTopRatedContent()
        {
            var contents = await db.GetContents();
            var ratings = await db.GetRating();

            var contentWithRatings = contents.Select(c =>
            {
                var rating = ratings.FirstOrDefault(r => r.Id == c.Id);
                double stars = rating?.Stars ?? 0;

                return new
                {
                    c.Id,
                    c.Name,
                    c.Description,
                    c.Image,
                    Rating = stars,
                    RatingText = $"⭐ {stars}/10"
                };
            })
            .OrderByDescending(c => c.Rating)
            .ToList();

            MoviesCollectionView.ItemsSource = contentWithRatings;
        }

        private async void MoviesSeries(object sender, EventArgs e)
        {
            var frame = sender as Frame;
            if (frame?.BindingContext == null)
                return;

            dynamic movie = frame.BindingContext;

            var rating = await db.GetRatingId((int)movie.Id);
            var content = await db.GetContentId((int)movie.Id);


            if (content.Subscription && !currentUser.HasSubscription)
            {
                await DisplayAlert("Подписка", "Для просмотра этого фильма нужна подписка.", "ОК");
            }
            else
            {
                await Navigation.PushAsync(new MediaPage(content, rating));
            }
        }
        private async void Profile(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProfilePage());
        }

        private void MoviesSeries(object sender, TappedEventArgs e)
        {

        }
    }

