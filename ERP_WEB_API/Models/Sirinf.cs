using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[PrimaryKey("Comcod", "Sircode")]
[Table("SIRINF")]
public partial class Sirinf
{
    [Key]
    [Column("COMCOD")]
    [StringLength(4)]
    public string Comcod { get; set; } = null!;

    [Key]
    [Column("SIRCODE")]
    [StringLength(12)]
    public string Sircode { get; set; } = null!;

    [Column("SIRDESC")]
    [StringLength(1000)]
    public string Sirdesc { get; set; } = null!;

    [Column("SIRDESCB")]
    [StringLength(500)]
    public string Sirdescb { get; set; } = null!;

    [Column("SIRTYPE")]
    [StringLength(100)]
    public string Sirtype { get; set; } = null!;

    [Column("SIRVAL", TypeName = "decimal(18, 6)")]
    public decimal Sirval { get; set; }

    [Column("SIRTDES")]
    [StringLength(250)]
    public string Sirtdes { get; set; } = null!;

    [Column("INCOTERMS")]
    [StringLength(5)]
    public string Incoterms { get; set; } = null!;

    [Column("SIRUNIT")]
    [StringLength(50)]
    public string Sirunit { get; set; } = null!;

    [Column("SINFQTY", TypeName = "decimal(18, 6)")]
    public decimal Sinfqty { get; set; }

    [Column("ACTCODE")]
    [StringLength(12)]
    public string Actcode { get; set; } = null!;

    [Column("USERCODE")]
    [StringLength(12)]
    public string Usercode { get; set; } = null!;

    [Column("MARK", TypeName = "decimal(18, 6)")]
    public decimal Mark { get; set; }

    [Column("EMPID")]
    [StringLength(12)]
    public string Empid { get; set; } = null!;

    [Column("DEPTCOD")]
    [StringLength(12)]
    public string Deptcod { get; set; } = null!;

    [Column("METHOD")]
    [StringLength(1)]
    public string Method { get; set; } = null!;

    [Column("STDDUR", TypeName = "decimal(18, 6)")]
    public decimal Stddur { get; set; }

    [Column("UNTCOD")]
    [StringLength(5)]
    public string Untcod { get; set; } = null!;

    [Column("ROWDATE", TypeName = "smalldatetime")]
    public DateTime Rowdate { get; set; }

    [Column("SIZEBLE")]
    public bool Sizeble { get; set; }

    [Column("HRCOMADD")]
    [StringLength(250)]
    public string Hrcomadd { get; set; } = null!;

    [Column("HRCOMADDB")]
    [StringLength(250)]
    public string Hrcomaddb { get; set; } = null!;

    [Column("HRCOMNAME")]
    [StringLength(250)]
    public string Hrcomname { get; set; } = null!;

    [Column("ALLOWANCE", TypeName = "decimal(18, 6)")]
    public decimal Allowance { get; set; }

    [Column("PRODPROCESS")]
    [StringLength(12)]
    public string Prodprocess { get; set; } = null!;

    [Column("HRSECTION")]
    [StringLength(5)]
    public string Hrsection { get; set; } = null!;

    [Column("SL")]
    public int Sl { get; set; }

    public bool Convertible { get; set; }
}
