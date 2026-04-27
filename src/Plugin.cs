using PRAGMATA.AP;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using System;

namespace PRAGMATA;

public class Plugin {
    //static app.InventoryManager inventoryManager = API.GetManagedSingletonT<app.InventoryManager>();
    //static app.ItemManager itemManager = API.GetManagedSingletonT<app.ItemManager>();

    [PluginEntryPoint]
    public static void Main() {
        API.LogInfo("~~~~ AP Loaded ~~~~");

        TDB tdb = API.GetTDB();

        app.InventoryManager inventoryManager = API.GetManagedSingletonT<app.InventoryManager>();
        app.ItemManager itemManager = API.GetManagedSingletonT<app.ItemManager>();

        _System.UInt32_Array1D itemIDs = inventoryManager.getItemIDs();

        for (int i = 0; i < itemIDs.Length; i++) {
            uint itemID = itemIDs.Get(i);
            string message = $"{itemID} || ";

            app.TextMessageData textData = itemManager.getNameData(itemID);

            if (textData != null)
                message += textData.getMessage();

            API.LogInfo($"{message}");
        }
    }

    [MethodHook(typeof(app.InventoryManager), nameof(app.InventoryManager.acquireItem), MethodHookType.Pre)]
    public static PreHookResult PreAcquireItem(Span<ulong> args) {
        app.InventoryManager inventoryManager = ManagedObject.ToManagedObject(args[1]).As<app.InventoryManager>();
        app.AcquisitionItemInfo acquisitionItemInfo = ManagedObject.ToManagedObject(args[2]).As<app.AcquisitionItemInfo>();
        app.InventoryManager.AcquireItemOptions acquireItemOptions = ManagedObject.ToManagedObject(args[3]).As<app.InventoryManager.AcquireItemOptions>();

        string message = $"[{DateTime.Now.ToString("hh:mm:ss tt")}]    ~~ InventoryManager.acquireItem ~~";

        app.ItemQuantityInfo itemQuantityInfo = acquisitionItemInfo.ItemQuantityInfo;
        app.WeaponItemInfo weaponInfo = acquisitionItemInfo.WeaponInfo;
        app.PerkItemInfo perkInfo = acquisitionItemInfo.PerkInfo;

        if (itemQuantityInfo != null) {
            message += "\n    ItemInfo ~~ ";
            message += $"ID: {itemQuantityInfo.ID} || Qty: {itemQuantityInfo.Quantity}";
        }

        if (weaponInfo != null) {
            message += "\n    WeaponInfo ~~ ";
            message += $"ID: {weaponInfo.ID} || RemainingBullerNum: {weaponInfo.RemainingBulletNum}";
        }

        if (perkInfo != null) {
            message += "\n    PerkInfo ~~ ";
            message += $"ItemID: {perkInfo.ItemID} || PerkID: {perkInfo.PerkID} || Count: {perkInfo.Count}";
        }

        API.LogInfo(message);

        return PreHookResult.Continue;
    }

    [MethodHook(typeof(app.InventoryManager), nameof(app.InventoryManager.onAcquireItem), MethodHookType.Pre)]
    public static PreHookResult PreOnAcquireItas(Span<ulong> args) {
        // Method Arguments");
        uint itemID = (uint)args[2];
        app.WeaponItemInfo? weapon = ManagedObject.ToManagedObject(args[3])?.As<app.WeaponItemInfo>();
        app.PerkItemInfo? perk = ManagedObject.ToManagedObject(args[4])?.As<app.PerkItemInfo>();
        int unknown = (int)args[5];
        //app.InventoryManager.AcquireItemOptions acquireItemOptions = ManagedObject.ToManagedObject(args[6]).As<app.InventoryManager.AcquireItemOptions>();
        //API.LogInfo("Check6");

        string message = $"{itemID} || ";

        // Get ItemManager Item Name
        app.ItemManager itemManager = API.GetManagedSingletonT<app.ItemManager>();
        app.TextMessageData textData = itemManager.getNameData(itemID);
        if (textData != null)
            message += $"ItemManager Name: {textData.getMessage()}";

        // Get Weapon Info
        if (weapon != null)
            message += $"\n    Weapon ID: {weapon.ID} || Remaining Bullet Num: {weapon.RemainingBulletNum}";

        // Get Perk Info
        if (perk != null)
            message += $"\n    Perk Item ID: {perk.ItemID} || Perk ID: {perk.PerkID} || Perk Count: {perk.Count}";

        if (unknown != 0)
            message += $"\n    args[5]: {unknown}";

        API.LogInfo($"[{DateTime.Now.ToString("hh:mm:ss tt")}]    ~~ InventoryManager.onAcquireItem ~~");
        API.LogInfo($"    {message}");

        return PreHookResult.Continue;
    }

    [PluginExitPoint]
    public static void OnUnload() {
        if (Client.isConnected)
            Client.Disconnect().Wait();

        //ImGui.End();
        API.LogInfo("C# plugin unloaded.");
    }
}
