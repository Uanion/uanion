using Uanion.API;

var builder = WebApplication.CreateBuilder(args);
var app = builder
    .ConfigurationServices()
    .ConfigurePipeline();

app.Run();
