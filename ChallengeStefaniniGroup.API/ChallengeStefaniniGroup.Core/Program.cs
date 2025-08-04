using ChallengeStefaniniGroup.Application.Task.Services.TaskService;
using ChallengeStefaniniGroup.Data.Data;
using ChallengeStefaniniGroup.Data.Repository.TaskRepository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("Cors", p =>
    {
        p.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseMongoDB(
    builder.Configuration.GetSection("MongoDBSettings:ConnectionURL").Value ?? string.Empty,
    builder.Configuration.GetSection("MongoDBSettings:DatabaseName").Value ?? string.Empty));

builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Cors");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
