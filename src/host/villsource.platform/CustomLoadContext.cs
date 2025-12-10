using System.Reflection;
using System.Runtime.Loader;

namespace villsource.platform;

public class CustomLoadContext : AssemblyLoadContext
{
    private readonly string _dependencyPath;
    public CustomLoadContext(string dependencyPath)
    {
        _dependencyPath = dependencyPath;
    }
    
    protected override Assembly? Load(AssemblyName assemblyName)
    {
        string assemblyPath = Path.Combine(_dependencyPath, assemblyName.Name + ".dll");
        if (File.Exists(assemblyPath))
        {
            return LoadFromAssemblyPath(assemblyPath);
        }
        return null; // Use default resolution if not found
    }
}