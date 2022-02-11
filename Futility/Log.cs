﻿using System;
using System.Collections.Generic;

namespace FUtility
{
    public class Log
    {
        public static string modName = typeof(Log).Assembly.GetName().Name.Replace("Merged", "");
        private static string prefix = $"[{modName}]: ";

        public static void SetName(string name)
        {
            prefix = $"[{name}]: ";
        }

        public static void PrintVersion()
        {
            Info($"Loaded version {GetVersion()}");
        }

        public static string GetVersion() => typeof(Log).Assembly.GetName().Version.ToString();

        public static void Info(params object[] arg)
        {
            try
            {
                Debug.Log(prefix + string.Join(", ", arg));
            }
            catch (Exception e)
            {
                Warn(e);
            }
        }

        public static void Warning(params object[] arg)
        {
            try
            {
                Debug.LogWarning(prefix + string.Join(", ", arg));
            }
            catch (Exception e)
            {
                Warn(e);
            }
        }

        public static void Assert(string name, object arg)
        {
            if(arg == null)
            {
                Warning($"Assert failed, {name} is null");
            }
        }

        public static void Debuglog(params object[] arg)
        {
#if DEBUG
            try
            {
                Debug.Log(prefix + " (debug) " + string.Join(", ", arg));
            }
            catch (Exception e)
            {
                Warn(e);
            }
#endif
        }

        public static void Error(object arg)
        {
            try
            {
                Debug.LogError(prefix + arg.ToString());
            }
            catch (Exception e)
            {
                Warn(e);
            }
        }

        public static void PrintInstructions(List<HarmonyLib.CodeInstruction> codes)
        {
            Debuglog("\n");
            for(int i = 0; i < codes.Count; i++)
            {
                Debuglog(codes[i]);
            }
        }

        private static void Warn(Exception e)
        {
        }
    }
}
