using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StaffCoffee.BLL.BLL_IMPLE;
using StaffCoffee.BLL.BLL_INTERFACES;
using StaffCoffee.DAL.DAL_IMPLE;
using StaffCoffee.DAL.DAL_INTERFACES;
using StaffCoffee.Data;
using System.Text;

namespace StaffCoffee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            /* ================= JWT ================= */

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
                            Encoding.UTF8.GetBytes("THIS_IS_SUPER_LONG_JWT_SECRET_KEY_1234567890"))
                    };
                });

            builder.Services.AddAuthorization();

            /* ================= CORS ================= */

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            /* ================= SERVICE ================= */

            builder.Services.AddScoped<DBConnect>();
            builder.Services.AddScoped<I_BLL_StaffBill, BLL_StaffBill>();
            builder.Services.AddScoped<I_BLL_StaffDashBoard, BLL_StaffDashBoard>();
            builder.Services.AddScoped<I_BLL_StaffAccount, BLL_StaffAccount>();

            builder.Services.AddScoped<I_DAL_StaffBill, DAL_StaffBill>();
            builder.Services.AddScoped<I_DAL_StaffDashBoard, DAL_StaffDashBoard>();
            builder.Services.AddScoped<I_DAL_StaffAccount, DAL_StaffAccount>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            /* ================= DEV ================= */

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            /* ================= PIPELINE ================= */

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            app.UseAuthentication();

            app.UseMiddleware<UserContextMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}