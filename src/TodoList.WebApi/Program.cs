using Microsoft.EntityFrameworkCore;
using Serilog;
using TodoList.WebApi.Configurations;
using TodoList.WebApi.Data;
using TodoList.WebApi.Interfaces.Managers;
using TodoList.WebApi.Interfaces.Repositories;
using TodoList.WebApi.Interfaces.Services;
using TodoList.WebApi.Middlewares;
using TodoList.WebApi.Repositories;
using TodoList.WebApi.Security;
using TodoList.WebApi.Services;

#region  Services
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();
builder.Services.ConfigureJwt(builder.Configuration.GetSection("Jwt"));
builder.Services.ConfigureSwaggerAuthorize();

//Caching 
builder.Services.AddMemoryCache();

//-> database
var connectionString = builder.Configuration.GetConnectionString("PostgreSQLProductionDb");
builder.Services.AddDbContext<AppDbContext>(dbOptions => {
    dbOptions.UseNpgsql(connectionString);
    dbOptions.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) =>
   loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));

//-> Repository Reletions
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//-> Service Reletions
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IEmailService, EmailService>();
#endregion

#region Middlewares
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.MapControllers();
app.Run();
#endregion