using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PortalSystem.Data;
using Microsoft.AspNetCore.Identity;
using PortalSystem.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PortalSystemContextConnection") ?? throw new InvalidOperationException("Connection string 'PortalSystemContextConnection' not found.");
var configuration = builder.Configuration;
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<PortalSystemDb>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IUsersAccountServices, UsersAccountServices>();
builder.Services.AddTransient<IClassServices, ClassServices>();
builder.Services.AddTransient<IEnrolledServices, EnrolledServices>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddControllers();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                  .AddCookie(options =>
                  {
                      options.Cookie.Name = "myauth";
                      options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
                      
                  });
builder.Services.AddHttpClient();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapDefaultControllerRoute();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
