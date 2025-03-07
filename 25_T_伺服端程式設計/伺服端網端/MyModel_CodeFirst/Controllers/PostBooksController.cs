using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyModel_CodeFirst.Models;

namespace MyModel_CodeFirst.Controllers
{
    public class PostBooksController : Controller
    {
        private readonly GuestBookContext _context;

        public PostBooksController(GuestBookContext context)
        {
            _context = context;
        }

        //2.1.6 修改Index Action的寫法
        public async Task<IActionResult> Index()
        {

            var books = await _context.Book.OrderByDescending(b => b.TimeStamp).ToListAsync();

            return View(books);
        }

        //2.2.2 將PostBooksController中Details Action改名為Display(View也要改名字)
        public async Task<IActionResult> Display(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.BookID == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: PostBooks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookID,Title,Description,Author,Photo,ImageType,TimeStamp")] Book book, IFormFile? newPhoto)
        {
         
            book.TimeStamp = DateTime.Now;

            //3.4.6 修改Post Create Action，加上處理上傳照片的功能
            if (newPhoto != null && newPhoto.Length != 0) 
            {
                //執行上傳照片的動作

                //只允許上傳圖片檔
                if (newPhoto.ContentType != "image/jpeg" && newPhoto.ContentType != "image/png")
                {
                    ViewData["Message"] = "請上傳jpg或png格式的檔案!!";
                    return View(book);
                }


                // 取得檔案名稱
                string fileName = book.BookID + ".jpg";

                // 用一個BookPhotosPath變數儲存路徑
                string BookPhotosPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "BookPhotos", fileName);//取得目的路徑
                
                // 把檔案儲存於伺服器上
                using (FileStream stream = new FileStream(BookPhotosPath, FileMode.Create))
                {
                    newPhoto.CopyTo(stream);
                }

                book.ImageType = newPhoto.ContentType;
                book.Photo = fileName;
            }

            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }


        //6.1.1 在PostBooksController裡寫一個會發生例外的Action如下
        public IActionResult ExceptionTest()
        {
            int a = 0;

            int s = 100 / a;
            return View();
        }
        private bool BookExists(string id)
        {
            return _context.Book.Any(e => e.BookID == id);
        }
    }
}
