using System;
using System.Collections.Generic;

namespace WebKinoPoisk.DB;

public partial class Series
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Data { get; set; }

    public int IdRating { get; set; }

    public int IdContent { get; set; }

    public virtual Content IdContentNavigation { get; set; } = null!;

    public virtual Rating IdRatingNavigation { get; set; } = null!;
}
