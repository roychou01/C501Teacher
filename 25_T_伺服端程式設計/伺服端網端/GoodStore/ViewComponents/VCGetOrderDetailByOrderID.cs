using GoodStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoodStore.ViewComponents
{
    public class VCGetOrderDetailByOrderID: ViewComponent
    {
        private readonly GoodStoreContext _context;

        public VCGetOrderDetailByOrderID(GoodStoreContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            if (id == null)
            {
                return View("NotFound");
            }

            var orderDetails = await _context.OrderDetail.Where(od => od.OrderID == id)
                .Include(od=>od.Product).ToListAsync();

            
            if (orderDetails == null)
            {
                return View("NotFound");
            }

            return View(orderDetails);
        }
    }
}
