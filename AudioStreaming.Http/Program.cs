using AudioStreaming.Application;
using AudioStreaming.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<PlanRepository>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<ArtistRepository>();
builder.Services.AddScoped<AlbumRepository>();
builder.Services.AddScoped<MusicRepository>();

builder.Services.AddScoped<PlanService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ArtistService>();
builder.Services.AddScoped<MusicService>();

builder.Services.AddDbContext<ApplicationContext>(context => {
    context.UseNpgsql("Server=127.0.0.1;Port=5432;Database=audio_streaming;UserId=postgres;Password=1234;");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();