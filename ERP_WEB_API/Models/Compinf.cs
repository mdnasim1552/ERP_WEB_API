using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[Table("COMPINF")]
[Index("Comsnam", Name = "IX_COMPINF", IsUnique = true)]
public partial class Compinf
{
    [Key]
    [Column("COMCOD")]
    [StringLength(4)]
    public string Comcod { get; set; } = null!;

    [Column("COMSNAM")]
    [StringLength(100)]
    public string Comsnam { get; set; } = null!;

    [Column("COMNAM")]
    [StringLength(100)]
    public string Comnam { get; set; } = null!;

    [Column("COMADD1")]
    [StringLength(100)]
    public string Comadd1 { get; set; } = null!;

    [Column("COMADD2")]
    [StringLength(100)]
    public string Comadd2 { get; set; } = null!;

    [Column("COMADD3")]
    [StringLength(100)]
    public string Comadd3 { get; set; } = null!;

    [Column("COMADD4")]
    [StringLength(100)]
    public string Comadd4 { get; set; } = null!;

    [InverseProperty("ComcodNavigation")]
    public virtual ICollection<Hrginf> Hrginfs { get; set; } = new List<Hrginf>();

    [InverseProperty("ComcodNavigation")]
    public virtual ICollection<Interface> Interfaces { get; set; } = new List<Interface>();
}
