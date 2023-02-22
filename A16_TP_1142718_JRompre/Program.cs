using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using A16_TP_1142718_JRompre.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<A16_TP_1142718_JRompreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("A16_TP_1142718_JRompreContext") ?? throw new InvalidOperationException("Connection string 'A16_TP_1142718_JRompreContext' not found.")));

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
    name: "default",
    pattern: "{controller=Automobiles}/{action=Louer}/{id?}");

app.Run();
