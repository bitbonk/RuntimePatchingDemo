// your code, most likely in your own dll

using HarmonyLib;

public class MyPatcher
{
    // make sure DoPatching() is called at start either by
    // the mod loader or by your injector

    public static void DoPatching()
    {
        var harmony = new Harmony("com.example.patch");
        harmony.PatchAll();
    }
}