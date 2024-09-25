using GolfApi.Data;
using GolfApi.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer(); // Adds services for API documentation
builder.Services.AddSwaggerGen(); // Adds Swagger support for API documentation

// Register HttpClient and GolfApiService for dependency injection
builder.Services.AddHttpClient<GolfApiService>(); // Registers HttpClient and GolfApiService to make HTTP requests

// Register GolfAppContext
builder.Services.AddDbContext<GolfAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GolfAppDatabase"))); // Registers GolfAppContext to manage database interactions

// Configure JSON Serializer settings
builder.Services.AddControllers().AddJsonOptions(x =>
{
    // Ignore circular references during JSON serialization
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowSpecificOrigin",
        policy =>
        {
            // Allows requests from the specified origin
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader() // Allows any headers in requests
                .AllowAnyMethod(); // Allows any HTTP method in requests
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // Enable Swagger UI in development environment
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS

// Use CORS policy to handle cross-origin requests
app.UseCors("AllowSpecificOrigin");

app.UseAuthorization(); // Adds middleware for authorization

app.MapControllers(); // Maps controllers to endpoints

app.Run(); // Starts the application

