using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebAPI.APIModels;
using MyWebAPI.Services;
using Newtonsoft.Json;

namespace MyWebAPI.Controllers
{

    //9.1.5 建立一個空白的API Contoller-PetAdoptionController並設定介接位址
    [Route("api[controller]")]
    [ApiController]
    public class PetAdoptionController : ControllerBase
    {
        //9.2.2 將PetAdoptionController中的HttpClient物件寫成DI方式
        private readonly PetAdoptionService _petAdoptionService;

        public PetAdoptionController(PetAdoptionService petAdoptionService)
        {
            _petAdoptionService = petAdoptionService;
        }


        //9.1.6 撰寫Get()方法，使用HttpClient物件取得第三方API的資料
        [HttpGet]
        public async Task< IEnumerable<PetAdoptionData> > GetAllData(int page=1,int pageSize = 50)
        {
            var collection = await _petAdoptionService.GetData("",page, pageSize);

            if (collection == null)
            {
                return null;
            }

            return collection;

        }

        //9.1.10 利用第三方API所給的使用說明文件，另外撰寫至少兩個不同的查詢功能以利測試
        [HttpGet("GetByArea")]
        public async Task<IEnumerable<PetAdoptionData>> GetByArea(int animalAreaPKID, int page = 1, int pageSize = 50)
        {
            var collection = await _petAdoptionService.GetData($"&animal_area_pkid={animalAreaPKID}",page, pageSize);

            if (collection == null)
            {
                return null;
            }

            return collection;

        }

        [HttpGet("GetByBacterin")]
        public async Task<IEnumerable<PetAdoptionData>> GetByacterin(string animalBacterin, int page = 1, int pageSize = 50)
        {
            var collection = await _petAdoptionService.GetData($"&animal_bacterin={animalBacterin}",page, pageSize);

            if (collection == null)
            {
                return null;
            }

            return collection;

        }

        //private int getItemSkip(int page, int pageSize=50)
        //{
        //    return pageSize * (page - 1);
        //}
    }
}
