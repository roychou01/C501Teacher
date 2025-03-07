using Microsoft.EntityFrameworkCore;
using MyWebAPI.DTOs;
using MyWebAPI.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyWebAPI.Services
{
    //8.2.1 在Service資料夾中建立CategoryService，並將CategoriesController裡的兩個Get Action相關的
    //商業邏輯移至此撰寫
    //(包括ItemProduct()方法一併移入CategoryService)
    public class CategoryService
    {
        private readonly GoodStoreContext _context;

        public CategoryService(GoodStoreContext context)
        {
            _context = context;
        }


        //從資料庫取得產品類別的清單
        /// <summary>
        /// 從資料庫取得產品類別的全部資料清單
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryDTO>> GetGategory()
        {
            var result = _context.Category.Include(p => p.Product).Select(c => ItemCategory(c));
            return await result.ToListAsync();
        }

        //以多載實作GetGategory()
        /// <summary>
        /// 從資料庫取得指定產品類別的資料(傳入PK)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CategoryDTO> GetGategory(string id)
        {
            var category = await _context.Category.Include(p => p.Product).Where(c => c.CateID == id)
           .Select(c => ItemCategory(c)).FirstOrDefaultAsync();

            return category;
        }

        public async Task<Category> FindGategory(string id)
        {
            var cate = await _context.Category.FindAsync(id);

            return cate;
        }


        public async Task<Category> UpdateCategory(Category cate, CategoryPutDTO category)
        {

            cate.CateName = category.CateName;
            _context.Entry(cate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                throw;

            }

            return cate;
        }

        public async Task<Category> InsertCategory(CategoryPostDTO category)
        {
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

                throw;

            }
            return cate;
        }

        public async void DeleteCategory(Category category)
        {
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

        }

        public bool CategoryExists(string id)
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
