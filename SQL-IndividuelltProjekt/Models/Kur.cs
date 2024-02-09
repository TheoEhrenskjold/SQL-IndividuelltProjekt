using System;
using System.Collections.Generic;

namespace SQL_IndividuelltProjekt.Models;

public partial class Kur
{
    public int KursId { get; set; }

    public string? Kursnamn { get; set; }

    public virtual ICollection<Betyg> Betygs { get; set; } = new List<Betyg>();
}
