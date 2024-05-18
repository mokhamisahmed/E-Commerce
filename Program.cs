using E_Commerce_WebSite.Database;
using E_Commerce_WebSite.Models;
using E_Commerce_WebSite.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<Connection>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("connection"))
    );

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<Connection>();
builder.Services.AddScoped<RoleManager<IdentityRole>, RoleManager<IdentityRole>>();

builder.Services.AddScoped<ICrud<Category>,Service<Category>>();

builder.Services.AddScoped<ICrud<Product>, Service<Product>>();

builder.Services.AddScoped<ICrud<Order>, Service<Order>>();

builder.Services.AddScoped<ICrud<OrderItem>, Service<OrderItem>>();

builder.Services.AddScoped<IProduct, ProductService>();

builder.Services.AddScoped<ICategory, CategoryService>();

builder.Services.AddScoped<IOrderItem,OrderService>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



builder.Services.AddSession(options =>
{
    // Set session timeout
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Change it according to your requirements
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
