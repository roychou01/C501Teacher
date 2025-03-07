using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyModel_DBFirst.Models;

public partial class tStudent
{
    //3.2 撰寫在View上顯示的欄位內容(Display)
    //3.3 撰寫在表單上的欄位驗證規則(需using System.ComponentModel.DataAnnotations)

    [Display(Name ="學號")]
    [Required(ErrorMessage ="必填")]
    [RegularExpression("1[1-9][0-9]{4}",ErrorMessage = "格式錯誤(ex:1○○○○○)")]
    public string fStuId { get; set; } = null!;

    [Display(Name = "姓名")]
    [Required(ErrorMessage = "必填")]
    [StringLength(30,ErrorMessage ="姓名最多30個字")]
    public string fName { get; set; } = null!;

    [Display(Name = "E-Mail")]
    [StringLength(40)]
    [EmailAddress(ErrorMessage ="E-Mail格式錯誤")]
    public string? fEmail { get; set; }

    [Display(Name = "成績")]
    [Range(0,100,ErrorMessage ="請填0-100的整數")]
    public int? fScore { get; set; }

    //5.2.3 修改tStudent Class以建立與Department的關聯，內容如下
    //5.1.2 在tStudent Class中增加一個屬性 public string DeptID { get; set; }
    [Display(Name = "科系")]
    [ForeignKey("Department")]
    public string DeptID { get; set; } = null!;  //這個屬性事實上是指F.K

    
    public virtual Department? Department { get; set; }  //用來描述跟Deparment的關係

}
