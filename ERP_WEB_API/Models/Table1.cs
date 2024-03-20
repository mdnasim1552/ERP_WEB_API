using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[Table("Table_1")]
public partial class Table1
{
    [Key]
    [Column("id")]
    [StringLength(50)]
    public string Id { get; set; } = null!;

    [Column("gender")]
    [StringLength(50)]
    public string? Gender { get; set; }
}
