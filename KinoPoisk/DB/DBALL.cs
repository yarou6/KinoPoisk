using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoPoisk.DB
{
    public class DBALL
    {
        List<Content> Contents;

        List<Author> Authors;

        List<Gerne> Gernes;

        List<Rating> Ratings;

        List<Series> Series;

        List<TypeContent> TypeContents;

        public void AddContent(Content content) => Contents.Add(content);
        public void UpdateContent(Content updated)
        {
            var content = Contents.FirstOrDefault(c => c.Id == updated.Id);
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
        public void RemoveContent(int id) => Contents.RemoveAll(c => c.Id == id);
        public List<Content> GetContents() => Contents;
        public void GetContentId(int id) => Contents.FirstOrDefault(c => c.Id == id);



        public void AddAuthor(Author author) => Authors.Add(author);
        public void UpdateAuthor(Author updated) 
        {
            var author = Authors.FirstOrDefault(c => c.Id == updated.Id);
            if(author != null)
            {
                author.Title = updated.Title;
                author.Country = updated.Country;
            }
        }
        public void RemoveAuthor(int id) => Authors.RemoveAll(c => c.Id == id);
        public List<Author> GetAuthors() => Authors;
        public void GetAuthorId(int id) => Authors.FirstOrDefault(c => c.Id == id); 




        public void AddGenre(Gerne genre) => Gernes.Add(genre);
        public void UpdateGerne(Gerne updated) 
        { 
            var genre = Gernes.FirstOrDefault(c => c.Id == updated.Id);
            if (genre != null)
            {
                genre.Title = updated.Title;
            }
        }
        public void RemoveGerne(int id) => Gernes.RemoveAll(c => c.Id == id);
        public List<Gerne> GetGernes() => Gernes;
        public void GetGerneId(int id) => Gernes.FirstOrDefault(c => c.Id == id);




        public void AddRating(Rating rating) => Ratings.Add(rating);
        public void UpdateRating(Rating updated)
        {
            var rating = Ratings.FirstOrDefault(c => c.Id == updated.Id);
            if(rating != null)
            {
                rating.Stars = updated.Stars;
                rating.Feedback = updated.Feedback;
            }
        }
        public void RemoveRating(int id) => Ratings.RemoveAll(c => c.Id == id);
        public List<Rating> GetRating() => Ratings;
        public void GetRatingId(int id) => Ratings.FirstOrDefault(c => c.Id == id);



        public void AddSeries(Series series) => Series.Add(series);
        public void UpdateSeries(Series updated)
        {
            var series = Series.FirstOrDefault(c =>c.Id == updated.Id);
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
        public void RemoveSeries(int id) => Series.RemoveAll(c => c.Id ==id);
        public List<Series> GetSeries() => Series;
        public void GetSeriesId(int id) => Series.FirstOrDefault(s => s.Id == id);


        public void AddTypeContent(TypeContent typeContent) => TypeContents.Add(typeContent);
        public void UpdateTypeContent(TypeContent updated) 
        {
            var typeContent = TypeContents.FirstOrDefault(c => c.Id == updated.Id);
            if(typeContent != null)
            {
                typeContent.Title = updated.Title;
            }
        }
        public void RemoveTypeContent(int id) => TypeContents.RemoveAll(c => c.Id == id);
        public List<TypeContent> GetTypeContent() => TypeContents;
        public void GetTypeContentId(int id) => TypeContents.FirstOrDefault(c => c.Id == id);









        private List<User> Users = new();
        public void RemoveUser(int id) => Users.RemoveAll(u => u.Id == id);
        public User GetUserById(int id) => Users.FirstOrDefault(u => u.Id == id);
        public List<User> GetUsers() => Users;
        public User Authenticate(string login, string password)
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
        public void InitAdmin()
        {
            if (!Users.Any(u => u.IsAdmin))
            {
                Users.Add(new User
                {
                    Id = 1,
                    Login = "admin",
                    Password = "admin123", 
                    IsAdmin = true,
                    HasSubscription = true
                });
            }
        }
    }
}
