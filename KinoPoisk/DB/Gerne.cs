using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KinoPoisk.DB
{
    public class Gerne
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonIgnore]
        public List<Content> Contents { get; set; }=new List<Content>();
    }
    
    public class GerneIs
    {
        public Gerne Gerne { get; set; }
        public bool IsChecked {  get; set; }
    }
}
