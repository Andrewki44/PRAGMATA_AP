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
        {663376744,  "Lunafilament (1)"},
        {2074518467, "Lunafilament (S)"},
        {2870192522, "Refill Repair Cartridge"},
        {1984889503, "Upgrade Materials??"},
        {187746965, "Upgrade Materials??"},
        {1305591762, "Repair Kit"},
        {163051433, "Shockwave Gun"},
    };

    [PluginExitPoint]
    public static async void OnUnload() {
        if (Archipelago.isConnected)
            Archipelago.Disconnect().Wait();

        //ImGui.End();
        API.LogInfo("C# plugin unloaded.");
    }
}
