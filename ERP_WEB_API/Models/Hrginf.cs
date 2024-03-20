using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[PrimaryKey("Comcod", "Hrgcod")]
[Table("HRGINF", Schema = "dbo_hrm")]
public partial class Hrginf
{
    [Key]
    [Column("COMCOD")]
    [StringLength(4)]
    public string Comcod { get; set; } = null!;

    [Key]
    [Column("HRGCOD")]
    [StringLength(7)]
    public string Hrgcod { get; set; } = null!;

    [Column("HRGDESC")]
    [StringLength(250)]
    public string? Hrgdesc { get; set; }

    [Column("HRGDESCB")]
    [StringLength(250)]
    public string? Hrgdescb { get; set; }

    [Column("HRGVAL")]
    [StringLength(1)]
    public string? Hrgval { get; set; }

    [Column("PERCNT", TypeName = "decimal(18, 6)")]
    public decimal? Percnt { get; set; }

    [Column("UNIT")]
    [StringLength(10)]
    public string? Unit { get; set; }

    [Column("RATE", TypeName = "decimal(18, 6)")]
    public decimal? Rate { get; set; }

    [Column("SLNO")]
    public int? Slno { get; set; }

    [Column("RANKCODE")]
    [StringLength(50)]
    public string? Rankcode { get; set; }

    [Column("HRGDESCBN")]
    [StringLength(250)]
    public string? Hrgdescbn { get; set; }

    [ForeignKey("Comcod")]
    [InverseProperty("Hrginfs")]
    public virtual Compinf ComcodNavigation { get; set; } = null!;
}
