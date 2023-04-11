using BlazorAppDemo.Core.Interfaces;
using BlazorAppDemo.Infrastructure.Repositories;
using BlazorAppDemo.Server.BazorAppDemo.Infrastructure;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
builder.Services.AddAutoMapper(typeof(MappingProfile));
string connectionString = builder.Configuration.GetConnectionString("Print3dConnectionNew");
builder.Services.AddDbContextFactory<Print3dContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddScoped<IPrint3dRepository, Print3dRepository>();




var app = builder.Build();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
