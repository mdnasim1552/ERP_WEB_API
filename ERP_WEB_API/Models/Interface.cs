using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[PrimaryKey("Comcod", "Interfaceid")]
[Table("INTERFACE")]
public partial class Interface
{
    [Key]
    [Column("COMCOD")]
    [StringLength(4)]
    public string Comcod { get; set; } = null!;

    [Key]
    [Column("INTERFACEID")]
    [StringLength(3)]
    public string Interfaceid { get; set; } = null!;

    [Column("INTERFACENAME")]
    [StringLength(250)]
    public string Interfacename { get; set; } = null!;

    [ForeignKey("Comcod")]
    [InverseProperty("Interfaces")]
    public virtual Compinf ComcodNavigation { get; set; } = null!;
}
