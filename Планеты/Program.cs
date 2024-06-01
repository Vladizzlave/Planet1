using Microsoft.EntityFrameworkCore;
using Планеты.Models;
using Планеты.Data.ApplicationDbContext;
using Microsoft.EntityFrameworkCore.Internal;
using Планеты.Model;
using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(connectionString));
builder.Services.AddRazorPages();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");
using (var scope = app.Services.CreateScope())
{
    try
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        dbContext.Database.Migrate();
        if (dbContext.Planets.Any()) ;
        dbContext.Planets.Add (new Planet() { Name = "Mercury", Description = "The smallest planet", Diameter = 4879, DistanceFromSun = 57.9 });
        dbContext.Planets.Add(new Planet() { Name = "Venus", Description = "The second planet from the Sun", Diameter = 12104, DistanceFromSun = 108.2 });
        dbContext.Planets.Add(new Planet() { Name = "Earth", Description = "Our home planet", Diameter = 12742, DistanceFromSun = 149.6 });


        dbContext.SaveChanges();
    }
    catch(Exception ex)
    {
        var logger = scope.ServiceProvider.GetService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding initial data");
    }
}
app.Run();
