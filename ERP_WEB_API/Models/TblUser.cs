using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ERP_WEB_API.Models;

[Index("EmailNo", Name = "UQ__TblUsers__8735459CFA10FB37", IsUnique = true)]
[Index("PhoneNo", Name = "UQ__TblUsers__960F17EF01394B20", IsUnique = true)]
public partial class TblUser
{
    [Key]
    [Column("userId")]
    [StringLength(100)]
    public string UserId { get; set; } = null!;

    [Column("fName")]
    [StringLength(100)]
    public string FName { get; set; } = null!;

    [Column("lName")]
    [StringLength(100)]
    public string? LName { get; set; }

    [Column("phoneNo")]
    [StringLength(11)]
    [Unicode(false)]
    public string PhoneNo { get; set; } = null!;

    [Column("emailNo")]
    [StringLength(50)]
    [Unicode(false)]
    public string EmailNo { get; set; } = null!;

    [Column("userCity")]
    public int? UserCity { get; set; }

    [Column("userImg")]
    [StringLength(3000)]
    public string? UserImg { get; set; }

    [Column("userCV")]
    [StringLength(3000)]
    public string? UserCv { get; set; }

    [Column("password")]
    [StringLength(500)]
    public string? Password { get; set; }

    [Column("dob", TypeName = "datetime")]
    public DateTime? Dob { get; set; }

    [ForeignKey("UserCity")]
    [InverseProperty("TblUsers")]
    public virtual TbleCity? UserCityNavigation { get; set; }
}
