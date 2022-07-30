﻿using Backwalls.Cmps;
using UnityEngine;

namespace Backwalls.Buildings
{
    public class DecorativeBackwallConfig : IBuildingConfig
    {
        public const string ID = "Backwall_DecorativeBackwall";

        public override BuildingDef CreateBuildingDef()
        {
            return BackwallTemplate.CreateDef(ID, "floor_glass_kanim");
        }

        public override void DoPostConfigureUnderConstruction(GameObject go)
        {
            go.AddComponent<BackwallPlanner>();
        }

        public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
        {
            GeneratedBuildings.MakeBuildingAlwaysOperational(go);
            BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
            go.AddOrGet<CopyBuildingSettings>().copyGroupTag = ID;
        }

        public override void DoPostConfigureComplete(GameObject go)
        {
            GeneratedBuildings.RemoveLoopingSounds(go);
            go.AddComponent<BackwallLink>();
            go.AddComponent<Backwall>();
        }
    }
}
