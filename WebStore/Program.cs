using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.AutomapperProfiles;
using WebStore.Data;
using WebStore.Models.Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<WebStoreContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("WebStoreContext")));

builder.Services.AddIdentity<WebStoreUser, IdentityRole<Guid>>()
    .AddEntityFrameworkStores<WebStoreContext>();

builder.Services.AddAutoMapper(typeof(UserProfile));

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
