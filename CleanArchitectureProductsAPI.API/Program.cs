using CleanArchitectureProductsAPI.API.Middleware;
using CleanArchitectureProductsAPI.Application;
using CleanArchitectureProductsAPI.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Register services from each layer
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();

// Turns validation exceptions into 400 responses
builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
builder.Services.AddProblemDetails();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware pipeline (order matters)
app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
