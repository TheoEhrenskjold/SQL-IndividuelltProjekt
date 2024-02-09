using System;
using System.Collections.Generic;

namespace SQL_IndividuelltProjekt.Models;

public partial class Betyg
{
    public int BetygsId { get; set; }

    public int? StudentId { get; set; }

    public int? KursId { get; set; }

    public int? LärarId { get; set; }

    public int Betyg1 { get; set; }

    public DateTime? Datum { get; set; }

    public virtual Kur? Kurs { get; set; }

    public virtual Lärare? Lärar { get; set; }
}
