using ChallengeStefaniniGroup.Application;
using ChallengeStefaniniGroup.Data.Data;
using ChallengeStefaniniGroup.Data.Data.Helper;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDbSettings>();
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDBSettings"));
builder.Services.AddDbContext<DataContext>(options => options.UseMongoDB(mongoDBSettings.ConnectionURL, mongoDBSettings.DatabaseName));

builder.Services.AddScoped<ITaskService, TaskService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
