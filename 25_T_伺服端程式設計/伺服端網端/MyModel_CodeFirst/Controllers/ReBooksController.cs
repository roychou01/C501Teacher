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
    public class ReBooksController : Controller
    {
        private readonly GuestBookContext _context;

        public ReBooksController(GuestBookContext context)
        {
            _context = context;
        }

        //2.5.4 修改RePostBooksController，僅保留Create Action，其它全部刪除
        public IActionResult Create(string BookID)//2.5.9 傳遞BookID參數
        {
            ViewData["BookID"] = BookID;//2.5.9 傳遞BookID參數
            return View();
        }

        // POST: ReBooks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReBookID,Description,Author,TimeStamp,BookID")] ReBook reBook)
        {
            reBook.TimeStamp= DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Add(reBook);
                await _context.SaveChangesAsync();

                //2.5.12 修改ReBooksController中的Create Action，使其Return JSON資料
                //return RedirectToAction("Display","PostBooks", new { id=reBook.BookID});
                return Json(reBook);
            }

            //ViewData["BookID"] = new SelectList(_context.Book, "BookID", "BookID", reBook.BookID);

            //return View("Display", "PostBooks", reBook);
            //2.5.12 修改ReBooksController中的Create Action，使其Return JSON資料
            return Json(reBook);
        }

        //2.5.15 在ReBooksController中撰寫自VCRebook ViewComponent取得回覆留言資料的Action
        public IActionResult GetRebookByViewComponent(string id)
        {
            return ViewComponent("VCRebooks", new { bookID=id});
        }


    }
}
