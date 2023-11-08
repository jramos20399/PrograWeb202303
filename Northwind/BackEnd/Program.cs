using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Entities.Utilities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

#region Serilog

    builder.Logging.ClearProviders();
    builder.Logging.AddConsole();
    builder.Host.UseSerilog((ctx, lc) =>lc
            .WriteTo.File("logs/logsBackEnd.txt", rollingInterval: RollingInterval.Day)
            .MinimumLevel.Information()
            
        
        
        
        );


#endregion


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Dependency Injection

string connString = builder
                            .Configuration
                            .GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<NorthWindContext>(options =>
                        options.UseSqlServer(
                           connString
                            ));

Util.ConnectionString = connString;


builder.Services.AddScoped<ICategoryDAL, CategoryDALImpl>();
builder.Services.AddScoped<IUnidadDeTrabajo, UnidadDeTrabajo>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ISupplierDAL, SupplierDALImpl>() ;
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IProductDAL  , ProductDALImpl>();
builder.Services.AddScoped<IProductService, ProductService>();




#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
