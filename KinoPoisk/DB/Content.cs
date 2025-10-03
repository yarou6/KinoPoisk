using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoPoisk.DB
{
    public class Content
    {
        public int Id { get; set; }

        public int IdTypeContent { get; set; }

        public TypeContent TypeContent { get; set; }

        public int IdRating { get; set; }

        public Rating Rating { get; set; }

        public bool Subscription { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int IdGerne { get; set; }

        public Gerne Gerne { get; set; }

        public int Age { get; set; }

        public int IdAuthor { get; set; }

        public Author Author { get; set; }

        public DateTime Data { get; set; }

        public int CountSeries { get; set; }

        public string Image { get; set; }
    }
}
