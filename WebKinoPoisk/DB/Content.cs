using System;
using System.Collections.Generic;

namespace WebKinoPoisk.DB;

public partial class Content
{
    public int Id { get; set; }

    public int IdTypeContent { get; set; }

    public bool Subscription { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Age { get; set; } = null!;

    public int IdAuthor { get; set; }

    public DateTime Data { get; set; }

    public int CountSeries { get; set; }

    public string Image { get; set; } = null!;

    public virtual Author IdAuthorNavigation { get; set; } = null!;

    public virtual TypeContent IdTypeContentNavigation { get; set; } = null!;

    public virtual ICollection<Rating> Ratings { get; set; } = new List<Rating>();

    public virtual ICollection<Series> Series { get; set; } = new List<Series>();
}
