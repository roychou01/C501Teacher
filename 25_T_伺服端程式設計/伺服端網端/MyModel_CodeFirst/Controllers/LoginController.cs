using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyModel_CodeFirst.Models;
using System.Reflection.Metadata;

namespace MyModel_CodeFirst.Controllers
{
    public class LoginController : Controller
    {
        private readonly GuestBookContext _context;

        public LoginController(GuestBookContext context)
        {
            _context = context;
        }

        //5.2.4 建立Get與Post的Login Action
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login login)
        {
            // select * from Login where Account = @Account and Password = @Password
            //var result = await _context.Login.Where(m => m.Account == login.Account && m.Password == login.Password).FirstOrDefaultAsync();

            //string sql = "select * from Login where Account =  '"+ login.Account + "' and Password =  '"+ login.Password +"'";
            
            string sql = "select * from Login where Account = @Account and Password = @Password";

            SqlParameter[] parameters = 
            {
                new SqlParameter("@Account", login.Account),
                new SqlParameter("@Password", login.Password)
            };

            var result = await _context.Login.FromSqlRaw(sql, parameters).FirstOrDefaultAsync();

            //如果帳密正確,導入後台頁面
            if (result != null)
            {
                //5.3.4 在LoginController的Post Login Action中加入Session紀錄登入狀態
                //發給證明,證明他已經登入
                HttpContext.Session.SetString("Manager", result.Account);


                return RedirectToAction("Index", "BooksManage");
            }
            else //如果帳密不正確,回到登入頁面,並告知帳密錯誤
            {
                ViewData["Message"] = "帳號或密碼錯誤";
            }

            return View(result);
        }

        //5.4.1 在LoginController加入Logout Action
        public IActionResult Logout()
        {
            //5.4.2 在Logout Action中清除Session
            //HttpContext.Session.Clear();//清掉所有的Session
            HttpContext.Session.Remove("Manager");//清掉Manager的Session


            return RedirectToAction("Index", "Home");
        }

    }
}
