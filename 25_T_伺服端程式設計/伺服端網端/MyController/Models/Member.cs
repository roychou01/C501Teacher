namespace MyController.Models
{
    //1. 撰寫會員資料表的資料模型
    public class Member
    {
        public string MemberID { get; set; } = string.Empty;
        public string MemberName { get; set; } = null!;
        public string? MemberAddress { get; set; }
        public string MemberPhone { get; set; } = string.Empty;
        public bool Gender { get; set; }       

    }
}
