using System;
using System.Collections.Generic;

namespace WebKinoPoisk.DB;

public partial class Author
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Content> Contents { get; set; } = new List<Content>();
}
