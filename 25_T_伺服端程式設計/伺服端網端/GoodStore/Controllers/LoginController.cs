using GoodStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Diagnostics.Metrics;

namespace GoodStore.Controllers
{
    public class LoginController : Controller
    {
        private readonly GoodStoreContext _context;

        public LoginController(GoodStoreContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Member member)
        {
            
            var result = await _context.Member.Where(m => m.Account == member.Account && m.Password == _context.ComputeSha256Hash(member.Password)).FirstOrDefaultAsync();

            //如果帳密正確,導入後台頁面
            if (result != null)
            {
               
                //發給證明,證明他已經登入
                HttpContext.Session.SetString("MemberInfo", result.ToJson());


                return RedirectToAction("Index", "ProductList");
            }
            else //如果帳密不正確,回到登入頁面,並告知帳密錯誤
            {
                ViewData["Message"] = "帳號或密碼錯誤";
            }

            return View(result);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("MemberInfo");
            return RedirectToAction("Index", "ProductList");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Member member)
        {
            ModelState.Remove("MemberID");

            member.Password = _context.ComputeSha256Hash(member.Password);

            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();

                TempData["RegisterMessage"] = "OK";

                return RedirectToAction(nameof(Login));
            }

            return View(member);
        }

        public bool MemberAccountCheck(string account)
        {

            var result = _context.Member.Where(m => m.Account == account).FirstOrDefault();
            Task.Delay(2000).Wait();

            return result == null;
        }

    }
}

//Create function[dbo].[fnGetNewMemberID] ()
//    returns nchar(6)
//begin
//  DECLARE @newID nchar(6)
//	DECLARE @numberPart int
//	DECLARE @newNumberPart NVARCHAR(10)

//	-- 取得最新的 MemberID
//	SELECT TOP 1 @newID = MemberID
//	FROM Member
//	ORDER BY MemberID DESC

//	-- 提取數字部分，轉換為整數
//	SET @numberPart = CAST(SUBSTRING(@newID, 2, 5) AS INT)

//	-- 加 1
//	SET @numberPart = @numberPart + 1

//	-- 將新的數字部分轉為字串，並確保補零至 5 位
//	SET @newID = RIGHT('00000' + CAST(@numberPart AS NVARCHAR(5)), 5)

//	-- 拼接回新的 MemberID
//	return 'M' + @newID
	
//end
