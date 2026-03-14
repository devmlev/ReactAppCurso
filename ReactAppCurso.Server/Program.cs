using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();

app.UseAuthorization();

// Map API controllers first
app.MapControllers();

// Configure OpenAPI and Scalar (always enabled)
app.MapOpenApi();
app.MapScalarApiReference(options =>
{
    options
        .WithTitle("ReactAppCurso API")
        .WithTheme(ScalarTheme.Purple)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});

// Serve static files for SPA
app.UseDefaultFiles();
app.MapStaticAssets();

// Fallback to SPA for client-side routing (should be last)
app.MapFallbackToFile("/index.html");

app.Run();
