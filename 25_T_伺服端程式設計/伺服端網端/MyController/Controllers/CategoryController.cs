using Microsoft.AspNetCore.Mvc;
using MyController.Models;


namespace MyController.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {

            ViewData["Result"]= $"產品類別編號：{category.CateID}、產品類別名稱：{category.CateName}、說明：{category.Description}、圖片：{category.Photo}";
            return View();
        }
    }
}
