// your code, most likely in your own dll

using System.Diagnostics;
using System.Reflection;
using System.Runtime.Loader;
using HarmonyLib;

public class MyPatcher
{
    // make sure DoPatching() is called at start either by
    // the mod loader or by your injector

    public static void DoPatching()
    {
        var patchesAssembly = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), "RuntimePatchingDemo.Patches.dll");

        Console.WriteLine($"Loading patches assembly {patchesAssembly}");
        
        AssemblyLoadContext.Default.LoadFromAssemblyPath(patchesAssembly);
        
        var harmony = new Harmony("com.example.patch");

        Console.WriteLine($"Patching {new StackTrace().GetFrame(1).GetMethod().ReflectedType.Assembly.Location}");
        harmony.PatchAll();
    }
}