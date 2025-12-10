using Microsoft.AspNetCore.Routing;

namespace villsource.Sdk;

public interface IPlugin
{
    string Name { get; }
    void MapEndpoints(IEndpointRouteBuilder endpoints);
}