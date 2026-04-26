using REFrameworkNET;
using REFrameworkNET.Attributes;
using System;
using System.Collections.Generic;

namespace PRAGMATA_AP;

public class Plugin {
    [PluginEntryPoint]
    public static void Main() {
        API.LogInfo("~~~~ AP Loaded ~~~~");
    }

    [MethodHook(typeof(app.InventoryManager), nameof(app.InventoryManager.onAcquireItem), MethodHookType.Pre)]
    public static PreHookResult PreOnRequiredItem(Span<ulong> args) {
        uint itemID = (uint)args[2];
        string message = "";

        if (itemIDs.ContainsKey(itemID)) {
            message = $"{itemID} || {itemIDs[itemID]}";
        } else {
            message = $"{itemID} || UNKNOWN, PLEASE DOCUMENT";
        }

        API.LogInfo("~~~~ onAcquireItem ~~~~");
        API.LogInfo($"[{DateTime.Now.ToString("hh:mm:ss tt")}]    {message}");

        return PreHookResult.Continue;
    }

    public static Dictionary<uint, string> itemIDs = new(){
        {2227368435, "Lunafilament"},
        {663376744, "Lunafilament (1)"},
        {2074518467, "Lunafilament (S)"},
        {2870192522, "Refill Repair Cartridge"},
        {1984889503, "Upgrade Materials??"},
        {187746965, "Upgrade Materials??"},
        {1305591762, "Repair Kit"},
        {163051433, "Shockwave Gun"},
        {860467045, "Charge Piercer"},
        {3320209826, "Homing Missiles"},
        {3613536690, "Photon Laser"},
        {2600790876, "Sticky Bombs"},
        {2427932221, "Stasis Net"},
        {2620883957, "Riot Blaster"},
        {1504483110, "Decoy Generator"},
        {2629333698, "Impact Barrier"},
        {2943986455, "Decode"},
        {2943986455, "Multihack"},
        {1852445624, "Lunafilament (M)"},
        {1179591319, "Lunafilament (L or XL)"},
        {179699175, "Lunafilament (XL or L)"},
        {2429803748, "Red Gate Key"},
        {701076331, "Cabin Coin"},
        {1123299822, "REM (Skateboard)"},
    };

    [PluginExitPoint]
    public static async void OnUnload() {
        if (Archipelago.isConnected)
            Archipelago.Disconnect().Wait();

        //ImGui.End();
        API.LogInfo("C# plugin unloaded.");
    }
}
