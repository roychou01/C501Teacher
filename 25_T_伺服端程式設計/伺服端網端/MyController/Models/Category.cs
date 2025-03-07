namespace MyController.Models
{
    public class Category
    {
        public int CateID { get; set; }
        public string CateName { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Photo { get; set; }
    }
}
