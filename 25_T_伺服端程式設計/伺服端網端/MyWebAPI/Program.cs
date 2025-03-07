using Microsoft.EntityFrameworkCore;
using MyWebAPI.Models;
using MyWebAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//���s���F��
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


//2.2.5 �bProgram.cs���UDbContext����(GoodStoreContext.cs)�ë��wappsettings.json�����s�u�r��{���X(�o�q�����g�bvar builder�o��᭱)
builder.Services.AddDbContext<GoodStoreContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("GoodStoreDB")));

//4.7.7 �bProgram�̵��UGoodStoreContext2��Service(���`�N���쥻���U��GoodStoreContext���i�R��)
builder.Services.AddDbContext<GoodStoreContext2>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("GoodStoreDB")));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//1.2.2 �bProgram.cs�����U�αҥ�Swagger
builder.Services.AddSwaggerGen();


//8.1.3 �bProgram.cs�̵��USomeService�A��
builder.Services.AddScoped<SomeService>();


//8.2.3 �bProgram.cs�̵��UCategoryService
builder.Services.AddScoped<CategoryService>();


//9.2.3 �bProgram.cs�����UHttpClient����
builder.Services.AddScoped<HttpClient>();


//9.2.6 �bProgram.cs�����UPetAdoptionService����
builder.Services.AddScoped<PetAdoptionService>();



////////////////////////////////////////////////////////
var app = builder.Build();

app.UseCors("MyCorsPolicy");

// Configure the HTTP request pipeline.
//1.2.2 �bProgram.cs�����U�αҥ�Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//2.1.3 �bProgram.cs���[�Japp.UseStaticFiles(); (�]���ڭ̶}���O ��WebAPI�M��)
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
