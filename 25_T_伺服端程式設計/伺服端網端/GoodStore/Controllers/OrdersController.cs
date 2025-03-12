﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GoodStore.Models;
using System.Diagnostics.Metrics;
using GoodStore.Filters;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Newtonsoft.Json.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;
using GoodStore.ViewComponents;
using System.Numerics;

namespace GoodStore.Controllers
{
    [ServiceFilter(typeof(LoginStatusFilter))]
    public class OrdersController : Controller
    {
        private readonly GoodStoreContext _context;

        public OrdersController(GoodStoreContext context)
        {
            _context = context;
        }

        private Member getMemberInfo()
        {
            var member= HttpContext.Items["Member"] as Member;

             return member;
        }


        public async Task<IActionResult> Index()
        {
            var Orders = _context.Order.Include(o => o.Member)
                .Where(o => o.MemberID == getMemberInfo().MemberID)
                .Select(o => new
                {
                    OrderID = o.OrderID,
                    OrderDate = o.OrderDate,
                    MemberName = o.Member.Name,
                    ContactName = o.ContactName,
                    ContactAddress = o.ContactAddress,
                    Total = o.OrderDetail.Sum(od => od.Qty * od.Price)

                });

            return View(await Orders.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Member)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            //ViewData["MemberID"] = new SelectList(_context.Member, "MemberID", "MemberID");
            return View();
        }

    
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order, string Cart)
        {
            order.OrderDate = DateTime.Now;
            order.MemberID = (HttpContext.Items["Member"] as Member).MemberID;

            ModelState.Remove("OrderID");
            ModelState.Remove("MemberID");
            ModelState.Remove("Member");

            if (ModelState.IsValid)
            {
                //存入資料庫的動作,因為相對複雜,所以使用SQL語法
                //使用資料庫端的預存程序
                try
                {
                    var result = await _context.ExecSPAddNewOrderAsync(order.MemberID, order.ContactName, order.ContactAddress, Cart);

                    if (result > 0)
                    {
                        TempData["OrderMessage"] = "OK";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch
                {
                    return View(order);
                }
            }
           
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["MemberID"] = new SelectList(_context.Member, "MemberID", "MemberID", order.MemberID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OrderID,OrderDate,MemberID,ContactName,ContactAddress")] Order order)
        {
            if (id != order.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.OrderID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberID"] = new SelectList(_context.Member, "MemberID", "MemberID", order.MemberID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o => o.Member)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(string id)
        {
            return _context.Order.Any(e => e.OrderID == id);
        }
    }
}


//Create FUNCTION getOrderID()

//    RETURNS CHAR(12)
//AS
//BEGIN
//    DECLARE @TodayDate VARCHAR(8);
//DECLARE @SerialNumber INT;
//DECLARE @NewOrderID VARCHAR(12);

//--取得今天的日期（格式: YYYYMMDD）
//    SET @TodayDate = CONVERT(VARCHAR(8), GETDATE(), 112);

//--查詢今天已有的訂單數量，並計算下一個流水號
//SELECT @SerialNumber = ISNULL(MAX(CAST(SUBSTRING(OrderID, 9, 4) AS INT)), 0) + 1
//    FROM [Order]
//WHERE OrderID LIKE @TodayDate + '%';

//--組合新的訂單編號，格式: YYYYMMDD + 4位數流水號
//SET @NewOrderID = @TodayDate + RIGHT('0000' + CAST(@SerialNumber AS VARCHAR(4)), 4);

//RETURN @NewOrderID;
//END




//create proc AddNewOrder
//	@MemberID nchar(6),
//    @ContactName nvarchar(27),
//@ContactAddress nvarchar(60),
//    @Cart nvarchar(max)
//as
//begin
	
//	begin tran  --開始交易處理程序
	
//	declare @orderID nchar(12)=dbo.getOrderID()

//	insert into [Order] values(@orderID , getdate(), @MemberID , @ContactName, @ContactAddress)  --資料來自表單


//    if @@ERROR = 0

//    begin
//        insert into OrderDetail
//		select @orderID, PID, Qty, Price  from openjson(@Cart) with(PID nchar(5), Qty int, Price money)   --資料來自購物車的JSON

//		if @@ERROR=0
//			commit
//		else
//			rollback
//	end
//	else
//		rollback

//end
