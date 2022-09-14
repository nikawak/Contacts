using Contacts.Services;
using Contacts.Services.Intefaces;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = new SqliteConnection($"DataSource={LiteContext.DbPath}");
connection.Open();

builder.Services
    .AddDbContext<LiteContext>(
        o => o.UseSqlite(connection));

builder.Services.AddScoped<IContactRepository, ContactRepository>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); 
    app.UseHsts();
}

var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetService<LiteContext>();

await db.Database.EnsureCreatedAsync();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Contact}/{action=Index}/{id?}");

app.Run();
