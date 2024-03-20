using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[Keyless]
[Table("ERRORLOG_BK")]
public partial class ErrorlogBk
{
    [Column("COMCOD")]
    [StringLength(4)]
    public string Comcod { get; set; } = null!;

    [Column("ERRORDATETIME", TypeName = "smalldatetime")]
    public DateTime Errordatetime { get; set; }

    [Column("ERRORMESSAGE")]
    public string Errormessage { get; set; } = null!;

    [Column("DATABASENAME")]
    [StringLength(50)]
    public string Databasename { get; set; } = null!;

    [Column("ERR_NUM")]
    public int ErrNum { get; set; }

    [Column("ERR_LINE")]
    public int ErrLine { get; set; }
}
