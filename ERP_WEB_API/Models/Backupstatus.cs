using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[Table("BACKUPSTATUS")]
public partial class Backupstatus
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("COMCOD")]
    [StringLength(4)]
    public string Comcod { get; set; } = null!;

    [Column("FTPPATH")]
    public string Ftppath { get; set; } = null!;

    [Column("LATESTBK")]
    public string Latestbk { get; set; } = null!;

    [Column("LATESTBKCOUNT")]
    public int Latestbkcount { get; set; }

    [Column("LATESTMAXBK")]
    public string Latestmaxbk { get; set; } = null!;

    [Column("UPLDATE")]
    public string Upldate { get; set; } = null!;

    [Column("TOTALFILE")]
    public int Totalfile { get; set; }
}
