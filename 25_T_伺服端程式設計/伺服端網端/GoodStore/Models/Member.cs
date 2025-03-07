using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodStore.Models;

public partial class Member
{
    public string MemberID { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool Gender { get; set; }

    public int Point { get; set; }

    [Key]
    [Display(Name = "帳號")]
    [StringLength(10, MinimumLength = 5, ErrorMessage = "帳號為5-10碼")]
    [RegularExpression("[A-Za-z][A-Za-z0-9]{4,9}", ErrorMessage = "帳號格式有誤")]
    [Required(ErrorMessage = "必填")]
    public string Account { get; set; } = null!;

    [Display(Name = "密碼")]
    [Required(ErrorMessage = "必填")]
    [StringLength(16, MinimumLength = 8, ErrorMessage = "密碼為8-16碼")]
    [MinLength(8)]
    [MaxLength(16)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    public virtual ICollection<Order> Order { get; set; } = new List<Order>();
}
