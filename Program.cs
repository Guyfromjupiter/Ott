using Ott.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Controllers
builder.Services.AddControllers();

// 🔐 JWT Configuration
var jwtSettings = builder.Configuration.GetSection("Jwt");

var key = jwtSettings["Key"]
          ?? throw new Exception("JWT Key missing");

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = jwtSettings["Issuer"],
            ValidAudience = jwtSettings["Audience"],

            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(key)
            )
        };
    });

builder.Services.AddAuthorization();

// 🔹 AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// 🔹 DbContext
builder.Services.AddDbContext<OttContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("OttsConections")));

// 🔹 Repositories
builder.Services.AddScoped<IMovieRepository, SqlMovieRepo>();
builder.Services.AddScoped<IPaymentRepository, SqlpaymentRepo>();
builder.Services.AddScoped<IProfileRepo, SqlProfileRepo>();
builder.Services.AddScoped<IRatingRepository, SqlRatingRepo>();
builder.Services.AddScoped<IWatchlistRepo, SqlWatchlistRepo>();

// 🔥 CORS CONFIG
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000") // change if needed
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// 🔥 Middleware pipeline

app.UseHttpsRedirection();

// CORS before auth
app.UseCors("AllowFrontend");

// Auth order
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();