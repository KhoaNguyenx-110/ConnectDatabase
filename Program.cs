using Microsoft.EntityFrameworkCore;
using ConnectDatabase.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DataContext>(opts => {
    opts.UseSqlServer(builder.Configuration[
    "ConnectionStrings:ProductConnection"]);
    opts.EnableSensitiveDataLogging(true);
});
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.Cookie.IsEssential = true;
});
var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.MapControllers();
app.MapControllerRoute("Default",
"{controller=Supplier}/{action=Index}/{id?}");
var context = app.Services.CreateScope().ServiceProvider

.GetRequiredService<DataContext>();

SeedData.SeedDatabase(context);
app.Run();