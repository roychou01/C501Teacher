using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.DTOs;
using MyWebAPI.Models;
using MyWebAPI.Services;

namespace MyWebAPI.Controllers
{
    //3.1.4 修改API介接路由為「api[controller]」
    [Route("api[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
     
        private readonly CategoryService _categoryService;

        public CategoriesController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //8.2.5 改寫CategoriesController裡的兩個Get Action寫法，僅留下控制邏輯
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategory()
        {
            var result = await _categoryService.GetGategory();

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
            var category = await _categoryService.GetGategory(id);

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
  
            if (id == null)
            {
                return BadRequest();
            }

            var cateOld = await _categoryService.FindGategory(id);

            if (cateOld == null)
            {
                return NotFound("查無資料");
            }

            var cate = await _categoryService.UpdateCategory(cateOld, category);


            return Ok(cate);
        }

 
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory([FromForm]CategoryPostDTO category)
        {

            if(_categoryService.CategoryExists(category.CateID))
            {
                return Conflict("資料已存在");
            }


            var cate = await _categoryService.InsertCategory(category);

            return Ok(cate);

         
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {

            var category = await _categoryService.FindGategory(id);

            if (category == null)
            {
                return NotFound();
            }

            _categoryService.DeleteCategory(category);

            return NoContent();
        }

       
    }
}
