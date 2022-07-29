﻿using Backwalls.Buildings;
using FUtility.FUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Backwalls.UI
{
    internal class PatternSelector : KMonoBehaviour
    {
        [SerializeField]
        private PatternToggle patternTogglePrefab;

        [SerializeField]
        private ToggleGroup patternToggleGroup;

        public Action<BackwallPattern> OnSetVariant;

        private Dictionary<string, PatternToggle> patternToggles = new Dictionary<string, PatternToggle>();

        protected override void OnPrefabInit()
        {
            base.OnPrefabInit();

            var patterns = transform.Find("Scroll View/Viewport/Content");
            patternTogglePrefab = patterns.Find("TogglePrefab").gameObject.AddComponent<PatternToggle>();
            patternToggleGroup = patterns.FindOrAddComponent<ToggleGroup>();
            patternToggleGroup.allowSwitchOff = true;
            patternToggleGroup.SetAllTogglesOff();
        }

        public void SetPattern(string pattern)
        {
            if (patternToggles.TryGetValue(pattern, out var toggle))
            {
                toggle.isOn = true;
            }
        }

        public void SetupVariantToggles()
        {
            Mod.variants = Mod.variants
                .OrderBy(v => v.sortOrder)
                .ThenBy(v => v.name)
                .ToList();

            foreach (Transform toggle in patternToggleGroup.transform)
            {
                //Destroy(toggle);
            }

            foreach (var variant in Mod.variants)
            {
                var toggle = Instantiate(patternTogglePrefab, patternToggleGroup.transform);
                toggle.transform.Find("Image").GetComponent<Image>().sprite = variant.UISprite;
                toggle.gameObject.SetActive(true);
                toggle.Setup(variant);
                toggle.group = patternToggleGroup;
                toggle.onValueChanged.AddListener(value =>
                {
                    if(value)
                    {
                        OnSetVariant?.Invoke(toggle.pattern);
                    }

                    toggle.UpdateState(value);
                });

                patternToggleGroup.RegisterToggle(toggle);
                patternToggles.Add(variant.ID, toggle);

                Helper.AddSimpleToolTip(toggle.gameObject, variant.name);
            }
        }
        public class PatternToggle : Toggle
        {
            public BackwallPattern pattern;
            private Image bg;
            private static Color defaultColor = new Color32(62, 67, 87, 255);
            private static Color selectedColor = new Color32(129, 138, 179, 255);

            public void Setup(BackwallPattern pattern)
            {
                this.pattern = pattern;
                bg = GetComponent<Image>();
            }

            public void UpdateState(bool on)
            {
                if (on)
                {
                    PlaySound(UISoundHelper.Click);
                    bg.color = selectedColor;
                }
                else
                {
                    bg.color = defaultColor;
                }
            }
        }
    }
}
