﻿using FUtility;
using KMod;
using System;
using System.IO;

namespace FLocalization
{
    public class Translations
    {
        public static void RegisterForTranslation(Type root, bool generateTemplate = false)
        {
            Localization.RegisterForTranslation(root);
            LoadStrings();
            LocString.CreateLocStringKeys(root, null);

            if (generateTemplate)
            {
                Localization.GenerateStringsTemplate(root, Path.Combine(Manager.GetDirectory(), "strings_templates"));
            }
        }

        // Loads user created translations
        private static void LoadStrings()
        {
            string code = Localization.GetLocale()?.Code;

            if (code.IsNullOrWhiteSpace()) return;

            string path = Path.Combine(Utils.ModPath, "translations", code + ".po");

            if (File.Exists(path))
            {
                Localization.OverloadStrings(Localization.LoadStringsFile(path, false));
                Log.Info($"Found translation file for {code}.");
            }
        }
    }
}