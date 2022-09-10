﻿using FUtility;
using HarmonyLib;
using PrintingPodRecharge.Cmps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;

namespace PrintingPodRecharge.Patches
{
    public class CharacterSelectionControllerPatch
    {
        [HarmonyDebug]
        [HarmonyPatch(typeof(CharacterSelectionController), "InitializeContainers")]
        public static class CharacterSelectionController_InitializeContainers_Patch
        {
            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> orig)
            {
                var codes = orig.ToList();

                ReplaceNumber(codes, "numberOfDuplicantOptions", "GetDupeCount");
                ReplaceNumber(codes, "numberOfCarePackageOptions", "GetItemCount");

                return codes;
            }

            private static void ReplaceNumber(List<CodeInstruction> codes, string fieldName, string methodName)
            {
                var fieldInfo = AccessTools.Field(typeof(CharacterSelectionController), fieldName);
                var methodInfo = AccessTools.Method(typeof(CharacterSelectionController_InitializeContainers_Patch), methodName, new Type[] { typeof(int) });

                var index = codes.FindLastIndex(c => c.LoadsField(fieldInfo));

                if(index == -1)
                {
                    Log.Warning($"Could not patch CharacterSelectionController {fieldName}.");
                    return;
                }

                codes.Insert(index + 1, new CodeInstruction(OpCodes.Call, methodInfo));
            }

            public static int GetDupeCount(int count)
            {
                return ImmigrationModifier.Instance != null ? ImmigrationModifier.Instance.GetDupeCount(count) : count;
            }

            public static int GetItemCount(int count)
            {
                return ImmigrationModifier.Instance != null ? ImmigrationModifier.Instance.GetItemCount(count) : count;
            }
        }
    }
}
