using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using OnlineEdu.API.Extensions;
using OnlineEdu.API.Mapping;
using OnlineEdu.DataAccess.Context;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using OnlineEdu.Business.Configurations;
using System.Security.Claims;
using OnlineEdu.Entity.Entities;
using OnlineEdu.Business.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(IAssemblyMarker).Assembly);


//Extensions klosorundekiler burada!!
builder.Services.AddServiceExtensions(builder.Configuration);

builder.Services.AddDbContext<OnlineEduContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
    options.UseLazyLoadingProxies();
 });


builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<OnlineEduContext>().AddErrorDescriber<CustomErrorDescriber>();
var tokenOptions = builder.Configuration.GetSection("JwtTokenOptions").Get<JwtTokenOptions>();

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,opt => {
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        LifetimeValidator = (before, expires, token, parameters) => expires > DateTime.UtcNow,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(tokenOptions.Key)),
        ClockSkew = TimeSpan.Zero,
        NameClaimType = ClaimTypes.Name
    };
});

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
