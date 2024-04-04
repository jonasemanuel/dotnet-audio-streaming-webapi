using System.Text;
using AudioStreaming.Application;
using AudioStreaming.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:5001",
            ValidAudience = "https://localhost:5001",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Infnet@345"))
        };
    }
);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<PlanRepository>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<ArtistRepository>();
builder.Services.AddScoped<AlbumRepository>();
builder.Services.AddScoped<MusicRepository>();
builder.Services.AddScoped<PlaylistRepository>();

builder.Services.AddScoped<PlanService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<ArtistService>();
builder.Services.AddScoped<MusicService>();
builder.Services.AddScoped<PlaylistService>();

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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();