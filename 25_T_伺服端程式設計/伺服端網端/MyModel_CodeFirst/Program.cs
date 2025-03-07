using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using MyModel_CodeFirst.Models;

var builder = WebApplication.CreateBuilder(args);

//1.2.4 �bProgram.cs���H�̿�`�J���g�k���UŪ���s�u�r�ꪺ�A��(food panda�BUber Eats)
//      ���`�N�{������m�����n�bvar builder = WebApplication.CreateBuilder(args);�o�y����
builder.Services.AddDbContext<GuestBookContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("GuestBookConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();


//5.3.3 �bProgram.cs�����U�αҥ�Session
//���USession�A��
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});



/////////////////////////////////////////////////////////////////////////////////////////////////////////
var app = builder.Build();

//1.3.4 �bProgram.cs���g�ҥ�Initializer���{��
using (var scope = app.Services.CreateScope())
{
    var service = scope.ServiceProvider;

    SeedData.Initialize(service);
}


//6.1.3 �ק� Program.cs�����{���X�A�N�O�_�b�}�o�Ҧ��U�����~�B�z�P�_���ѱ�
//if (!app.Environment.IsDevelopment())
//{
    app.UseExceptionHandler("/Home/Error");  //�o�ӬO�B�z�ҥ~�o�ͮɪ����~�B�z
    //6.2.1 �bProgram.cs�����{���X���U�B�zHttpNotFound(404)���~��Error Handler
    app.UseStatusCodePagesWithReExecute("/Home/Error");  //�o�ӬO�B�z���A�X�����~�B�z
//}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//5.3.3 �bProgram.cs�����U�αҥ�Session
//�ҥ�Session
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.Run();
