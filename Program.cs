using ResourceApi.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MIDTERM_Q3_32E3_YuanJasper_Rodriguez.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// 1. Setup Database
builder.Services.AddDbContext<ResourceDbContext>(o =>
    o.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// 2. Setup JWT Validation (Must match AuthApi settings!)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

var app = builder.Build();

// 3. Pipeline Order: ID Check -> Permission Check
app.UseAuthentication();
app.UseAuthorization();

// 4. Auto-create database
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<ResourceDbContext>().Database.EnsureCreated();
}

app.MapControllers();
app.Run();