using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TechnoShopApi.Inventory.Application.Internal.CommandServices;
using TechnoShopApi.Inventory.Application.Internal.QueryServices;
using TechnoShopApi.Inventory.Domain.Repositories;
using TechnoShopApi.Inventory.Domain.Services;
using TechnoShopApi.Inventory.Infrastructure.Persistence.EFC;
using TechnoShopApi.Shared.Domain.Repositories;
using TechnoShopApi.Shared.Infrastructure.Interfaces.ASP;
using TechnoShopApi.Shared.Infrastructure.Interfaces.Middleware;
using TechnoShopApi.Shared.Infrastructure.Persistence.EFC.Configuration;
using TechnoShopApi.Shared.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers( options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });




// shared bounded context injection configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// news bounded context injection configuration DEPENDENCY INJECTION
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IContainerRepository, ContainerRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();
builder.Services.AddScoped<IContainerCommandService, ContainerCommandService>();
// configure lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
  options.SwaggerDoc("vi", new OpenApiInfo
  {
      Title = "TechnoShop API",
      Version = "v1",
      Description = ".NET 8 API for ilustrate DDD and Clean Architecture and CQRS",
  });
});
var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/vi/swagger.json", "TechnoShop API");
    });
}

// Add authorization middleware to pipeline
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();