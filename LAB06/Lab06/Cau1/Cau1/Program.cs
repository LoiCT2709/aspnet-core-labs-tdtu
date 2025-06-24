using Microsoft.EntityFrameworkCore;
using Cau1.Data;

var builder = WebApplication.CreateBuilder(args);

// Lấy chuỗi kết nối từ appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DbConnection");

// Đăng ký DbContext
builder.Services.AddDbContext<CustomerDBContext>(options =>
    options.UseSqlServer(connectionString));

// Đăng ký dịch vụ MVC
builder.Services.AddControllersWithViews();

// 🔹 Thêm dòng này để fix lỗi Authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// Cấu hình Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

// Sử dụng Authentication và Authorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Customer}/{action=Index}/{id?}");

app.Run();
