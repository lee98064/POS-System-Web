using Microsoft.EntityFrameworkCore;
using NuxtIntegration.Helpers;
var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddDbContext<POSSystemApiContext>(options =>
//     options.UseSqlite(builder.Configuration.GetConnectionString("POSSystemApiContext")));
// Add services to the container.

builder.Services.AddDbContext<POSSystemApiContext>(options => 
    options.UseSqlite(builder.Configuration.GetConnectionString("Db")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddSpaStaticFiles(options => options.RootPath = "client-app/dist");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//if (!app.Environment.IsDevelopment())
//{
//    app.UseSpaStaticFiles();
//}

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "api",
        pattern: "api/{controller}/{action=Index}/{id?}");
});

//app.UseSpa(spa =>
//{
//    spa.Options.SourcePath = "client-app";

//    if (app.Environment.IsDevelopment())
//    {
//        spa.UseNuxtDevelopmentServer();
//    }
//});

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
