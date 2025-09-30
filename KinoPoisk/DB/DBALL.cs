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

        public List<Content> GetContent()
        {
            return Contents;
        }
        public Content GetContentId(int id)
        {
            foreach (Content content in Contents)
            {
                if (content.Id == id)
                {
                    return content;
                }
            }
            return null;
        }

    }
}
