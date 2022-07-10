using System.Reflection;
using System.Runtime.Loader;

namespace AssemblyModules.Core;

public class AssemblyModuleContext : AssemblyLoadContext
{
    public AssemblyModuleContext() : base(isCollectible: true) { }

    protected override Assembly? Load(AssemblyName assemblyName) => base.Load(assemblyName);
}