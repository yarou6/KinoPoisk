using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
namespace KinoPoisk.DB
{
    public class DBDTO
    {
        public List<Content> contents { get; set; }
        public List<Author> authors { get; set; }
        public List<Gerne> gernes { get; set; }
        public List<Rating> ratings { get; set; }
        public List<Series> series { get; set; }
        public List<TypeContent> typeContents { get; set; }
        public List<User> users { get; set; }
        public int aecontent { get; set; }
        public int aeauthor { get; set; }
        public int aegerne { get; set; }
        public int aerating { get; set; }
        public int aeseries { get; set; }
        public int aetypecontents { get; set; }
    }
    public class DBALL
    {
        List<Content> contents = new();
        List<Author> authors = new();
        List<Gerne> gernes = new();
        List<Rating> ratings = new();
        List<Series> series = new();
        List<TypeContent> typeContents = new();
        List<User> users = new();

        int aecontent = 0;
        int aeauthor = 0;
        int aegerne = 0;
        int aerating = 0;
        int aeseries = 0;
        int aetypecontents = 0;
        
        private DBALL dBALL;

        public static implicit operator DBDTO(DBALL dBALL)
        {
            var read = new DBDTO();
            read.contents = dBALL.contents;
            read.authors = dBALL.authors;
            read.gernes = dBALL.gernes;
            read.ratings = dBALL.ratings;
            read.series = dBALL.series;
            read.typeContents = dBALL.typeContents;
            read.users = dBALL.users;

            read.aecontent = dBALL.aecontent;
            read.aeauthor = dBALL.aeauthor;
            read.aegerne = dBALL.aegerne;
            read.aerating = dBALL.aerating;
            read.aeseries = dBALL.aeseries;
            read.aetypecontents = dBALL.aetypecontents;
            return read;
        }
        public static void ConverterOn(DBALL dBALL, DBDTO dBDTO)
        {
            dBALL.contents = dBDTO.contents;
            dBALL.authors = dBDTO.authors;
            dBALL.gernes = dBDTO.gernes;
            dBALL.ratings = dBDTO.ratings;
            dBALL.series = dBDTO.series;
            dBALL.typeContents = dBDTO.typeContents;
            dBALL.users = dBDTO.users ?? new List<User>();

            dBALL.aecontent = dBDTO.aecontent;
            dBALL.aeauthor = dBDTO.aeauthor;
            dBALL.aegerne = dBDTO.aegerne;
            dBALL.aerating = dBDTO.aerating;
            dBALL.aeseries = dBDTO.aeseries;
            dBALL.aetypecontents = dBDTO.aetypecontents;
        }

        public async Task<DBALL> GetDB()
        {
            await Task.Delay(1000);
            //File.Delete(FileSystem.Current.AppDataDirectory + "/test.txt");
            //File.Create(FileSystem.Current.AppDataDirectory + "/test.txt");

            if (dBALL == null)
            {
                dBALL = this;
                if (File.Exists(FileSystem.Current.AppDataDirectory + "/test.txt"))
                    await ReadFiles();

                await InitAdmin();
            }
            return dBALL;

        }
        public async Task ReadFiles()
        {
            string fr = await File.ReadAllTextAsync(FileSystem.Current.AppDataDirectory + "/test.txt");

            DBDTO dbDTO = null;
            try { dbDTO = JsonSerializer.Deserialize<DBDTO>(fr); } catch (Exception e) { }

            if (dbDTO == null) return;

            ConverterOn(this, dbDTO);
        }
        public async Task SaveFile()
        {
            try
            {
               await File.WriteAllTextAsync(FileSystem.Current.AppDataDirectory + "/test.txt", JsonSerializer.Serialize((DBDTO)this));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка сохранения: " + ex.Message);
            }
        }

        public async Task AddContent(Content content)
        {
            await Task.Delay(100);
            content.Id = aecontent;
            contents.Add(content);
            aecontent++;
            await SaveFile();
        }
        public async Task UpdateContent(Content updated)
        {
            await Task.Delay(1000);
            var content = contents.FirstOrDefault(c => c.Id == updated.Id);
            if (content != null)
            {
                content.IdTypeContent = updated.IdTypeContent;
                content.TypeContent = updated.TypeContent;

                content.Gernes = updated.Gernes;
                content.IdAuthor = updated.IdAuthor;
                content.Author = updated.Author;

                content.Subscription = updated.Subscription;
                content.Name = updated.Name;
                content.Description = updated.Description;
                content.Data = updated.Data;
                content.CountSeries = updated.CountSeries;
                content.Age = updated.Age;

                foreach (Gerne genre in content.Gernes)
                {
                    if (!genre.Contents.Contains(content))
                        genre.Contents.Add(content);
                    await UpdateGerne(genre);
                }
            }
            await SaveFile();
        }
        public async Task RemoveContent(int id)
        {
            await Task.Delay(1000);
            contents.RemoveAll(c => c.Id == id);
            await SaveFile();
        }
        public async Task<List<Content>> GetContents()
        {
            await Task.Delay(1000);
            return new List<Content>(contents);
        }
        public async Task<Content> GetContentId(int id)
        {
            await Task.Delay(1000);
            var obj = contents.FirstOrDefault(c => c.Id == id);
            return obj;
        }



