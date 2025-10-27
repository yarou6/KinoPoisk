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

        BindingContext = this;

        InitSampleData();
    }
    private async void InitSampleData()
    {
        //await db.ClearDatabaseFile();
        //var filmType = new TypeContent { Id = 1, Title = "Фильм" };
        //var seriesType = new TypeContent { Id = 2, Title = "Сериал" };

        //await db.AddTypeContent(filmType);
        //await db.AddTypeContent(seriesType);

        //var action = new Gerne { Id = 1, Title = "Экшн" };
        //var drama = new Gerne { Id = 2, Title = "Драма" };
        //var fantasy = new Gerne { Id = 3, Title = "Фэнтези" };
        //var sciFi = new Gerne { Id = 4, Title = "Научная фантастика" };
        //var thriller = new Gerne { Id = 5, Title = "Триллер" };
        //var comedy = new Gerne { Id = 6, Title = "Комедия" };
        //var adventure = new Gerne { Id = 7, Title = "Приключения" };
        //var crime = new Gerne { Id = 8, Title = "Криминал" };
        //var mystery = new Gerne { Id = 9, Title = "Мистика" };
        //var animation = new Gerne { Id = 10, Title = "Мультфильм" };

        //await db.AddGenre(action);
        //await db.AddGenre(drama);
        //await db.AddGenre(fantasy);
        //await db.AddGenre(sciFi);
        //await db.AddGenre(thriller);
        //await db.AddGenre(comedy);
        //await db.AddGenre(adventure);
        //await db.AddGenre(crime);
        //await db.AddGenre(mystery);
        //await db.AddGenre(animation);


        //var marvel = new Author { Id = 1, Title = "Marvel Studios", Country = "США" };
        //var starWars = new Author { Id = 2, Title = "Lucasfilm", Country = "США" };
        //var netflix = new Author { Id = 3, Title = "Netflix Studios", Country = "США" };
        //var dc = new Author { Id = 4, Title = "DC Films", Country = "США" };
        //var fox = new Author { Id = 5, Title = "20th Century Fox", Country = "Новая Зеландия" };
        //var amazon = new Author { Id = 6, Title = "Amazon Studios", Country = "США" };

        //await db.AddAuthor(marvel);
        //await db.AddAuthor(starWars);
        //await db.AddAuthor(netflix);
        //await db.AddAuthor(dc);
        //await db.AddAuthor(fox);
        //await db.AddAuthor(amazon);

        

        //var contents = new List<Content>
        //{
        //    new Content
        //    {
        //        Id = 1,
        //        Name = "Мстители: Финал",
        //        Description = "Супергеройский фильм о финальной битве Мстителей с Таносом.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ action, drama, sciFi },
        //        Author = marvel,
        //        IdAuthor = 1,
        //        Age = "12+",
        //        Data = new DateTime(2019,4,26),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "avengersendgame"
        //    },
        //    new Content
        //    {
        //        Id = 2,
        //        Name = "Звёздные войны: Пробуждение силы",
        //        Description = "Приключенческий космический эпос о борьбе Сопротивления с Первым Орденом.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ action, adventure, fantasy },
        //        Author = starWars,
        //        IdAuthor = 2,
        //        Age = "12+",
        //        Data = new DateTime(2015,12,18),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "starwarstheforceawakens"
        //    },
        //    new Content
        //    {
        //        Id = 3,
        //        Name = "Джокер",
        //        Description = "Психологический триллер о происхождении одного из самых известных злодеев Готэма.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ drama, thriller, crime },
        //        Author = dc,
        //        IdAuthor = 4,
        //        Age = "18+",
        //        Data = new DateTime(2019,10,4),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "joker"
        //    },
        //    new Content
        //    {
        //        Id = 4,
        //        Name = "Аватар",
        //        Description = "Фантастический эпос о планете Пандора и войне за её ресурсы.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ action, adventure, fantasy, sciFi },
        //        Author = fox,
        //        IdAuthor = 5,
        //        Age = "12+",
        //        Data = new DateTime(2009,12,18),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "avatar"
        //    },
        //    new Content
        //    {
        //        Id = 5,
        //        Name = "Хранители",
        //        Description = "Супергеройский фильм о группе бывших героев, раскрывающих заговор в США.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ action, drama, mystery },
        //        Author = dc,
        //        IdAuthor = 4,
        //        Age = "16+",
        //        Data = new DateTime(2009,3,6),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "watchmen"

        //    },
        //    new Content
        //    {
        //        Id = 6,
        //        Name = "Железный человек",
        //        Description = "История миллиардера Тони Старка, который становится супергероем Железным человеком.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ action, sciFi },
        //        Author = marvel,
        //        IdAuthor = 1,
        //        Age = "12+",
        //        Data = new DateTime(2008,5,2),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "ironman"
        //    },
        //    new Content
        //    {
        //        Id = 7,
        //        Name = "Стражи Галактики",
        //        Description = "Космическая команда героев сражается против угрозы вселенной.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ action, adventure, comedy, sciFi },
        //        Author = marvel,
        //        IdAuthor = 1,
        //        Age = "12+",
        //        Data = new DateTime(2014,8,1),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "guardiansofthegalaxy"
        //    },
        //    new Content
        //    {
        //        Id = 8,
        //        Name = "Властелин колец: Братство кольца",
        //        Description = "Фэнтезийное приключение о путешествии Фродо и его друзей, чтобы уничтожить кольцо.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ adventure, fantasy, drama },
        //        Author = amazon,
        //        IdAuthor = 6,
        //        Age = "12+",
        //        Data = new DateTime(2001,12,19),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "thelordoftheringsthefellowshipofthering"
        //    },
        //    new Content
        //    {
        //        Id = 9,
        //        Name = "Игра престолов",
        //        Description = "Эпический сериал о борьбе за Железный трон и политических интригах в Вестеросе.",
        //        TypeContent = seriesType,
        //        IdTypeContent = 2,
        //        Gernes = new List<Gerne>{ drama, fantasy, adventure },
        //        Author = netflix,
        //        IdAuthor = 3,
        //        Age = "18+",
        //        Data = new DateTime(2011,4,17),
        //        CountSeries = 8,
        //        Subscription = true,
        //        Image = "gameofthrones"
        //    },
        //    new Content
        //    {
        //        Id = 10,
        //        Name = "Шерлок",
        //        Description = "Современная адаптация приключений знаменитого детектива Шерлока Холмса.",
        //        TypeContent = seriesType,
        //        IdTypeContent = 2,
        //        Gernes = new List<Gerne>{ drama, crime, mystery },
        //        Author = netflix,
        //        IdAuthor = 3,
        //        Age = "16+",
        //        Data = new DateTime(2010,7,25),
        //        CountSeries = 4,
        //        Subscription = true,
        //        Image = "sherlock"
        //    },
        //    new Content
        //    {
        //        Id = 11,
        //        Name = "Форсаж 7",
        //        Description = "Экшн-фильм о гонках и семейных ценностях команды Доминика Торетто.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ action, adventure, drama },
        //        Author = fox,
        //        IdAuthor = 5,
        //        Age = "12+",
        //        Data = new DateTime(2015,4,3),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "furious7"
        //    },
        //    new Content
        //    {
        //        Id = 12,
        //        Name = "Интерстеллар",
        //        Description = "Научно-фантастический фильм о путешествии через космос и червоточины для спасения человечества.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ sciFi, drama, adventure },
        //        Author = fox,
        //        IdAuthor = 5,
        //        Age = "12+",
        //        Data = new DateTime(2014,11,7),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "interstellar"
        //    },
        //    new Content
        //    {
        //        Id = 13,
        //        Name = "Лига справедливости Зака Снайдера",
        //        Description = "Супергеройский фильм, объединяющий героев DC для спасения мира.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ action, adventure, fantasy },
        //        Author = dc,
        //        IdAuthor = 4,
        //        Age = "12+",
        //        Data = new DateTime(2021,3,18),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "justiceleague"
        //    },
        //    new Content
        //    {
        //        Id = 14,
        //        Name = "Тор: Рагнарёк",
        //        Description = "Фантастический приключенческий фильм о Торе, который борется за спасение Асгарда.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ action, adventure, comedy, fantasy },
        //        Author = marvel,
        //        IdAuthor = 1,
        //        Age = "12+",
        //        Data = new DateTime(2017,11,3),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "thorragnarok"
        //    },
        //    new Content
        //    {
        //        Id = 15,
        //        Name = "Веном",
        //        Description = "Фильм о журналисте Эдди Броке и симбиоте Веноме, превращающем его в антигероя.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ action, sciFi, thriller },
        //        Author = fox,
        //        IdAuthor = 5,
        //        Age = "16+",
        //        Data = new DateTime(2018,10,5),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "venom"
        //    },
        //    new Content
        //    {
        //        Id = 16,
        //        Name = "Тёмный рыцарь",
        //        Description = "Фильм о Бэтмене и его борьбе с Джокером в Готэме.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ action, drama, crime },
        //        Author = dc,
        //        IdAuthor = 4,
        //        Age = "16+",
        //        Data = new DateTime(2008,7,18),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "thedarkknight"
        //    },
        //    new Content
        //    {
        //        Id = 17,
        //        Name = "Лунтик и его друзья",
        //        Description = "Весёлый мультфильм о приключениях Лунтика и его друзей.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ animation, comedy, adventure },
        //        Author = amazon,
        //        IdAuthor = 6,
        //        Age = "0+",
        //        Data = new DateTime(2006,6,1),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "luntik"
        //    },
        //    new Content
        //    {
        //        Id = 18,
        //        Name = "Стражи Галактики. Часть 2",
        //        Description = "Продолжение приключений Стражей Галактики в космосе.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ action, adventure, comedy, sciFi },
        //        Author = marvel,
        //        IdAuthor = 1,
        //        Age = "12+",
        //        Data = new DateTime(2017,5,5),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "guardiansofthegalaxyvol2"
        //    },
        //    new Content
        //    {
        //        Id = 19,
        //        Name = "Валериан и город тысячи планет",
        //        Description = "Научно-фантастический фильм о спецагентах, защищающих миры во вселенной.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ action, adventure, sciFi },
        //        Author = fox,
        //        IdAuthor = 5,
        //        Age = "12+",
        //        Data = new DateTime(2017,7,21),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "valerianandthecity"
        //    },
        //    new Content
        //    {
        //        Id = 20,
        //        Name = "Бегущий по лезвию 2049",
        //        Description = "Фантастический триллер о будущем, где андроиды и люди сосуществуют.",
        //        TypeContent = filmType,
        //        IdTypeContent = 1,
        //        Gernes = new List<Gerne>{ drama, sciFi, thriller },
        //        Author = fox,
        //        IdAuthor = 5,
        //        Age = "18+",
        //        Data = new DateTime(2017,10,6),
        //        CountSeries = 1,
        //        Subscription = true,
        //        Image = "bladerunner2049"
        //    }
        //};
        //int ratingId = 1;
        //var random = new Random();

        //foreach (var content in contents)
        //{
        //    await db.AddContent(content);

        //    var rating = new Rating
        //    {
        //        Id = ratingId++,
        //        Stars = Math.Round(random.NextDouble() * 4 + 6, 1),
        //        Feedback = "Отзыв отсутствует",
        //        IdContent = content.Id,
        //        Content = content
        //    };
        //    await db.AddRating(rating);
        //}
        await LoadTopRatedContent();
    }
    private async Task LoadTopRatedContent()
    {
        var contents = await db.GetContents();
        var ratings = await db.GetRating();

        var allMovies = contents.Select(c =>
        {
            double stars = c.GetAverageRating(ratings);

            return new
            {
                c.Id,
                c.Name,
                c.Description,
                c.Image,
                Rating = stars,
                RatingText = $"⭐ {stars:F1}/10",
                Subscription = c.Subscription && !currentUser.HasSubscription
            };
        })
        .OrderByDescending(c => c.Rating)
        .ToList();

        TopMoviesCollectionView.ItemsSource = allMovies.Take(10);

        AllMoviesCollectionView.ItemsSource = allMovies;

        MovieSearchBar.TextChanged += (s, e) =>
        {
            if (string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                AllMoviesCollectionView.ItemsSource = allMovies;
                return;
            }

            var filtered = allMovies
                .Where(m => m.Name.Contains(e.NewTextValue, StringComparison.OrdinalIgnoreCase)
                         || m.Description.Contains(e.NewTextValue, StringComparison.OrdinalIgnoreCase))
                .ToList();

            AllMoviesCollectionView.ItemsSource = filtered;
        };
    }

    private async void MoviesSeries(object sender, EventArgs e)
    {
        var frame = sender as Frame;
        if (frame?.BindingContext == null)
            return;

        dynamic movie = frame.BindingContext;

        var content = await db.GetContentId((int)movie.Id);


        if (content.Subscription && !currentUser.HasSubscription)
        {
            await DisplayAlert("Нет Доступа", "Для просмотра этого фильма нужна подписка.", "ОК");
            return;
        }

        await Navigation.PushAsync(new MediaPage(content, db, currentUser));
    }
    private async void Profile(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProfilePage(db, currentUser));
    }
    public async void RefreshData()
    {
        await LoadTopRatedContent();
    }
    protected override void OnDisappearing()
    {
        base.OnDisappearing();

        if (Navigation.NavigationStack.OfType<MainPage>().FirstOrDefault() is MainPage mainPage)
        {
            mainPage.RefreshData();
        }
    }
}

