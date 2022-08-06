using HarmonyLib;
using UnityEngine;

namespace Spectate_On_Death
{
    [HarmonyPatch(typeof(PLCameraMode_LocalPawn), "GetAvailableViewPawn")]
    class SpectateOnDeath
    {
        static void Postfix(PLCameraMode_LocalPawn __instance, ref PLPawn __result)
        {
            if (__result == null)
            {
                if (__instance.CurrentViewPawn == null)
                {
                    __instance.NextViewPawn();
                }
                __result = __instance.CurrentViewPawn;
                if (__result != null) PLGlobal.Instance.SetBottomInfo("", "[<] Spectating: " + __result.GetName() + " [>]", "", "");
            }
        }
    }
    [HarmonyPatch(typeof(PLCameraMode_LocalPawn), "Tick")]
    class ButtonOverride
    {
        static void Postfix(PLCameraMode_LocalPawn __instance)
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.Comma))
            {
                __instance.PrevViewPawn();
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.Period))
            {
                __instance.NextViewPawn();
            }
        }
    }
}
