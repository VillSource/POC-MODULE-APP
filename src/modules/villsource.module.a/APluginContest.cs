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
    }
}