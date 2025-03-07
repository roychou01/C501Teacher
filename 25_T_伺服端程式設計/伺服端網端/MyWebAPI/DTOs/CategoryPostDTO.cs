using System.ComponentModel.DataAnnotations;
using MyWebAPI.Models;
using static MyWebAPI.ValidationAttributes.MyValidator;

namespace MyWebAPI.DTOs
{
    public class CategoryPostDTO
    {
        //5.3.7 在CategoryPostDTO.cs加入需要的內建驗證器(Validator)
        
        [Required]
        [RegularExpression("[A-Z][1-9]")]
        public string CateID { get; set; } = null!;

        [Required]
        [StringLength(20)]
        //5.3.9 在需要使用此驗證器的屬性上加入標籤
        [CategoryNameCheck]
        public string CateName { get; set; } = null!;
    }

    //5.3.8 在CategoryPostDTO.cs加入自訂驗證器(使用ValidationAttribute物件)
    //public class CategoryNameCheck : ValidationAttribute
    //{
    //    //假設類別名稱不可以重複
    //    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    //    {
    //        GoodStoreContext2 _context = validationContext.GetService<GoodStoreContext2>();


    //        var findName = _context.Category.Where(c => c.CateName == value.ToString());
    //        if (findName.Any())
    //        {
    //            return new ValidationResult("類別名稱重複");
    //        }


    //        return ValidationResult.Success;
    //    }
    //}
}
