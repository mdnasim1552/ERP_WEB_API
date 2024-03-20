using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[Table("USERROLE")]
public partial class Userrole
{
    [Key]
    [Column("ROLEID")]
    [StringLength(5)]
    public string Roleid { get; set; } = null!;

    [Column("ROLE")]
    [StringLength(100)]
    public string Role { get; set; } = null!;

    [InverseProperty("UserroleNavigation")]
    public virtual ICollection<Userinf> Userinfs { get; set; } = new List<Userinf>();
}
