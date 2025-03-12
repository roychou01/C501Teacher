using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodStore.Models;

public class ProductData
{
    [Display(Name = "品名")]
    public string ProductName { get; set; } = null!;

    [Display(Name = "價格")]
    [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
    public decimal Price { get; set; }

    [Display(Name = "商品描述")]
    [DataType(DataType.MultilineText)]
    public string? Description { get; set; }

}

[ModelMetadataType(typeof(ProductData))]
public partial class Product
{ 

}



public class MemberData
{

    [Display(Name = "會員姓名")]
    [Required(ErrorMessage = "必填")]
    public string Name { get; set; } = null!;
    [Display(Name = "性別")]
    public bool Gender { get; set; }

    [Display(Name = "點數")]
    public int Point { get; set; }

    [Key]
    [Display(Name = "帳號", Prompt = "5-10碼英數字")]
    [StringLength(10, MinimumLength = 5, ErrorMessage = "帳號為5-10碼")]
    [RegularExpression("[A-Za-z][A-Za-z0-9]{4,9}", ErrorMessage = "帳號格式有誤")]
    [Required(ErrorMessage = "必填")]
    public string Account { get; set; } = null!;

    [Display(Name = "密碼",Prompt ="密碼為8-16碼")]
    [Required(ErrorMessage = "必填")]
    [StringLength(16, MinimumLength = 8, ErrorMessage = "密碼為8-16碼")]
    [MinLength(8)]
    [MaxLength(16)]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;
}

[ModelMetadataType(typeof(MemberData))]
public partial class Member
{

    [NotMapped]
    [Display(Name = "再填一次密碼", Prompt = "密碼為8-16碼")]
    [Required(ErrorMessage = "必填")]
    [Compare(nameof(Password), ErrorMessage = "密碼兩次輸入不相同")]
    [DataType(DataType.Password)]
    public string PasswordConfirm { get; set; } = null!;
}



public partial class OrderDetail
{
    //public decimal SubTotal => Price * Qty;

    [NotMapped]
    [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
    public decimal SubTotal 
    {
        get
        {
            return Price * Qty;
        }
    }

}

[ModelMetadataType(typeof(OrderData))]
public partial class Order
{
    
}


public class OrderData
{

    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime OrderDate { get; set; }
}