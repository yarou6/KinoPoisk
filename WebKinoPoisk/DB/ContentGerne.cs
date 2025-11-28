using System;
using System.Collections.Generic;

namespace WebKinoPoisk.DB;

public partial class ContentGerne
{
    public int IdContent { get; set; }

    public int IdGerne { get; set; }

    public virtual Content IdContentNavigation { get; set; } = null!;

    public virtual Gerne IdGerneNavigation { get; set; } = null!;
}
