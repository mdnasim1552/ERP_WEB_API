using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[Table("TbleCity")]
public partial class TbleCity
{
    [Key]
    [Column("cityId")]
    public int CityId { get; set; }

    [Column("cityName")]
    [StringLength(255)]
    public string CityName { get; set; } = null!;

    [Column("countryId")]
    public int? CountryId { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("TbleCities")]
    public virtual TblCountry? Country { get; set; }

    [InverseProperty("UserCityNavigation")]
    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
