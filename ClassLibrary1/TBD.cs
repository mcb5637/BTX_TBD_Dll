using BattleTech;
using Harmony;
using HBS.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TBD
{
    public class TBD
    {
        public static void Init(string directory, string settingsJSON)
        {
            var harmony = HarmonyInstance.Create("com.github.mcb5637.TBD");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
    [HarmonyPatch(typeof(StarSystem), nameof(StarSystem.Rehydrate))]
    public class StarSystem_Rehydrate
    {
        public static void Postfix(StarSystem __instance)
        {
            if (__instance.Tags.Contains("planet_ruins"))
            {
                __instance.Tags.Remove("planet_ruins");
                __instance.Tags.Add("planet_other_ruins");
            }
        }
    }
}
