
using CoffeeManage.BLL.BLL_IMPLE;
using CoffeeManage.BLL.BLL_INTERFACES;
using CoffeeManage.DAL.DAL_IMPLE;
using CoffeeManage.DAL.DAL_INTERFACES;
using QLY_LMS.Data;

namespace CoffeeManage
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
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

            builder.Services.AddScoped<I_DAL_LoadCoffee, DAL_LoadCoffee>();
            builder.Services.AddScoped<I_BLL_LoadCoffee, BLL_LoadCoffee>();

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

            app.UseHttpsRedirection();
            app.UseCors("AllowFrontend");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
