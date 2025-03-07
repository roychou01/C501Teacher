using System.ComponentModel.DataAnnotations;
using static MyWebAPI.ValidationAttributes.MyValidator;

namespace MyWebAPI.DTOs
{
    //5.2.3 建立一個ProductPostDTO給Post利用DTO傳遞資料
    public class ProductPostDTO
    {
        //5.3.1 在ProductPostDTO.cs加入需要的內建驗證器(Validator)

        [Required]
        [RegularExpression("[A-Z][1-9][0-9]{3}")]
        public string ProductID { get; set; } = null!;

        [Required]
        [StringLength(40)]
        //5.3.4 在需要使用此驗證器的屬性上加入標籤(這裡範例為ProductName屬性)
        [ProductNameCheck]
        public string ProductName { get; set; } = null!;

        [Required]
        [Range(0,1000000)]
        public decimal Price { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [Required]
        public IFormFile Picture { get; set; } = null!;

        [Required]
        [RegularExpression("[A-Z][1-9]")]
        public string CateID { get; set; } = null!;
    }

    //5.3.3 在ProductPostDTO.cs加入自訂驗證器(使用ValidationAttribute物件)
    //public class ProductNameCheck : ValidationAttribute
    //{
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
          
    //        string productName = value.ToString();
            
    //        if (productName.Length<3)
    //        {
    //            return new ValidationResult("商品名稱至少三個字");
    //        }

    //        return ValidationResult.Success;
    //    }
    //}

}
