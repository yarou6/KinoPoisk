using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoPoisk.DB
{
    public class DBALL
    {
        List<Content> contents = new();

        List<Author> authors = new();

        List<Gerne> gernes = new();

        List<Rating> ratings = new();

        List<Series> series = new();

        List<TypeContent> typeContents = new();

        public async Task AddContent(Content content) => contents.Add(content);
        public async Task UpdateContent(Content updated)
        {
            var content = contents.FirstOrDefault(c => c.Id == updated.Id);
            if(content != null)
            {
                content.IdTypeContent = updated.IdTypeContent;
                content.TypeContent = updated.TypeContent;

                content.IdRating = updated.IdRating;
                content.Rating = updated.Rating;

                content.IdGerne = updated.IdGerne;
                content.Gerne = updated.Gerne;

                content.IdAuthor = updated.IdAuthor;
                content.Author = updated.Author;

                content.Subscription = updated.Subscription;
                content.Name = updated.Name;
                content.Description = updated.Description;
                content.Data = updated.Data;
                content.CountSeries = updated.CountSeries;
                content.Age = updated.Age;
            }
        }
        public async Task RemoveContent(int id) => contents.RemoveAll(c => c.Id == id);
        public async Task<List<Content>> GetContents() => contents;
        public async Task GetContentId(int id) => contents.FirstOrDefault(c => c.Id == id);



        public async Task AddAuthor(Author author)
        {
            await Task.Delay(1000);

            if (author.Id != 0)
                author.Id = authors.Max(с => с.Id) + 1;
            else
                author.Id = 0;

            authors.Add(author);
        }
        public async Task UpdateAuthor(Author updated) 
        {
            var author = authors.FirstOrDefault(c => c.Id == updated.Id);
            if(author != null)
            {
                author.Title = updated.Title;
                author.Country = updated.Country;
            }
        }
        public async Task RemoveAuthor(int id) => authors.RemoveAll(c => c.Id == id);
        public async Task<List<Author>> GetAuthors() => authors;
        public async Task GetAuthorId(int id) => authors.FirstOrDefault(c => c.Id == id); 




        public async Task AddGenre(Gerne genre) => gernes.Add(genre);
        public async Task UpdateGerne(Gerne updated) 
        { 
            var genre = gernes.FirstOrDefault(c => c.Id == updated.Id);
            if (genre != null)
            {
                genre.Title = updated.Title;
            }
        }
        public async Task RemoveGerne(int id) => gernes.RemoveAll(c => c.Id == id);
        public async Task<List<Gerne>> GetGernes() => gernes;
        public async Task GetGerneId(int id) => gernes.FirstOrDefault(c => c.Id == id);




        public async Task AddRating(Rating rating) => ratings.Add(rating);
        public async Task UpdateRating(Rating updated)
        {
            var rating = ratings.FirstOrDefault(c => c.Id == updated.Id);
            if(rating != null)
            {
                rating.Stars = updated.Stars;
                rating.Feedback = updated.Feedback;
            }
        }
        public async Task RemoveRating(int id) => ratings.RemoveAll(c => c.Id == id);
        public async Task<List<Rating>> GetRating() => ratings;
        public async Task GetRatingId(int id) => ratings.FirstOrDefault(c => c.Id == id);



        public async Task AddSeries(Series series) => this.series.Add(series);
        public async Task UpdateSeries(Series updated)
        {
            var series = this.series.FirstOrDefault(c => c.Id == updated.Id);
            if(series != null)
            {
                series.Name = updated.Name;
                series.Description = updated.Description;
                series.Data = updated.Data;

                series.IdRating = updated.IdRating;
                series.Rating = updated.Rating;

                series.IdContent = updated.IdContent;
                series.Content = updated.Content;
            }
        }
        public async Task RemoveSeries(int id) => series.RemoveAll(c => c.Id ==id);
        public async Task<List<Series>> GetSeries() => series;
        public async Task GetSeriesId(int id) => series.FirstOrDefault(s => s.Id == id);


        public async Task AddTypeContent(TypeContent typeContent) => typeContents.Add(typeContent);
        public async Task UpdateTypeContent(TypeContent updated) 
        {
            var typeContent = typeContents.FirstOrDefault(c => c.Id == updated.Id);
            if(typeContent != null)
            {
                typeContent.Title = updated.Title;
            }
        }
        public async Task RemoveTypeContent(int id) => typeContents.RemoveAll(c => c.Id == id);
        public async Task<List<TypeContent>> GetTypeContent() => typeContents;
        public async Task GetTypeContentId(int id) => typeContents.FirstOrDefault(c => c.Id == id);









        private List<User> Users = new();
        public async Task RemoveUser(int id) => Users.RemoveAll(u => u.Id == id);
        public async Task<User> GetUserById(int id) => Users.FirstOrDefault(u => u.Id == id);
        public async Task<List<User>> GetUsers() => Users;
        public async Task<User> Authenticate(string login, string password)
        {
            return Users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }
        public bool Register(string login, string password, bool isAdmin = false, bool hasSubscription = false)
        {
            if (Users.Any(u => u.Login == login))
                return false;

            var user = new User
            {
                Id = Users.Count > 0 ? Users.Max(u => u.Id) + 1 : 1,
                Login = login,
                Password = password,
                IsAdmin = isAdmin,
                HasSubscription = hasSubscription
            }; 

            Users.Add(user);
            return true;
        }
        public async Task InitAdmin()
        {
            if (!Users.Any(u => u.IsAdmin))
            {
                Users.Add(new User
                {
                    Id = 1,
                    Login = "admin",
                    Password = "admin", 
                    IsAdmin = true,
                    HasSubscription = true
                });

                Users.Add(new User
                {
                    Id = 2,
                    Login = "123",
                    Password = "123",
                    IsAdmin = false,
                    HasSubscription = true
                });
            }
        }
    }
}
