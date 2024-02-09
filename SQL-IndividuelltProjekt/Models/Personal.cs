using System;
using System.Collections.Generic;

namespace SQL_IndividuelltProjekt.Models;

public partial class Personal
{
    public int PersonalId { get; set; }

    public string? Namn { get; set; }

    public string? Befattning { get; set; }

    public virtual Lärare? Lärare { get; set; }
}
