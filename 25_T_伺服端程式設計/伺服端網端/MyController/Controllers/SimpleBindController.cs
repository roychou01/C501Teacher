using Microsoft.AspNetCore.Mvc;

namespace MyController.Controllers
{
    public class SimpleBindController : Controller
    {
        //假設我們有一個商品資料表,有商品編號、商品名稱、商品價格
        //1.我們要先有一個商品新增的表單介面(將介面實作於View)
        //2.所以要先有一個相對應的Action
        //3.假設我們的View名稱為Create.cshtml,則需有Create() Action
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string id, string name, int price)
        {
            if (string.IsNullOrEmpty(id)) {
                ViewData["Result"] = "商品編號必須有值";
                return View();
            }

            if (string.IsNullOrEmpty(name)) {
                ViewData["Result"] = "商品名稱必須有值";
                return View();
            }

            if (price < 0) {
                ViewData["Result"] = "商品價格必須大於等於零";
                return View();
            }

            //測試是否接收到表單傳遞的資料
            ViewData["Result"] = $"商品編號：{id}、商品名稱：{name}、商品價格：{price}";

            //接到資料後送進資料庫(實際上正式系統的行為)

            return View();
        }

    }
}
