using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace elecciones_api.Models;

public partial class Elecciones2019
{
    [Key]
    public int Id { get; set; }

    public string? Departamento { get; set; }

    public string? Candidato { get; set; }

    public int? Votos { get; set; }
}
