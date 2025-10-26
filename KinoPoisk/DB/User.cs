using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoPoisk.DB
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool HasSubscription { get; set; }

        public List<int> WatchedContentIds { get; set; } = new();  
        public List<int> FavoriteContentIds { get; set; } = new(); 
    }
}
