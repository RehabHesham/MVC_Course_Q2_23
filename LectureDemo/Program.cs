using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options=>
options.IdleTimeout = TimeSpan.FromDays(1));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.Use(async (cont, nex) =>
{
    Console.WriteLine("middleware 1 -> forward");
    if (cont.Request.Cookies.ContainsKey("ReqNum"))
    {
        //inc
        int num = int.Parse(cont.Request.Cookies["ReqNum"]);
        cont.Response.Cookies.Append("ReqNum", (++num).ToString());
    }
    else
    {
    cont.Response.Cookies.Append("ReqNum", "1");
    }
    await nex();
    Console.WriteLine("middleware 1 -> back");
});

//app.Use(async (context, next) =>
//{
//    if(context.Request.Path == "/cat")
//    {
//        Console.WriteLine("short");
//    }
//    else
//    {
//    Console.WriteLine("middleware 2 -> forward");
//    await next();
//    Console.WriteLine("middleware 2 -> back");

//    }
//});
//app.Use(async (context, next) =>
//{
//    Console.WriteLine("middleware 3 -> forward");
//    await next();
//    Console.WriteLine("middleware 3 -> back");
//});
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "instructor",
//    pattern: "instrctors/{id:int}/{name:alpha}",
//    defaults: new {Controller = "Instructor",Action = "Index"});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
