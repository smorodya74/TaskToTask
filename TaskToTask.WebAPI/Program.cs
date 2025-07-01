using Microsoft.EntityFrameworkCore;
using TaskToTask.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TaskToTaskDbContext>(
    options =>
    {
        options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(TaskToTaskDbContext)));
    });

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
