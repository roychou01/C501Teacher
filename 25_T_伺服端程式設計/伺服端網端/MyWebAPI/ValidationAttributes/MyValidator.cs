using MyWebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.ValidationAttributes
{
    //8.0.2 將原本寫在ProductPostDTO及CategoryPostDTO內的自訂驗證類別(ValidationAttributes)貼進MyValidator.cs檔案中
    public class MyValidator
    {

        public class CategoryNameCheck : ValidationAttribute
        {
            //假設類別名稱不可以重複
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                GoodStoreContext2 _context = validationContext.GetService<GoodStoreContext2>();


                var findName = _context.Category.Where(c => c.CateName == value.ToString());
                if (findName.Any())
                {
                    return new ValidationResult("類別名稱重複");
                }


                return ValidationResult.Success;
            }
        }

        public class ProductNameCheck : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {

                string productName = value.ToString();

                if (productName.Length < 3)
                {
                    return new ValidationResult("商品名稱至少三個字");
                }

                return ValidationResult.Success;
            }
        }
    }
}
