﻿using Backwalls.Buildings;
using FUtility;
using HarmonyLib;

namespace Backwalls.Patches
{
    public class GeneratedBuildingsPatch
    {
        [HarmonyPatch(typeof(GeneratedBuildings), "LoadGeneratedBuildings")]
        public static class GeneratedBuildings_LoadGeneratedBuildings_Patch
        {
            public static void Prefix()
            {
                ModUtil.AddBuildingToPlanScreen(Consts.BUILD_CATEGORY.FURNITURE, BackwallConfig.ID, Consts.SUB_BUILD_CATEGORY.Furniture.LIGHTS, FloorLampConfig.ID);
            }

            public static void Postfix()
            {
                BackwallPattern.InitDefaultMaterial();

                foreach (var def in Assets.BuildingDefs)
                {
                    if (def.BlockTileAtlas != null && !def.BuildingComplete.HasTag(ModAssets.Tags.noBackwall))
                    {
                        Mod.variants.Add(new BackwallPattern(def));
                    }
                }

                // Adds a solid color variant
                var sprite = Assets.GetBuildingDef(ExteriorWallConfig.ID).GetUISprite();
                var solidColor = new BackwallPattern("BlankPattern", "Solid Color", ModAssets.blankTileTex, sprite, 999);
                Mod.variants.Add(solidColor);
            }
        }
    }
}
