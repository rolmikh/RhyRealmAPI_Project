using Microsoft.EntityFrameworkCore;
using RhyRealmAPI_Project.Models;
using RhyRealmAPI_Project.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<RhyRealm_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("con")));

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("Smtp"));
builder.Services.AddTransient<EmailService>();

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<CacheService>();

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", context =>
{
    context.Response.Redirect("/swagger/index.html");
    return Task.CompletedTask;
});
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
