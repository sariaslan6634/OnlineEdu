using Microsoft.EntityFrameworkCore;
using OnlineEdu.API.Extensions;
using OnlineEdu.API.Mapping;
using OnlineEdu.Business.Abstract;
using OnlineEdu.Business.Concrete;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.concrete;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.DataAccess.Repositories;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(cfg => 
{
    cfg.AddProfile<AboutMapping>();
    cfg.AddProfile<BannerMapping>();
    cfg.AddProfile<BlogCategoryMapping>();
    cfg.AddProfile<BlogMapping>();
    cfg.AddProfile<ContactMapping>();
    cfg.AddProfile<CourseCategoryMapping>();
    cfg.AddProfile<CourseMapping>();
    cfg.AddProfile<MessageMapping>();
    cfg.AddProfile<SocialMediaMapping>();
    cfg.AddProfile<SubscriberMapping>();
    cfg.AddProfile<TestimonialMapping>();
});


//Extensions klosorundekiler burada!!
builder.Services.AddServiceExtensions();

builder.Services.AddDbContext<OnlineEduContext>(options => 
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"));
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

app.UseAuthorization();

app.MapControllers();

app.Run();
