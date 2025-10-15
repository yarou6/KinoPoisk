using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoPoisk.DB
{
    public class Rating
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public string Feedback { get; set; }
        public int IdContent {get; set; }
        public Content Content { get; set; }
    }
}
