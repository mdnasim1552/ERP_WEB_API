using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[Table("TblCountry")]
public partial class TblCountry
{
    [Key]
    [Column("countryId")]
    public int CountryId { get; set; }

    [Column("countryName")]
    [StringLength(255)]
    public string CountryName { get; set; } = null!;

    [InverseProperty("Country")]
    public virtual ICollection<TbleCity> TbleCities { get; set; } = new List<TbleCity>();
}
