﻿using FUtility;
using HarmonyLib;

namespace AsphaltStairs
{
    public class LocalizationPatch
    {
        [HarmonyPatch(typeof(Localization), "Initialize")]
        public class Localization_Initialize_Patch
        {
            public static void Postfix()
            {
                Loc.Translate(typeof(STRINGS), true);
            }
        }
    }
}
