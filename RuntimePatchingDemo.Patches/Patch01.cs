﻿using HarmonyLib;

namespace RuntimePatchingDemo.Patches;

[HarmonyPatch(typeof(SomeClassToPatch))]
[HarmonyPatch(nameof(SomeClassToPatch.Count))]
internal class Patch01
{
    private static readonly AccessTools.FieldRef<SomeClassToPatch, bool> isRunningRef =
        AccessTools.FieldRefAccess<SomeClassToPatch, bool>("isRunning");

    private static bool Prefix(SomeClassToPatch __instance, ref int ___counter)
    {
        Console.WriteLine("patch: start prefix");
        Console.WriteLine($"patch: it is running: {isRunningRef(__instance)}");
        isRunningRef(__instance) = true;
        if (___counter > 100)
        {
            Console.WriteLine("patch: counter already above 100, not calling original method");
            // Do not call original method (and subsequent prefixes).
            return false;
        }

        Console.WriteLine("patch: increment counter one more, calling original method");
        ___counter += 1;

        // Do call original method (and subsequent prefixes).
        return true;
    }

    private static void Postfix(ref int __result)
    {
        Console.WriteLine("patch: start postfix");
        Console.WriteLine("patch: doubling the result");
        __result *= 2;
    }
}