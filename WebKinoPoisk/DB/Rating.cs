using System;
using System.Collections.Generic;

namespace WebKinoPoisk.DB;

public partial class Rating
{
    public int Id { get; set; }

    public string Status { get; set; } = null!;

    public string Feedback { get; set; } = null!;

    public int IdContent { get; set; }

    public int IdUser { get; set; }

    public virtual Content IdContentNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;

    public virtual ICollection<Series> Series { get; set; } = new List<Series>();
}
