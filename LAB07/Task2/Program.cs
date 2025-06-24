
using Microsoft.EntityFrameworkCore;
using Task2.Data;

namespace Task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Cấu hình CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin() // Cho phép tất cả các nguồn (Origin)
                          .AllowAnyMethod() // Cho phép tất cả các phương thức HTTP (GET, POST, PUT, DELETE...)
                          .AllowAnyHeader(); // Cho phép tất cả các header
                });
            });

            builder.Services.AddDbContext<HospitalDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Cấu hình middleware CORS
            app.UseCors("AllowAll"); // Áp dụng chính sách CORS cho toàn bộ ứng dụng

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();


        }
    }
}
