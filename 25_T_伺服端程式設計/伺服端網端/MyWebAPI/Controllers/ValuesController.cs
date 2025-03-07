using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyWebAPI.Controllers
{

    //1.3.3 修改ValuesController的路由介接位址並測試 ([Route("api/[controller]")])
    [Route("api[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

       
        //1.3.2 進行增加Action、修改介接口等測試
        [HttpGet("aaa")]
        public IEnumerable<string> Get2()
        {

            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Ge(int id)
        {
            //1.3.1 修改Ge Action的內容並測試
            string[] MyProducts = { "超級無敵海景佛跳牆", "清香白玉板紅嘴綠鸚鴿", "玉笛誰家聽落梅"};

            return MyProducts[id];
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