        public async Task AddAuthor(Author author)
        {
            await Task.Delay(100);
            author.Id = aeauthor;
            authors.Add(author);
            aeauthor++;
            await SaveFile();
        }
        public async Task UpdateAuthor(Author updated)
        {
            await Task.Delay(1000);
            var author = authors.FirstOrDefault(c => c.Id == updated.Id);
            if (author != null)
            {
                author.Title = updated.Title;
                author.Country = updated.Country;
            }
            await SaveFile();
        }
        public async Task RemoveAuthor(int id)
        {
            await Task.Delay(1000);
            authors.RemoveAll(c => c.Id == id);
            await SaveFile();
        }
        public async Task<List<Author>> GetAuthors()
        {
            await Task.Delay(1000);
            return authors;
        }
        public async Task<Author> GetAuthorId(int id)
        {
            await Task.Delay(1000);
            var obj = authors.FirstOrDefault(c => c.Id == id);
            return obj;
        }




        public async Task AddGenre(Gerne genre)
        {
            await Task.Delay(100);
            genre.Id = aegerne;
            gernes.Add(genre);
            aegerne++;
            await SaveFile();
        }
        public async Task UpdateGerne(Gerne updated)
        {
            await Task.Delay(1000);
            var genre = gernes.FirstOrDefault(c => c.Id == updated.Id);
            if (genre != null)
            {
                genre.Title = updated.Title;
            }
            await SaveFile();
        }
        public async Task RemoveGerne(int id)
        {
            await Task.Delay(1000);
            gernes.RemoveAll(c => c.Id == id);
            await SaveFile();
        }
        public async Task<List<Gerne>> GetGernes()
        {
            await Task.Delay(1000);
            return new List<Gerne>(gernes);
        }
        public async Task<Gerne> GetGerneId(int id)
        {
            await Task.Delay(1000);
            var obj = gernes.FirstOrDefault(c => c.Id == id);
            return obj;
        }




        public async Task AddRating(Rating rating)
        {
            await Task.Delay(100);
            rating.Id = aerating;
            ratings.Add(rating);
            aerating++;
            await SaveFile();
        }
        public async Task UpdateRating(Rating updated)
        {
            await Task.Delay(1000);
            var rating = ratings.FirstOrDefault(c => c.Id == updated.Id);
            if (rating != null)
            {
                rating.Stars = updated.Stars;
                rating.Feedback = updated.Feedback;
                rating.Content = updated.Content;
                rating.IdContent = updated.IdContent;
            }
            await SaveFile();
        }
        public async Task RemoveRating(int id)
        {
            await Task.Delay(1000);
            ratings.RemoveAll(c => c.Id == id);
            await SaveFile();
        }
        public async Task<List<Rating>> GetRating()
        {
            await Task.Delay(1000);
            return new List<Rating>(ratings);
        }
        public async Task<Rating> GetRatingId(int id)
        {
            await Task.Delay(1000);
            var obj = ratings.FirstOrDefault(c => c.Id == id);
            return obj;
        }



        public async Task AddSeries(Series series)
        {
            await Task.Delay(1000);
            series.Id = aerating;
            this.series.Add(series);
            aeseries++;
            await SaveFile();
        }
        public async Task UpdateSeries(Series updated)
        {
            await Task.Delay(1000);
            var series = this.series.FirstOrDefault(c => c.Id == updated.Id);
            if (series != null)
            {
                series.Name = updated.Name;
                series.Description = updated.Description;
                series.Data = updated.Data;

                series.IdRating = updated.IdRating;
                series.Rating = updated.Rating;

                series.IdContent = updated.IdContent;
                series.Content = updated.Content;
            }
            await SaveFile();
        }
        public async Task RemoveSeries(int id)
        {
            await Task.Delay(1000);
            series.RemoveAll(c => c.Id == id);
            await SaveFile();
        }
        public async Task<List<Series>> GetSeries()
        {
            await Task.Delay(1000);
            return new List<Series>(series);
        }
        public async Task<Series> GetSeriesId(int id)
        {
            await Task.Delay(1000);
            var obj = series.FirstOrDefault(s => s.Id == id);
            return obj;
        }


