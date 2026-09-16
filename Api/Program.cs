using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

if (builder.Environment.IsDevelopment())
{
	builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.AddDbContext<SmartTrackerDbContext>(options =>
	options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IGameRepository, GameRepository>();

builder.Services.AddHttpsRedirection(options =>
{
	options.HttpsPort = 7203;
});


builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowBlazorClient", policy =>
	{
		policy.WithOrigins("https://localhost:7255")
			  .AllowAnyMethod()
			  .AllowAnyHeader();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();

	app.MapScalarApiReference(option =>
	{
		option.Title = "SmartTracker API";
		option.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
	});
}


app.UseCors("AllowBlazorClient");

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
