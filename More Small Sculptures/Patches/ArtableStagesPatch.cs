﻿using Database;
using FUtility;
using FUtilityArt;
using HarmonyLib;

namespace MoreSmallSculptures.Patches
{
    public class ArtableStagesPatch
    {
        private const string ANIM_FILE = "mss_sculptures_kanim";
        private const string TARGET_DEF = SmallSculptureConfig.ID;

        [HarmonyPatch(typeof(ArtableStages), MethodType.Constructor, typeof(ResourceSet))]
        public class TargetType_Ctor_Patch
        {
            public static void Postfix(ArtableStages __instance)
            {
                ArtHelper.GetDefaultDecors(__instance, SculptureConfig.ID, out var greatDecor, out var okayDecor, out var uglyDecor);

                __instance.Add(CreateGreatStage("baby_pip", greatDecor));
                __instance.Add(CreateGreatStage("two_baby_pips", greatDecor));
                __instance.Add(CreateGreatStage("baby_beeta", greatDecor));
                __instance.Add(CreateGreatStage("baby_pincher", greatDecor));
                __instance.Add(CreateGreatStage("catcoon", greatDecor));
                __instance.Add(CreateGreatStage("cat", greatDecor));
                __instance.Add(CreateGreatStage("isaac_suncard", greatDecor));
                __instance.Add(CreateGreatStage("totoro", greatDecor));
                __instance.Add(CreateGreatStage("chu_totoro", greatDecor));
                __instance.Add(CreateGreatStage("chibi_totoro", greatDecor));

                __instance.Add(CreateOkayStage("duck", okayDecor));

                __instance.Add(CreateBadStage("hightaste", uglyDecor));
                __instance.Add(CreateBadStage("banan", uglyDecor));
            }

            private static ArtableStage CreateStage(string stageId, int decor, string name, bool cheer, ArtableStatusItem statusItem)
            {
                var id = $"{TARGET_DEF}_{stageId}";
                Log.Debuglog("ADDED STAGE " + id);
                Mod.myOverrides.Add(id);

                return new ArtableStage(
                    id,
                    name,
                    ANIM_FILE,
                    stageId,
                    decor,
                    cheer,
                    statusItem,
                    TARGET_DEF);
            }

            private static ArtableStage CreateGreatStage(string stageId, int decor)
            {
                return CreateStage(
                    stageId,
                    decor,
                    STRINGS.BUILDINGS.PREFABS.SCULPTURE.EXCELLENTQUALITYNAME,
                    true,
                    Db.Get().ArtableStatuses.Great);
            }

            private static ArtableStage CreateBadStage(string stageId, int decor)
            {
                return CreateStage(
                    stageId,
                    decor,
                    STRINGS.BUILDINGS.PREFABS.SCULPTURE.POORQUALITYNAME,
                    false,
                    Db.Get().ArtableStatuses.Ugly);
            }

            private static ArtableStage CreateOkayStage(string stageId, int decor)
            {
                return CreateStage(
                    stageId,
                    decor,
                    STRINGS.BUILDINGS.PREFABS.SCULPTURE.AVERAGEQUALITYNAME,
                    false,
                    Db.Get().ArtableStatuses.Okay);
            }
        }
    }
}