        public async Task AddTypeContent(TypeContent typeContent)
        {
            await Task.Delay(100);
            typeContent.Id = aetypecontents;
            typeContents.Add(typeContent);
            aetypecontents++;
            await SaveFile();
        }
        public async Task UpdateTypeContent(TypeContent updated)
        {
            await Task.Delay(1000);
            var typeContent = typeContents.FirstOrDefault(c => c.Id == updated.Id);
            if (typeContent != null)
            {
                typeContent.Title = updated.Title;
            }
            await SaveFile();
        }
        public async Task RemoveTypeContent(int id)
        {
            await Task.Delay(1000);
            typeContents.RemoveAll(c => c.Id == id);
            await SaveFile();
        }
        public async Task<List<TypeContent>> GetTypeContent()
        {
            await Task.Delay(1000);
            return new List<TypeContent>(typeContents);
        }
        public async Task<TypeContent> GetTypeContentId(int id)
        {
            await Task.Delay(1000);
            var obj = typeContents.FirstOrDefault(s => s.Id == id);
            return obj;

        }


        public async Task RemoveUser(int id)
        {
            await Task.Delay(1000);
            users.RemoveAll(u => u.Id == id);
        }
        public async Task<User> GetUserById(int id)
        {
            await Task.Delay(1000);
            var obj = users.FirstOrDefault(u => u.Id == id);
            return obj;
        }
        public async Task<List<User>> GetUsers()
        {
            await Task.Delay(1000);
            return new List<User>(users);
        }
        public async Task<User> Authenticate(string login, string password)
        {
            await Task.Delay(1000);
            if (users == null)
                users = new List<User>();
            var obj = users.FirstOrDefault(u => u.Login == login && u.Password == password);
            return obj;
        }
        public async Task<bool> Register(string login, string password, bool isAdmin = false, bool hasSubscription = false)
        {
            await Task.Delay(1000);
            if (users.Any(u => u.Login == login))
                return false;

            var user = new User
            {
                Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1,
                Login = login,
                Password = password,
                IsAdmin = isAdmin,
                HasSubscription = hasSubscription
            };

            users.Add(user);
            await SaveFile();
            return true;
        }
        /// <summary>
        /// ненужное
        /// </summary>
        /// <returns></returns>
        public async Task InitAdmin()
        {
            await Task.Delay(1000);
            if (users == null) users = new List<User>();
            if (!users.Any(u => u.IsAdmin))
            {
                users.Add(new User
                {
                    Id = 1,
                    Login = "admin",
                    Password = "admin",
                    IsAdmin = true,
                    HasSubscription = true
                });

                users.Add(new User
                {
                    Id = 2,
                    Login = "123",
                    Password = "123",
                    IsAdmin = false,
                    HasSubscription = true
                });

                users.Add(new User
                {
                    Id = 3,
                    Login = "321",
                    Password = "321",
                    IsAdmin = false,
                    HasSubscription = false
                });
            }
        }


        public async Task ClearDatabaseFile()
        {
            await Task.Delay(1000);
            string path = Path.Combine(FileSystem.Current.AppDataDirectory, "test.txt");

            if (File.Exists(path))
                File.Delete(path);

            contents.Clear();
            authors.Clear();
            gernes.Clear();
            ratings.Clear();
            series.Clear();
            typeContents.Clear();

            aecontent = 0;
            aeauthor = 0;
            aegerne = 0;
            aerating = 0;
            aeseries = 0;
            aetypecontents = 0;

            await Task.CompletedTask;
        }

        public async Task AddOrUpdateRating(int contentId, int userId, double stars, string feedback)
        {
            await Task.Delay(1000);

            var existingRating = ratings.FirstOrDefault(r => r.IdUser == userId && r.IdContent == contentId);

            if (existingRating != null)
            {
                existingRating.Stars = stars;
                existingRating.Feedback = feedback;
                await UpdateRating(existingRating);
            }
            else
            {
                var newRating = new Rating
                {
                    Id = ratings.Any() ? ratings.Max(r => r.Id) + 1 : 1,
                    IdUser = userId,
                    IdContent = contentId,
                    Stars = stars,
                    Feedback = feedback
                };
                await AddRating(newRating);
            }

            var content = await GetContentId(contentId);
            double average = content.GetAverageRating(await GetRating());
            Console.WriteLine($"Новая средняя оценка для {content.Name}: {average}");
        }
        public async Task MarkAsWatched(int userId, int contentId)
        {
            await Task.Delay(1000);

            var user = await GetUserById(userId);
            if (user != null && !user.WatchedContentIds.Contains(contentId))
            {
                user.WatchedContentIds.Add(contentId);
                await SaveFile();
            }
        }

        public async Task ToggleFavorite(int userId, int contentId)
        {
            await Task.Delay(1000);

            var user = await GetUserById(userId);
            if (user != null)
            {
                if (user.FavoriteContentIds.Contains(contentId))
                    user.FavoriteContentIds.Remove(contentId);
                else
                    user.FavoriteContentIds.Add(contentId);

                await SaveFile();
            }
        }
    }
}
