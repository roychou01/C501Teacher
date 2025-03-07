using System.ComponentModel.DataAnnotations;

namespace MyView.Models
{
    public class NightMarket
    {
        [Display(Name="夜市代碼")]
        [Required(ErrorMessage ="必填")]
        [RegularExpression("A[0-9]{2}",ErrorMessage ="格式錯誤")]
        public string ID { get; set; }

        [Display(Name = "夜市名稱")]
        [Required(ErrorMessage = "必填")]
        [StringLength(20,ErrorMessage ="最長20個字")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "夜市地址")]
        [Required(ErrorMessage = "必填")]
        [StringLength(50, ErrorMessage = "最長50個字")]
        public string Address { get; set; } = string.Empty;
    }
}
