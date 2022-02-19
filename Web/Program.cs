using Geolocation.API;
using Geolocation.Logic.Api.Services;
using Geolocation.Logic.Core.Services;
using Geolocation.ObjectStorage.Api.Data;
using Geolocation.ObjectStorage.Api.Services;
using Geolocation.ObjectStorage.Core;
using Geolocation.ObjectStorage.Core.Services;
using System.Text.Json;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
}); ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<DbContext>();
builder.Services.AddScoped<IDataService, DataService>();

builder.Services.AddSingleton<IScenarioObjectStorage, ScenarioObjectStorage>();
builder.Services.AddTransient<IScenarioService, ScenarioService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IScenarioManager, ScenarioManager>();
builder.Services.AddTransient<IActionInitiator, ActionInitiator>();
builder.Services.AddTransient<ITriggerInitiator, TriggerInitiator>();

builder.Services.AddSignalR();
builder.Services.AddCors();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(builder => builder.AllowAnyOrigin());

app.MapControllers();

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<ScenarioHub>("/scenario");
});

app.Run();
