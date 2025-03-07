using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyModel_CodeFirst.Models;

namespace MyModel_CodeFirst.ViewComponents
{
    //2.3.3 VCReBooks class繼承ViewComponent(注意using Microsoft.AspNetCore.Mvc;)
    public class VCRebooks:ViewComponent
    {
        private readonly GuestBookContext _context;

        public VCRebooks(GuestBookContext context)
        {
            _context = context;
        }

        //2.3.4 撰寫InvokeAsync()方法取得回覆留言資料
        public async Task<IViewComponentResult> InvokeAsync(string bookID, bool isDel=false)
        {
            //select * from ReBook
            //where BookID = @bookID
            //order by TimeStamp desc
            //
            var rebook = await _context.ReBook.Where(r=>r.BookID == bookID).OrderByDescending(r=>r.TimeStamp).ToListAsync();

            //4.3.4 在VCRebooks ViewComponent中加入isDel參數判斷是否呈現Delete View
            if (isDel)
                return View("Delete",rebook);
                    
            return View(rebook);
        }


      
    }
}
