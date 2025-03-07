using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using MyModel_CodeFirst.Models;

var builder = WebApplication.CreateBuilder(args);

//1.2.4 在Program.cs內以依賴注入的寫法註冊讀取連線字串的服務(food panda、Uber Eats)
//      ※注意程式的位置必須要在var builder = WebApplication.CreateBuilder(args);這句之後
builder.Services.AddDbContext<GuestBookContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("GuestBookConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();


//5.3.3 在Program.cs中註冊及啟用Session
//註冊Session服務
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});



/////////////////////////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();

//1.3.4 在Program.cs撰寫啟用Initializer的程式
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;

    SeedData.Initialize(service);
}


//6.1.3 修改 Program.cs中的程式碼，將是否在開發模式下的錯誤處理判斷註解掉
//if (!app.Environment.IsDevelopment())
//{
    app.UseExceptionHandler("/Home/Error");  //這個是處理例外發生時的錯誤處理
    //6.2.1 在Program.cs中的程式碼註冊處理HttpNotFound(404)錯誤的Error Handler
    app.UseStatusCodePagesWithReExecute("/Home/Error");  //這個是處理狀態碼的錯誤處理
//}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//5.3.3 在Program.cs中註冊及啟用Session
//啟用Session
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
