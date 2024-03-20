using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[PrimaryKey("Comcod", "Actcode")]
[Table("ACINF")]
public partial class Acinf
{
    [Key]
    [Column("COMCOD")]
    [StringLength(4)]
    public string Comcod { get; set; } = null!;

    [Key]
    [Column("ACTCODE")]
    [StringLength(12)]
    public string Actcode { get; set; } = null!;

    [Column("ACTDESC")]
    [StringLength(100)]
    public string Actdesc { get; set; } = null!;

    [Column("ACTELEV")]
    [StringLength(10)]
    public string Actelev { get; set; } = null!;

    [Column("ACTTYPE")]
    [StringLength(20)]
    public string Acttype { get; set; } = null!;

    [Column("ACTTDESC")]
    [StringLength(100)]
    public string Acttdesc { get; set; } = null!;

    [Column("USERCODE")]
    [StringLength(12)]
    public string Usercode { get; set; } = null!;

    [Column("ACTIVE")]
    public bool Active { get; set; }

    [Column("WODESC")]
    [StringLength(50)]
    public string Wodesc { get; set; } = null!;

    [Column("ACGCODE")]
    [StringLength(8)]
    public string Acgcode { get; set; } = null!;

    [Column("CFCODE")]
    [StringLength(8)]
    public string Cfcode { get; set; } = null!;

    [Column("DOCPATH")]
    [StringLength(500)]
    public string Docpath { get; set; } = null!;
}
