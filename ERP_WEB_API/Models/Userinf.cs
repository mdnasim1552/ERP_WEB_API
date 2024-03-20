using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[PrimaryKey("Comcod", "Usrid")]
[Table("USERINF")]
public partial class Userinf
{
    [Key]
    [Column("COMCOD")]
    [StringLength(4)]
    public string Comcod { get; set; } = null!;

    [Key]
    [Column("USRID")]
    [StringLength(7)]
    public string Usrid { get; set; } = null!;

    [Column("USRSNAME")]
    [StringLength(20)]
    public string Usrsname { get; set; } = null!;

    [Column("USRNAME")]
    [StringLength(80)]
    public string Usrname { get; set; } = null!;

    [Column("USRDESIG")]
    [StringLength(50)]
    public string Usrdesig { get; set; } = null!;

    [Column("USRACTIVE")]
    public bool Usractive { get; set; }

    [Column("USRPASS")]
    [StringLength(100)]
    [Unicode(false)]
    public string Usrpass { get; set; } = null!;

    [Column("MAILID")]
    [StringLength(50)]
    public string Mailid { get; set; } = null!;

    [Column("EMPID")]
    [StringLength(50)]
    public string Empid { get; set; } = null!;

    [Column("USERROLE")]
    [StringLength(5)]
    public string Userrole { get; set; } = null!;

    [ForeignKey("Userrole")]
    [InverseProperty("Userinfs")]
    public virtual Userrole UserroleNavigation { get; set; } = null!;
}
