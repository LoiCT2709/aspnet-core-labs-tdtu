using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Task2.Data;
using System.IO;

namespace Task2
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<HospitalDbContext>
    {
        public HospitalDbContext CreateDbContext(string[] args)
        {
            // Xây dựng DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<HospitalDbContext>();

            // Đọc cấu hình từ appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Đảm bảo rằng đường dẫn đúng đến thư mục hiện tại
                .AddJsonFile("appsettings.json") // Đọc file cấu hình appsettings.json
                .Build();

            var connectionString = configuration.GetConnectionString("DbConnection"); // Lấy chuỗi kết nối

            // Cấu hình DbContext sử dụng chuỗi kết nối
            optionsBuilder.UseSqlServer(connectionString);

            // Trả về DbContext
            return new HospitalDbContext(optionsBuilder.Options);
        }
    }
}
