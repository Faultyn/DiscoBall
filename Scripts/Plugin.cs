// DiscoBall Mod Made By Fault With Help From Husky#9424

using BepInEx;
using System;
using System.Reflection;
using UnityEngine;
using Utilla;

namespace DiscoBall
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        void OnEnable()
        {
            Utilla.Events.GameInitialized += OnGameInitialized;
            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            Utilla.Events.GameInitialized -= OnGameInitialized;
            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            var str = Assembly.GetExecutingAssembly().GetManifestResourceStream("DiscoBall.Assets.imcrying");
            if (str == null)
                return;

            var bundle = AssetBundle.LoadFromStream(str);
            if (bundle == null)
                return;

            GameObject assets = bundle.LoadAsset<GameObject>("YoMamaSoFAT"); // YoMamaSoFAT this is faults doing lol
            GameObject DiscoBall = Instantiate(assets);
            DiscoBall.AddComponent<DiscoBallMusic>();

            bundle.Unload(false);
        }
    }
}
