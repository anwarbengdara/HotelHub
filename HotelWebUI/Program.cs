using HotelHub.persistance;
using HotelHub.Service;
using HotelWebUI.Components;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using HotelHub.Service;
using HotelHub.Serviceinterfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<HotelHubContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString(name:"dbconnection")));
            
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ihotelService, HotelService>();
builder.Services.AddScoped<iRoomService, RoomService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
