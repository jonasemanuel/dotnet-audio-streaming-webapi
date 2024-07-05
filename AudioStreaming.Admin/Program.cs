using AudioStreaming.Admin.Infrastructure;
using AudioStreaming.Application;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AdminContext>(options =>
{
    options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=audio_streaming_admin;UserId=postgres;Password=1234;");
});

builder.Services.AddScoped<ArtistRepository>();
builder.Services.AddScoped<AlbumRepository>();
builder.Services.AddScoped<MusicRepository>();
builder.Services.AddScoped<ArtistRepository>();
builder.Services.AddScoped<UserRepository>();

builder.Services.AddScoped<ArtistService>();
builder.Services.AddScoped<MusicService>();
builder.Services.AddScoped<AlbumService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
