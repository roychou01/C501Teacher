using Microsoft.EntityFrameworkCore;
using MyModel_DBFirst.Models;

var builder = WebApplication.CreateBuilder(args);

//6.1.4 �bProgram.cs�[�J�ϥ�appsettings.json�����s�u�r��{���X(�o�q�����g�kvar builder�o��᭱,var app���e��)
builder.Services.AddDbContext<dbStudentsContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("dbStudentsConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();




////////////////////////////////////////�ڬO���j�u/////////////////////////////////////////////////////
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
