using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;
using MyWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//跨域存取政策
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


//2.2.5 在Program.cs註冊DbContext物件(GoodStoreContext.cs)並指定appsettings.json中的連線字串程式碼(這段必須寫在var builder這行後面)
builder.Services.AddDbContext<GoodStoreContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("GoodStoreDB")));

//4.7.7 在Program裡註冊GoodStoreContext2的Service(※注意※原本註冊的GoodStoreContext不可刪掉)
builder.Services.AddDbContext<GoodStoreContext2>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("GoodStoreDB")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//1.2.2 在Program.cs中註冊及啟用Swagger
builder.Services.AddSwaggerGen();


//8.1.3 在Program.cs裡註冊SomeService服務
builder.Services.AddScoped<SomeService>();


//8.2.3 在Program.cs裡註冊CategoryService
builder.Services.AddScoped<CategoryService>();


//9.2.3 在Program.cs內註冊HttpClient物件
builder.Services.AddScoped<HttpClient>();


//9.2.6 在Program.cs內註冊PetAdoptionService物件
builder.Services.AddScoped<PetAdoptionService>();



////////////////////////////////////////////////////////
var app = builder.Build();

app.UseCors("MyCorsPolicy");

// Configure the HTTP request pipeline.
//1.2.2 在Program.cs中註冊及啟用Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//2.1.3 在Program.cs中加入app.UseStaticFiles(); (因為我們開的是 純WebAPI專案)
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
