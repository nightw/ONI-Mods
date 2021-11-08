﻿namespace DecorPackA.Buildings.StainedGlassTile
{
    class SedimentaryRockSGTConfig : DefaultStainedGlassTileConfig
    {
        private static readonly string name = "SedimentaryRock";
        new public static string ID = Mod.PREFIX + name + "StainedGlassTile";

        public override BuildingDef CreateBuildingDef() => StainedGlassHelper.GetDef(name);
    }
}