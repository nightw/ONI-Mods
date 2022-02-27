﻿using HarmonyLib;
using System;
using System.Collections.Generic;
using static SandboxToolParameterMenu.SelectorValue;

namespace CrittersDropBones.Patches
{
    public class SandboxToolParameterMenuPatch
    {
        [HarmonyPatch(typeof(SandboxToolParameterMenu), "ConfigureEntitySelector")]
        public static class SandboxToolParameterMenu_ConfigureEntitySelector_Patch
        {
            internal static void Postfix(SandboxToolParameterMenu __instance)
            {
                var filters = new List<SearchFilter>(__instance.entitySelector.filters);

                foreach (var filter in filters)
                {
                    if (filter.Name == global::STRINGS.UI.SANDBOXTOOLS.FILTERS.ENTITIES.SPECIAL)
                    {
                        var oldCondition = filter.condition;
                        filter.condition = entity => oldCondition.Invoke(entity) || entity is KPrefabID entityID && entityID.HasTag(ModAssets.Tags.Bones);
                        break;
                    }
                }

                __instance.entitySelector.filters = filters.ToArray();
                UpdateOptions(__instance, filters);
            }

            private static void UpdateOptions(SandboxToolParameterMenu __instance, List<SearchFilter> filters)
            {
               var options = ListPool<object, SandboxToolParameterMenu>.Allocate();
                foreach (var prefab in Assets.Prefabs)
                {
                    foreach (var filter in filters)
                    {
                        if (filter.condition(prefab))
                        {
                            options.Add(prefab);
                            break;
                        }
                    }
                }

                __instance.entitySelector.options = options.ToArray();
                options.Recycle();
            }
        }
    }
}