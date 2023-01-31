using Layers_DI_Identity.Models;
using Layers_DI_Identity.Reposiotries;
using Layers_DI_Identity.ServiceLifeTime;
using Layers_DI_Identity.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MVC_DemoDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("myCS"));
});

builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<IStudentService,StudentService>();


builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddTransient<ItransiantService, transiantService>();
builder.Services.AddSingleton<ISingletonService, SingletonService>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
