using System.Reflection;
using villsource.platform;
using villsource.Sdk;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();
var pluginsEndpoint = app.MapGroup("plugins");

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var parth = @"/home/pandora/Desktop/POC-Modular/src/modules/villsource.module.a/bin/Debug/net10.0/";
var loader = new CustomLoadContext(parth);
var assembly = loader.LoadFromAssemblyName(new AssemblyName(@"villsource.module.a"));

var pluginImplementations = assembly.GetTypes()
    .Where(t => !t.IsInterface && !t.IsAbstract && typeof(IPlugin).IsAssignableFrom(t))
    .ToList();

foreach (var pluginImplementation in pluginImplementations)
{
    var plugin = (IPlugin?)Activator.CreateInstance(pluginImplementation);
    if (plugin == null)
    {
        Console.WriteLine($"Plugin {pluginImplementation.Name} could not be found.");
        continue;
    }
    var pluginEndpoint = pluginsEndpoint.MapGroup(plugin.Name);
    plugin.MapEndpoints(pluginEndpoint);
}

app.MapGet("/", () => "hello");

app.UseHttpsRedirection();

app.Run();