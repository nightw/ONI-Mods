﻿using System.Collections.Generic;
using UnityEngine;

namespace PrintingPodRecharge.Items
{
    public class BookOfSelfImprovementConfig : IEntityConfig
    {
        public const string ID = "PrintingPodRecharge_BookOfSelfImprovement";

        public GameObject CreatePrefab()
        {
            var prefab = EntityTemplates.CreateLooseEntity(
                ID,
                STRINGS.ITEMS.BOOK_OF_SELF_IMPROVEMENT.NAME,
                STRINGS.ITEMS.BOOK_OF_SELF_IMPROVEMENT.DESC,
                1f,
                false,
                Assets.GetAnim("rrp_book_of_self_improvement_kanim"),
                "object",
                Grid.SceneLayer.BuildingBack,
                EntityTemplates.CollisionShape.RECTANGLE,
                0.8f,
                0.9f,
                true,
                0,
                SimHashes.Creature,
                additionalTags: new List<Tag>
                {
                    GameTags.MiscPickupable,
                    GameTags.PedestalDisplayable
                });

            return prefab;
        }

        public string[] GetDlcIds() => DlcManager.AVAILABLE_ALL_VERSIONS;

        public void OnPrefabInit(GameObject inst)
        {
            inst.AddComponent<SelfImprovement>();
        }

        public void OnSpawn(GameObject inst)
        {
        }
    }
}
