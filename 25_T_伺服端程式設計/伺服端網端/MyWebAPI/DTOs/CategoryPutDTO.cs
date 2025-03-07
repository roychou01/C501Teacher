using System.ComponentModel.DataAnnotations;
using static MyWebAPI.ValidationAttributes.MyValidator;

namespace MyWebAPI.DTOs
{
    //6.1.3 新增CategoryPutDTO類別
    public class CategoryPutDTO
    {
        [Required]
        [StringLength(20)]
        [CategoryNameCheck]
        public string CateName { get; set; } = null!;
    }
}
