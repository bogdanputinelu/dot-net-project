using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Helpers;
using Project.Helpers.Extensions;
using Project.Helpers.Middleware;
using Project.Repositories.UserRepository;
using Project.Services.UserServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ProjectContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddRepositories();
builder.Services.AddServices();
builder.Services.AddUtils();

builder.Services.Configure<AppSetings>(builder.Configuration.GetSection("AppSetings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run();
