
using CoffeeManage.BLL.BLL_IMPLE;
using CoffeeManage.BLL.BLL_INTERFACES;
using CoffeeManage.DAL.DAL_IMPLE;
using CoffeeManage.DAL.DAL_INTERFACES;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using QLY_Coffee.Data;
using System.Text;

namespace CoffeeManage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "cfm_api",
                        ValidAudience = "cfm_user",
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes("THIS_IS_SUPER_LONG_JWT_SECRET_KEY_1234567890"))   //  PHẢI GIỐNG AuthService + Gateway
                    };
                });

            builder.Services.AddAuthorization();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy => policy
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            // ===== ĐĂNG KÝ SERVICE + DAL =====
            builder.Services.AddScoped<DBConnect>();
            builder.Services.AddScoped<I_BLL_LoadCoffee, BLL_LoadCoffee>();
            builder.Services.AddScoped<I_BLL_Cart, BLL_Cart>();
            builder.Services.AddScoped<I_BLL_Customer, BLL_Customer>();

            builder.Services.AddScoped<I_DAL_LoadCoffee, DAL_LoadCoffee>();
            builder.Services.AddScoped<I_DAL_Cart, DAL_Cart>();
            builder.Services.AddScoped<I_DAL_Customer, DAL_Customer>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthentication();
            app.UseMiddleware<UserContextMiddleware>();

            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("AllowFrontend");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
