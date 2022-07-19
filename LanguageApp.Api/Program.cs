using LanguageApp.Api.Data;
using LanguageApp.Api.Repositories;
using LanguageApp.Api.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContextPool<LanguageAppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LanguageAppConnection"))
);

builder.Services.AddScoped<ISentenceRepository, SentenceRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy =>
    policy.WithOrigins("https://localhost:7052", "https://localhost:7052")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)

);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
