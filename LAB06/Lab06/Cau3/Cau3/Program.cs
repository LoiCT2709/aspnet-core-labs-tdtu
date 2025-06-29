var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "blog",
    pattern: "{controller=Blog}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "user",
    pattern: "users/{role:alpha}",
    defaults: new { controller = "User", action = "GetUsersByRole" });

app.Run();
