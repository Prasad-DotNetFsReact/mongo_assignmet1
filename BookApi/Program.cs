using BookApi.Configurations;
using BookApi.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BookstoreDatabaseSettings>(
    builder.Configuration.GetSection(nameof(BookstoreDatabaseSettings)));

// Register the configuration as a singleton to be injected into services
builder.Services.AddSingleton<BookstoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<BookstoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<BookService>();

builder.Services.AddControllers();

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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


