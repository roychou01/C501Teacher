using System.ComponentModel.DataAnnotations;
using static MyWebAPI.ValidationAttributes.MyValidator;

namespace MyWebAPI.DTOs
{
    //6.1.6 新增ProductPutDTO類別
    public class ProductPutDTO
    {
        [Required]
        [StringLength(40)]
        [ProductNameCheck]
        public string ProductName { get; set; } = null!;

        [Required]
        [Range(0, 1000000)]
        public decimal Price { get; set; }

        [StringLength(200)]
        public string? Description { get; set; }

        [Required]
        public IFormFile Picture { get; set; } = null!;

      


    }
}
