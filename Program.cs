using baby_shop_backend.Context;
using baby_shop_backend.Mapper;
using baby_shop_backend.Middleware;
using baby_shop_backend.Services.CartServices;
using baby_shop_backend.Services.JwtServies;
using baby_shop_backend.Services.OrderServices;
using baby_shop_backend.Services.ProductServices;
using baby_shop_backend.Services.userServices;
using baby_shop_backend.Services.WhisListServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace baby_shop_backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            
            
            builder.Services.AddAutoMapper(typeof(MappingProfile));


            builder.Services.AddLogging();
            

            
            builder.Services.AddScoped<IuserServies, UserServies>();
            builder.Services.AddScoped<I_jwtServices, JwtServices>();
            builder.Services.AddScoped<IproductServices, ProductServices>();
            builder.Services.AddScoped<IcartServies, CartServies>();
            builder.Services.AddScoped<IorderServices, OrderServices>();
            builder.Services.AddScoped<IwhishList, WhishListServices>();


            // Configure DbContext with SQL Server.
            builder.Services.AddDbContext<DbContext_Main>(x =>
                x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddSwaggerGen(option =>
            {
                option.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'"
                });

                option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });



            });

            //--------------------Authentication & Token-----------------------------
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    //ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    //ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true
                };
            });


            builder.Services.AddCors(option =>
            {
                option.AddPolicy("ReactPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });




            // Add authorization
            builder.Services.AddAuthorization();

            // Add Swagger for API documentation.
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("ReactPolicy");

            //app.UseStaticFiles();

            app.UseHttpsRedirection();

            // Enable authentication and authorization middleware.
            
            app.UseAuthentication();
            app.UseAuthorization();

            //add custom middle ware

            app.UseMiddleware<JwtMiddleWare>();

            app.MapControllers();

            app.Run();
        }
    }
}
