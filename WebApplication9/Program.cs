using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication9.Areas.Identity.Data;
using WebApplication9.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthenticationDbContextContextConnection");
builder.Services.AddDbContext<appconnContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 28))));

builder.Services.AddDefaultIdentity<appiUser>(
    options => options.SignIn.RequireConfirmedAccount = true
    )
    .AddEntityFrameworkStores<appconnContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapGet("/hi", () => "Hello!");

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();