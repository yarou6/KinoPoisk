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
        public string Stars { get; set; }

        public string Feedback { get; set; }
    }
}
