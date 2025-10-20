using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoPoisk.DB
{
    public class Gerne
    {
        public int Id { get; set; }
        public string Title { get; set; }

    }
    
    public class GerneIs
    {
        public Gerne Gerne { get; set; }
        public bool IsChecked {  get; set; }
    }
}
