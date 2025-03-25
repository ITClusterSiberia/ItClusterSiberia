using Domain.Contracts.Repositories;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer(); 
builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();

var connectionString = builder.Configuration.GetConnectionString("DbConnection");
builder.Services.AddScoped<IUserRepository>(_ => new UserRepository(connectionString));
builder.Services.AddScoped<ISystemRoleRepository>(_ => new SystemRoleRepository(connectionString));
//builder.AddServiceDefaults();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
