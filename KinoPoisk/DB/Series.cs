using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoPoisk.DB
{
    public class Series
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Data {  get; set; }

        public int IdRating { get; set; }
        public Rating Rating { get; set; }

        public int IdContent { get; set; }

        public Content Content { get; set; }
    }
}
