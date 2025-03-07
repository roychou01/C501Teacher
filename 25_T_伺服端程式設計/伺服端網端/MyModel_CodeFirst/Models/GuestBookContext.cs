using Microsoft.EntityFrameworkCore;

namespace MyModel_CodeFirst.Models
{
    //1.2.2 撰寫GuestBookContext類別的內容
    //      (1)須繼承DbContext類別
    public class GuestBookContext:DbContext
    {
        //(2)撰寫依賴注入用的建構子
        public GuestBookContext(DbContextOptions<GuestBookContext> options):base(options)
        {

        }

        //(3)描述資料庫裡面的資料表
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<ReBook> ReBook { get; set; }

        //5.1.5 修改GuestBookContext類別的內容，加入描述資料庫裡Login的資料表
        public virtual DbSet<Login> Login { get; set; }

    }
}
