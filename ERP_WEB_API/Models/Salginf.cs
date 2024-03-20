using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[PrimaryKey("Comcod", "Gcod")]
[Table("SALGINF")]
public partial class Salginf
{
    [Key]
    [Column("COMCOD")]
    [StringLength(4)]
    public string Comcod { get; set; } = null!;

    [Key]
    [Column("GCOD")]
    [StringLength(9)]
    public string Gcod { get; set; } = null!;

    [Column("GDESC")]
    [StringLength(250)]
    public string Gdesc { get; set; } = null!;

    [Column("GVAL")]
    [StringLength(1)]
    public string Gval { get; set; } = null!;

    [Column("SYMBOL")]
    [StringLength(50)]
    public string Symbol { get; set; } = null!;

    [Column("SLNO")]
    public int Slno { get; set; }

    [Column("COLOR")]
    [StringLength(150)]
    public string Color { get; set; } = null!;

    [Column("DETAILS", TypeName = "xml")]
    public string? Details { get; set; }
}
