using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain.Project;
using TaskManagement.Domain.Task;
using TaskManagement.Domain.User;
using TaskManagement.Infrasturcture.EF;
using TaskManagement.Infrasturcture.EF.Project;
using TaskManagement.Infrasturcture.EF.Task;
using TaskManagement.Infrasturcture.EF.User;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<TaskManagementDbContex>(options =>
{
    options.UseSqlServer(config["cs"]);
});

builder.Services.AddScoped<IUserRepository, UserRepository>();
//builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<ITaskRepository, TaskManagement.Infrasturcture.Dapper.Task.TaskRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

builder.Services.AddScoped<ProjectService, ProjectService>();
builder.Services.AddScoped<CommentService, CommentService>();
builder.Services.AddScoped<TaskService, TaskService>();
builder.Services.AddScoped<UserService, UserService>();

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
