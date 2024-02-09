using System;
using System.Collections.Generic;

namespace SQL_IndividuelltProjekt.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? Namn { get; set; }

    public int? Personnummer { get; set; }

    public int? KlassId { get; set; }
}
