using Ecommerce_Project_WebAPI.Models;
using Ecommerce_Project_WebAPI.Services;
using Ecommerce_Project_WebAPI.Services.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Microsoft.EntityFrameworkCore.SqlServer;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UserRoleContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnString")));
//builder.Services.AddDbContext<UserRoleContext>(options => options.UseInMemoryDatabase("userrolesdb"));
builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnString")));
builder.Services.AddDbContext<ProductImageContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnString")));
builder.Services.AddDbContext<RegistrationContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnString")));
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddScoped<IUserRole, UserRoleRepository>();
builder.Services.AddScoped<IRegistration, RegistrationRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
