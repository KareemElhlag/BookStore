using BookStore;
using BookStore.Models;
using BookStore.Models.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;







var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();   
builder.Services.AddScoped<IBaseRepoBookAuthor<AuthorModel>, AuthorRepoWithDBcontext>();
builder.Services.AddScoped<IBaseRepoBookAuthor<BookModel>, BookRepoWithDBContext>();

builder.Services.AddDbContext<BookDbReposcs>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("FirstDB")
        );
});
var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Author}/{action=Index}/{id?}");
app.Run();
