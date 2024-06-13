using HarmonyLib;

namespace RuntimePatchingDemo.Patches;

[HarmonyPatch(typeof(SomeGameClass))]
[HarmonyPatch("DoSomething")] // if possible use nameof() here
class Patch01
{
    static AccessTools.FieldRef<SomeGameClass, bool> isRunningRef =
        AccessTools.FieldRefAccess<SomeGameClass, bool>("isRunning");

    static bool Prefix(SomeGameClass __instance, ref int ___counter)
    {
        isRunningRef(__instance) = true;
        if (___counter > 100)
            return false;
        ___counter = 0;
        return true;
    }

    static void Postfix(ref int __result) => __result *= 2;
}