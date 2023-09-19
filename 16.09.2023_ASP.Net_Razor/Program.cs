using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using _16._09._2023_ASP.Net_Razor.Data;
using _16._09._2023_ASP.Net_Razor.Models;
using RazorPagesMovie.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<_16_09_2023_ASPNet_RazorContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("_16_09_2023_ASPNet_RazorContext") ?? throw new InvalidOperationException("Connection string '_16_09_2023_ASPNet_RazorContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
