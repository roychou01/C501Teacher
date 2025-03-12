using GoodStore.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace GoodStore.Filters
{
    public class LogFilter:IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var MemberJson = context.HttpContext.Session.GetString("MemberInfo");

            if (MemberJson != null)
            {
                var MemberInfo = JsonConvert.DeserializeObject<Member>(MemberJson);
                context.HttpContext.Items["Member"]= MemberInfo;
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {

            //抓資訊
            var controller = context.RouteData.Values["controller"];
            var action = context.RouteData.Values["action"];
            var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            var agent = context.HttpContext.Request.Headers["User-Agent"].ToString();
            string user = "Guest";
            var time = DateTime.Now;

            var memberInfoJosn= context.HttpContext.Session.GetString("MemberInfo");

            if (memberInfoJosn != null)
            {
                var member = JsonConvert.DeserializeObject<Member>(memberInfoJosn);
                user = member?.MemberID + "-" + member?.Account + "-" + member?.Name;

            }

            string log = $"{time}, 使用者:{user},IP:{ip},瀏覽器:{agent},Controller:{controller},Action:{action}";
            //寫檔
            string filePath = "LogFiles/ActionLog.txt";

            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(log);
            }


        }
    }
}
