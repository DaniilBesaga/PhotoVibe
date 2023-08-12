using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using MyProject.Extensions;
using Microsoft.AspNetCore.Rewrite;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = "Photovibe",
        ValidateAudience = true,
        ValidAudience = "Photovibe",
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is my super secret code")),
        ValidateIssuerSigningKey = true
    };
});
// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddScoped<MyProject.Interface.IStockPhotosService, MyProject.Services.StockPhotosService>();
builder.Services.AddScoped<MyProject.Interface.IStockPhotoCollectionsService, MyProject.Services.StockPhotoCollectionsService>();
builder.Services.AddScoped<MyProject.Interface.ICartService, MyProject.Services.CartService>();
builder.Services.AddScoped<MyProject.Services.AddItemService>();
builder.Services.AddSession();
builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.Map("/", () => Results.LocalRedirect("/MainPage"));
app.Use(async (context, next) =>
{
    await next();
    if(context.Response.StatusCode==404)
    {
        context.Request.Path = "/NotFound";
        await next();
    }
});
IHostEnvironment? env = app.Services.GetService<IHostEnvironment>();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
