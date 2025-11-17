using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoPoisk.DB
{
    public class TypeContent
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public override string ToString()
        {
            return $"{Title}";
        }

    }
}
