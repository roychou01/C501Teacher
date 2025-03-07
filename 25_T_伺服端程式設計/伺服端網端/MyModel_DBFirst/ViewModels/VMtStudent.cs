using MyModel_DBFirst.Models;

namespace MyModel_DBFirst.ViewModels
{
    public class VMtStudent
    {
        //5.8.3 撰寫VMtStudent類別
        public List<tStudent>? Students { get; set; }
        public List<Department>? Departments { get; set; }
    }
}
