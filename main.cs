
using REFrameworkNET;
using REFrameworkNET.Attributes;

namespace PRAGMATA_AP;

public class MyPlugin
{
    [PluginEntryPoint]
    public static void Main()
    {
        API.LogInfo("Hello World");     
    }
}