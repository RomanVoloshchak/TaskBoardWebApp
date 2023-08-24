using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using TaskBoardWebApp.Infrastructure;
using TaskBoardWebApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DbConnection"]);
});
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
    pattern: "{controller=Home}/{action=Index}/{id?}");



var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<DataContext>();

//bool flag = false;
//if (!flag)
//{
//    var user = context.Users.FirstOrDefault(x => x.Name == "Rorshah");

//    var characters = context.Characters.AsQueryable()
//    .Where(x => x.User.Id == user.Id)
//    .Select(x => x);

//    Console.WriteLine("User: " + user.Email);
//    foreach (var character in characters)
//    {
//        Console.WriteLine("Charater: " + character.CreateDate);
//    }


//    flag = true;
//}

SeedData.SeedDatabase(context);
app.Run();
