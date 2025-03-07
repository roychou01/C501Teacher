using Microsoft.AspNetCore.Mvc;

namespace MyController.Controllers
{
    public class FileUploadController : Controller
    {
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(IFormFile photo)
        {
            if (photo == null || photo.Length==0)
            {
                ViewData["Message"] = "沒有上傳任何檔案!!";
                return View();
            }

            //只允許上傳圖片檔
            if (photo.ContentType != "image/jpeg" && photo.ContentType != "image/png")
            {
                ViewData["Message"] = "請上傳jpg或png格式的檔案!!";
                return View();
            }


            // 取得檔案名稱
            string fileName= Path.GetFileName(photo.FileName);

            // 用一個filePath變數儲存路徑
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","Photos", fileName);

            // 把檔案儲存於伺服器上

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                photo.CopyTo(stream);
            }

            ViewData["Message"] = "檔案成功上傳!!";
            return View();
        }
    }
}
