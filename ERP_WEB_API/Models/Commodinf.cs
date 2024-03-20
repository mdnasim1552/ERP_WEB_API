using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[PrimaryKey("Comcod", "Moduleid")]
[Table("COMMODINF")]
public partial class Commodinf
{
    [Key]
    [Column("COMCOD")]
    [StringLength(4)]
    public string Comcod { get; set; } = null!;

    [Key]
    [Column("MODULEID")]
    [StringLength(2)]
    public string Moduleid { get; set; } = null!;

    [Column("MODULENAME")]
    [StringLength(500)]
    public string Modulename { get; set; } = null!;
}
