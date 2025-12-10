using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using villsource.Sdk;

namespace villsource.module.a;

public class APluginContest : IPlugin
{
    public string Name => "APlugin";
    
    public void MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/", () => "villsource module A");
        endpoints.MapGet("/1", () => "villsource module A1");
        endpoints.MapGet("/2", () => "villsource module A2");
        endpoints.MapGet("/3", () => "villsource module A3");
    }
}