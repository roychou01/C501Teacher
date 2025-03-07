using Microsoft.AspNetCore.Mvc;
using MyView.Models;

namespace MyView.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            //1.判斷帳號密碼對不對
            //2.導向後台頁面或前台頁面


            if(login.Account=="admin" && login.Password == "12345678")
            {
                //導向後台管理頁面

                return RedirectToAction("Index", "Home");
            }

            ViewData["Error"] = "帳號或密碼有誤!!";
            return View();
        }
    }
}
