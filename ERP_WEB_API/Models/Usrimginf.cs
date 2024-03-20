using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[PrimaryKey("Comcod", "Usrid")]
[Table("USRIMGINF")]
public partial class Usrimginf
{
    [Key]
    [Column("COMCOD")]
    [StringLength(4)]
    public string Comcod { get; set; } = null!;

    [Key]
    [Column("USRID")]
    [StringLength(7)]
    public string Usrid { get; set; } = null!;

    [Column("USRIMG")]
    public byte[]? Usrimg { get; set; }

    [Column("REMARKS")]
    [StringLength(250)]
    public string Remarks { get; set; } = null!;

    [Column("USRSIGN")]
    public byte[]? Usrsign { get; set; }
}
