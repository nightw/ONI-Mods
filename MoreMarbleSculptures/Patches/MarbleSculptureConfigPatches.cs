﻿using FUtility;
using HarmonyLib;
using MoreMarbleSculptures.Components;
using System.Collections.Generic;
using UnityEngine;
using static STRINGS.BUILDINGS.PREFABS;

namespace MoreMarbleSculptures.Patches
{
    public class MarbleSculptureConfigPatches
    {
        [HarmonyPatch(typeof(MarbleSculptureConfig), "DoPostConfigureComplete")]
        public class MarbleSculptureConfig_DoPostConfigureComplete_Patch
        {
            public static void Postfix(GameObject go)
            {
                var sculpture = go.GetComponent<Sculpture>();

                if(sculpture == null)
                {
                    Log.Warning($"Sculpture component is missing from {go.name}");
                    return;
                }

                ArtHelper.GetDefaultDecors(sculpture.stages, out int greatDecor, out int okayDecor, out int uglyDecor);

                var overrides = go.AddComponent<ArtOverride>();
                overrides.animFileName = "mms_marble_kanim";
                overrides.extraStages = new List<Artable.Stage>()
                {
                   ArtHelper.CreateExcellentStage("dragon", MARBLESCULPTURE.EXCELLENTQUALITYNAME, greatDecor),
                   ArtHelper.CreateExcellentStage("talos", MARBLESCULPTURE.EXCELLENTQUALITYNAME, greatDecor),
                   ArtHelper.CreateExcellentStage("pacucorn", MARBLESCULPTURE.EXCELLENTQUALITYNAME, greatDecor),
                   ArtHelper.CreateExcellentStage("smugpip", MARBLESCULPTURE.EXCELLENTQUALITYNAME, greatDecor),
                   ArtHelper.CreateExcellentStage("panda", MARBLESCULPTURE.EXCELLENTQUALITYNAME, greatDecor),
                   ArtHelper.CreateExcellentStage("dashmaster", MARBLESCULPTURE.EXCELLENTQUALITYNAME, greatDecor),
                   ArtHelper.CreateExcellentStage("azura", MARBLESCULPTURE.EXCELLENTQUALITYNAME, greatDecor),
                   ArtHelper.CreateExcellentStage("poseidon", MARBLESCULPTURE.EXCELLENTQUALITYNAME, greatDecor),

                   ArtHelper.CreatePoorStage("smile", MARBLESCULPTURE.POORQUALITYNAME, uglyDecor)
                };

                var restorer = go.AddComponent<ArtOverrideRestorer>();
                restorer.fallbacks = new string[]
                {
                    "Default",
                    "Bad",
                    "Average",
                    "Good1"
                };

                ArtHelper.MoveStages(
                    sculpture,
                    Mod.Settings.MoveSculptures,
                    MARBLESCULPTURE.POORQUALITYNAME,
                    MARBLESCULPTURE.AVERAGEQUALITYNAME,
                    MARBLESCULPTURE.EXCELLENTQUALITYNAME,
                    uglyDecor,
                    okayDecor,
                    greatDecor);
            }
        }
    }
}
