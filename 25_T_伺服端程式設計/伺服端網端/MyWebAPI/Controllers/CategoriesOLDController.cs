using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.DTOs;
using MyWebAPI.Models;

namespace MyWebAPI.Controllers
{
    //3.1.4 修改API介接路由為「api[controller]」
    [Route("api[controller]")]
    [ApiController]
    public class CategoriesOLDController : ControllerBase
    {
        private readonly GoodStoreContext _context;

        public CategoriesOLDController(GoodStoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategory()
        {
            //4.5.3 改寫CategoriesController裡的第一個Get Action
            //4.5.4 使用Include()同時取得關聯資料並以CategoryDTO傳遞
            
            //商業邏輯
            var result = await _context.Category.Include(p => p.Product).Select(c => ItemCategory(c)).ToListAsync();
            
            
            //控制邏輯
            if (result == null)
            {
                return NotFound("找不到任何資料");
            }

            return result;
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(string id)
        {
            //var category = await _context.Category.FindAsync(id);

            //4.5.6 改寫CategoriesController裡的第二個Get Action
            //4.5.7 使用Include()同時取得關聯資料並以CategoryDTO傳遞
            var category = await _context.Category.Include(p => p.Product).Where(c => c.CateID == id)
                .Select(c => ItemCategory(c)).FirstOrDefaultAsync();

            if (category == null)
            {
                return NotFound("沒有找到任何資料");
            }

            return category;
        }

        //6.1.4 改寫CategoriesController中Put Action內容
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(string id, [FromForm]CategoryPutDTO category)
        {
            //if (id != category.CateID)
            //{
            //    return BadRequest();
            //}

            if (id == null)
            {
                return BadRequest();
            }

            var cate = await _context.Category.FindAsync(id);

            if (cate == null)
            {
                return NotFound("查無資料");
            }

            cate.CateName = category.CateName;
            _context.Entry(cate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return Ok(cate);
        }

        ///5.3.10 修改CategoriesController的Post方法，使其傳遞CategoryPostDTO
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory([FromForm]CategoryPostDTO category)
        {

            //5.3.11 修改CategoriesController的Post方法，使其傳遞CategoryPostDTO
            Category cate = new Category()
            {
                CateID = category.CateID,
                CateName = category.CateName
            };

            _context.Category.Add(cate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CategoryExists(category.CateID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCategory", new { id = category.CateID }, category);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(string id)
        {
            return _context.Category.Any(e => e.CateID == id);
        }

        private static CategoryDTO ItemCategory(Category c)
        {
            var result = new CategoryDTO
            {
                CateID = c.CateID,
                CateName = c.CateName,
                Product = c.Product

            };

            return result;
        }
    }
}
