using System;
using System.Collections.Generic;

namespace SQL_IndividuelltProjekt.Models;

public partial class Lärare
{
    public int LärarId { get; set; }

    public string? Namn { get; set; }

    public string? Ämne { get; set; }

    public virtual ICollection<Betyg> Betygs { get; set; } = new List<Betyg>();

    public virtual Personal Lärar { get; set; } = null!;
}
