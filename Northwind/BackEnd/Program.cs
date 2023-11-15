using BackEnd.Middleware;
using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using DAL.Implementations;
using DAL.Interfaces;
using Entities.Entities;
using Entities.Utilities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Text;

var builder = WebApplication.CreateBuilder(args);



#region ConnString

string connString = builder
                            .Configuration
                            .GetConnectionString("DefaultConnection");


builder.Services.AddDbContext<NorthWindContext>(options =>
                        options.UseSqlServer(
                           connString
                            ));

Util.ConnectionString = connString;

#endregion


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


#region Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>( options=>

                {
                    options.Password.RequiredLength = 5;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;

                }
    
    
    
    )
    .AddEntityFrameworkStores<NorthWindContext>()
    .AddDefaultTokenProviders();



#endregion




#region JWT


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

})

    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidAudience = builder.Configuration["JWT:ValidAudience"],
            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
        };
    });




#endregion




#region Dependency Injection
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

app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
