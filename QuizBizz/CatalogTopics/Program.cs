using CatalogTopics;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

// Add services to the container.
var services = builder.Services;

startup.ConfigureServices(services);

var app = builder.Build();

// Configure the HTTP request pipeline.
var webHostEnvironment = app.Environment;
startup.Configure(app, webHostEnvironment);

app.Run();
