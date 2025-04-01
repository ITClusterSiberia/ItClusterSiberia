using Microsoft.EntityFrameworkCore;
using YourNamespace.Data;

var builder = WebApplication.CreateBuilder(args);

// Добавляем DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Настраиваем контроллеры
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
