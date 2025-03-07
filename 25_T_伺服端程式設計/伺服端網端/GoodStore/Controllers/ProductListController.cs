using GoodStore.Filters;
using GoodStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodStore.Controllers
{
    public class ProductListController : Controller
    {
        private readonly GoodStoreContext _context;

        public ProductListController(GoodStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string? CateID)
        {

            //select * from product

            var products = _context.Product.Include(p => p.Cate).AsQueryable();
            if (!string.IsNullOrEmpty(CateID))
            {
                products = products.Where(p => p.CateID == CateID);
            }

            ViewData["Cate"] = await _context.Category.ToListAsync();

            return View(await products.ToListAsync());
        }

        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Cate)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            //await Task.Delay(3000);

            return View(product);
        }


        //[ServiceFilter(typeof(LoginStatusFilter))]
        public IActionResult Cart()
        {
            return View();
        }
    }
}
