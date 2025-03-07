using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;


namespace MyModel_CodeFirst.Models
{
    //1.1.2 設計Book類別的各屬性，包括名稱、資料類型及其相關的驗證規則及顯示名稱(Display)
    public class Book
    {
        [Display(Name = "編號")]
        [StringLength(36, MinimumLength = 36)]
        [Key]
        public string BookID { get; set; } = null!;  //採用GUID

        [Display(Name = "主題")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "主題1~30個字")]
        [Required(ErrorMessage = "必填")]
        public string Title { get; set; } = null!;

        [Display(Name = "內容")]
        [Required(ErrorMessage = "必填")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = null!;

        [Display(Name = "發表人")]
        [StringLength(20, ErrorMessage = "發表人最多20字")]
        [Required(ErrorMessage = "必填")]
        public string Author { get; set; } = null!;

        [Display(Name = "照片")]  
        [StringLength(44)]
        public string? Photo { get; set; }  //照片上傳檔名為 GUID+原本的副檔名 XXXXXXXX.jpg

        [HiddenInput]
        public string? ImageType { get; set; }

        [Display(Name = "發布時間")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd  hh:mm:ss}")]
        [HiddenInput]
        public DateTime TimeStamp { get; set; }


        //1.1.5 撰寫兩個類別間的關聯屬性做為未來資料表之間的關聯
        public virtual List<ReBook>? ReBooks { get; set; }
    }
}
