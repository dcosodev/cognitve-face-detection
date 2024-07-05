using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using FaceDetectionAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Load configuration from appsettings.json
var configuration = builder.Configuration;

// Add FaceDetectionService with configuration
var endpoint = configuration["AzureFaceApi:Endpoint"];
var subscriptionKey = configuration["AzureFaceApi:SubscriptionKey"];

if (string.IsNullOrEmpty(endpoint) || string.IsNullOrEmpty(subscriptionKey))
{
    throw new InvalidOperationException("AzureFaceApi:Endpoint and AzureFaceApi:SubscriptionKey must be configured.");
}

builder.Services.AddSingleton(new FaceDetectionService(endpoint, subscriptionKey));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
