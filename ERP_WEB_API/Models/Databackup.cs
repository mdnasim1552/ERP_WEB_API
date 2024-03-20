using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[Table("DATABACKUP")]
public partial class Databackup
{
    [Key]
    [Column("COMCOD")]
    [StringLength(4)]
    public string Comcod { get; set; } = null!;

    [Column("BAKPATH")]
    [StringLength(500)]
    public string Bakpath { get; set; } = null!;

    [Column("ZIPPATH")]
    [StringLength(500)]
    public string Zippath { get; set; } = null!;

    [Column("FTPUSERNAME")]
    [StringLength(50)]
    public string Ftpusername { get; set; } = null!;

    [Column("FTPPASSWORD")]
    [StringLength(50)]
    public string Ftppassword { get; set; } = null!;

    [Column("FTPUPLOADPATH")]
    [StringLength(500)]
    public string Ftpuploadpath { get; set; } = null!;

    [Column("FTPSERVER")]
    [StringLength(500)]
    public string Ftpserver { get; set; } = null!;
}
