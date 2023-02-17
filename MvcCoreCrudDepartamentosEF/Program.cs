using Microsoft.EntityFrameworkCore;
using MvcCoreCrudDepartamentosEF.Data;
using MvcCoreCrudDepartamentosEF.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string connectionString =
    builder.Configuration.GetConnectionString("SqlHospital");
builder.Services.AddTransient<RepositoryDepartamentos>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DepartamentosContex>
    (options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
