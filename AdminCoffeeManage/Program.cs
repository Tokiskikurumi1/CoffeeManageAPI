
using AdminCoffeeManage.BLL.BLL_IMPLE;
using AdminCoffeeManage.BLL.BLL_INTERFACES;
using AdminCoffeeManage.DAL;
using AdminCoffeeManage.DAL.DAL_IMPLE_;
using AdminCoffeeManage.DAL.DAL_INTERFACES;
using QLY_Coffee.Data;

namespace AdminCoffeeManage
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
            builder.Services.AddScoped<DBConnect>();

            builder.Services.AddScoped<I_BLL_ManageProduct, BLL_ManageProduct>();
            builder.Services.AddScoped<I_BLL_Bill, BLL_Bill>();
            builder.Services.AddScoped<I_DAL_ManageProduct, DAL_ManageProduct>();
            builder.Services.AddScoped<I_DAL_Bill, DAL_Bill>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
            app.UseStaticFiles();
            app.UseCors("AllowFrontend");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
