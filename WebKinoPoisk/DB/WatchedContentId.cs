using System;
using System.Collections.Generic;

namespace WebKinoPoisk.DB;

public partial class WatchedContentId
{
    public int IdUser { get; set; }

    public int IdContent { get; set; }

    public virtual Content IdContentNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
