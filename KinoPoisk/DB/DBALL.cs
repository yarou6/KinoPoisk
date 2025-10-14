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

        public async Task AddContent(Content content)
        { 
            await Task.Delay(1000);  
            contents.Add(content);
        }
        public async Task UpdateContent(Content updated)
        {
            await Task.Delay(1000);
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
        public async Task RemoveContent(int id) 
        {
            await Task.Delay(1000);
            contents.RemoveAll(c => c.Id == id);
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
            await Task.Delay(1000);

            if (author.Id != 0)
                author.Id = authors.Max(с => с.Id) + 1;
            else
                author.Id = 0;

            authors.Add(author);
        }
        public async Task UpdateAuthor(Author updated)
        {
            await Task.Delay(1000);
            var author = authors.FirstOrDefault(c => c.Id == updated.Id);
            if(author != null)
            {
                author.Title = updated.Title;
                author.Country = updated.Country;
            }
        }
        public async Task RemoveAuthor(int id) 
        { 
            await Task.Delay(1000);  
            authors.RemoveAll(c => c.Id == id); 
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
            await Task.Delay(1000);
            gernes.Add(genre);
        }
        public async Task UpdateGerne(Gerne updated)
        {
            await Task.Delay(1000);
            var genre = gernes.FirstOrDefault(c => c.Id == updated.Id);
            if (genre != null)
            {
                genre.Title = updated.Title;
            }
        }
        public async Task RemoveGerne(int id)
        {
            await Task.Delay(1000); 
            gernes.RemoveAll(c => c.Id == id); 
        }
        public async Task<List<Gerne>> GetGernes() 
        { 
            await Task.Delay(1000); 
            return new List<Gerne>( gernes); 
        }
        public async Task<Gerne> GetGerneId(int id)
        {
            await Task.Delay(1000);
            var obj = gernes.FirstOrDefault(c => c.Id == id);
            return obj;
        }




        public async Task AddRating(Rating rating) 
        { 
            await Task.Delay(1000); 
            ratings.Add(rating);
        }
        public async Task UpdateRating(Rating updated)
        {
            await Task.Delay(1000);
            var rating = ratings.FirstOrDefault(c => c.Id == updated.Id);
            if(rating != null)
            {
                rating.Stars = updated.Stars;
                rating.Feedback = updated.Feedback;
            }
        }
        public async Task RemoveRating(int id)
        { 
            await Task.Delay(1000); 
            ratings.RemoveAll(c => c.Id == id);
        }
        public async Task<List<Rating>> GetRating() 
        {
            await Task.Delay(1000);
            return new List<Rating>( ratings);
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
            this.series.Add(series); 
        }
        public async Task UpdateSeries(Series updated)
        {
            await Task.Delay(1000);
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
        public async Task RemoveSeries(int id)
        {
            await Task.Delay(1000); 
            series.RemoveAll(c => c.Id ==id);
        }
        public async Task<List<Series>> GetSeries() 
        {
            await Task.Delay(1000);
            return new List<Series>( series); 
        }
        public async Task<Series> GetSeriesId(int id)
        { 
            await Task.Delay(1000);
            var obj = series.FirstOrDefault(s => s.Id == id);
            return obj;
        }


        public async Task AddTypeContent(TypeContent typeContent)
        { 
            await Task.Delay(1000); 
            typeContents.Add(typeContent);
        }
        public async Task UpdateTypeContent(TypeContent updated)
        {
            await Task.Delay(1000);
            var typeContent = typeContents.FirstOrDefault(c => c.Id == updated.Id);
            if(typeContent != null)
            {
                typeContent.Title = updated.Title;
            }
        }
        public async Task RemoveTypeContent(int id)
        {
            await Task.Delay(1000);
            typeContents.RemoveAll(c => c.Id == id);
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








        private List<User> users = new();
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
            return new List<User>( users); 
        }
        public async Task<User> Authenticate(string login, string password)
        {
            await Task.Delay(1000);
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
            return true;
        }
        public async Task InitAdmin()
        {
            await Task.Delay(1000);
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
            }
        }
    }
}
