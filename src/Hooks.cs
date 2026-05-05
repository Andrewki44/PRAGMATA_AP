using PRAGMATA.AP;
using PRAGMATA.Data;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using System;
using System.Numerics;

namespace PRAGMATA {
    public partial class Plugin {
        //[MethodHook(typeof(app.InventoryManager), nameof(app.InventoryManager.acquireItem), MethodHookType.Pre)]
        //public static PreHookResult PreAcquireItem(Span<ulong> args) {
        //    app.InventoryManager inventoryManager = ManagedObject.ToManagedObject(args[1]).As<app.InventoryManager>();
        //    app.AcquisitionItemInfo acquisitionItemInfo = ManagedObject.ToManagedObject(args[2]).As<app.AcquisitionItemInfo>();
        //    app.InventoryManager.AcquireItemOptions acquireItemOptions = ManagedObject.ToManagedObject(args[3]).As<app.InventoryManager.AcquireItemOptions>();

        //    string message = $"[{DateTime.Now.ToString("hh:mm:ss tt")}]    ~~ InventoryManager.acquireItem ~~";

        //    app.ItemQuantityInfo itemQuantityInfo = acquisitionItemInfo.ItemQuantityInfo;
        //    app.WeaponItemInfo weaponInfo = acquisitionItemInfo.WeaponInfo;
        //    app.PerkItemInfo perkInfo = acquisitionItemInfo.PerkInfo;

        //    if (itemQuantityInfo != null) {
        //        message += "\n    ItemInfo ~~ ";
        //        message += $"ID: {itemQuantityInfo.ID} || Qty: {itemQuantityInfo.Quantity}";
        //    }

        //    if (weaponInfo != null) {
        //        message += "\n    WeaponInfo ~~ ";
        //        message += $"ID: {weaponInfo.ID} || RemainingBullerNum: {weaponInfo.RemainingBulletNum}";
        //    }

        //    if (perkInfo != null) {
        //        message += "\n    PerkInfo ~~ ";
        //        message += $"ItemID: {perkInfo.ItemID} || PerkID: {perkInfo.PerkID} || Count: {perkInfo.Count}";
        //    }

        //    API.LogInfo(message);

        //    return PreHookResult.Continue;
        //}

        //[MethodHook(typeof(app.InventoryManager), nameof(app.InventoryManager.onAcquireItem), MethodHookType.Pre)]
        //public static PreHookResult PreOnAcquireItas(Span<ulong> args) {
        //    // Method Arguments");
        //    uint itemID = (uint)args[2];
        //    app.WeaponItemInfo? weapon = ManagedObject.ToManagedObject(args[3])?.As<app.WeaponItemInfo>();
        //    app.PerkItemInfo? perk = ManagedObject.ToManagedObject(args[4])?.As<app.PerkItemInfo>();
        //    int qty = (int)args[5];
        //    //app.InventoryManager.AcquireItemOptions acquireItemOptions = ManagedObject.ToManagedObject(args[6]).As<app.InventoryManager.AcquireItemOptions>();
        //    //API.LogInfo("Check6");

        //    string message = $"{itemID} || ";

        //    // Get ItemManager Item Name
        //    app.ItemManager itemManager = API.GetManagedSingletonT<app.ItemManager>();
        //    app.TextMessageData textData = itemManager.getNameData(itemID);
        //    if (textData != null)
        //        message += $"ItemManager Name: {textData.getMessage()}";

        //    // Get Weapon Info
        //    if (weapon != null)
        //        message += $"\n    Weapon ID: {weapon.ID} || Remaining Bullet Num: {weapon.RemainingBulletNum}";

        //    // Get Perk Info
        //    if (perk != null)
        //        message += $"\n    Perk Item ID: {perk.ItemID} || Perk ID: {perk.PerkID} || Perk Count: {perk.Count}";

        //    if (qty != 0)
        //        message += $"\n    Qty: {qty}";

        //    API.LogInfo($"[{DateTime.Now.ToString("hh:mm:ss tt")}]    ~~ InventoryManager.onAcquireItem ~~");
        //    API.LogInfo($"    {message}");

        //    return PreHookResult.Continue;
        //}

        //[MethodHook(typeof(app.MenuManager), nameof(app.MenuManager.enterMenu), MethodHookType.Pre)]
        //public static PreHookResult PreEnterMenu(Span<ulong> args) {
        //    uint menuID = (uint)args[2];
        //    uint menuID2 = (uint)args[3];

        //    if (menuID == 2433465066 && menuID2 == 840074355) {
        //        if (!Client.isConnected) {
        //            app.MenuManager menuManager = ManagedObject.ToManagedObject(args[1]).As<app.MenuManager>();
        //            //menuManager.leaveMenu(2433465066, 840074355);

        //            return PreHookResult.Skip;
        //        }
        //    }
        //    return PreHookResult.Continue;
        //}

        //[MethodHook(typeof(app.MenuManager), nameof(app.MenuManager.registerMenu), MethodHookType.Pre)]
        //public static PreHookResult PreRegisterMenu(Span<ulong> args) {
        //    uint menuID = (uint)args[2];
        //    uint menuID2 = (uint)args[3];

        //    if (menuID == 2433465066 && menuID2 == 840074355) {
        //        if (!Client.isConnected) {
        //            app.MenuManager menuManager = ManagedObject.ToManagedObject(args[1]).As<app.MenuManager>();
        //            //menuManager.leaveMenu(2433465066, 840074355);

        //            return PreHookResult.Skip;
        //        }
        //    }
        //    return PreHookResult.Continue;
        //}

        /// <summary>
        /// Lunafilament Chest Open Trigger
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        //[MethodHook(typeof(app.sm72_035_10PropDriver), nameof(app.sm72_035_10PropDriver.onTriggerProcessEvent), MethodHookType.Pre)]
        //public static PreHookResult PreOnFilamentContainerProcessEvent(Span<ulong> args) {
        //    app.sm72_035_10PropDriver sm72 = ManagedObject.ToManagedObject(args[1]).As<app.sm72_035_10PropDriver>();
        //    via.GameObject sm72Obj = sm72.GameObject;
        //    via.vec3 sm72Pos = sm72Obj.Transform.Position;

        //    API.LogInfo($"~~ sm72_035_10 Container Opened ~~");
        //    API.LogInfo($"X: {sm72Pos.x} || Y: {sm72Pos.y} || Z: {sm72Pos.z}");

        //    return PreHookResult.Continue;
        //}

        /// <summary>
        /// Aquire Perk Trigger
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        //[MethodHook(typeof(app.InventoryManager), nameof(app.InventoryManager.acquirePerk), MethodHookType.Pre)]
        //public static PreHookResult PreOnAcquirePerk(Span<ulong> args) {
        //    app.PerkItemInfo perk = ManagedObject.ToManagedObject(args[2]).As<app.PerkItemInfo>();

        //    if (PragmataLocationData.modLocationDict.TryGetValue(perk.PerkID, out var location)) {
        //        API.LogInfo($"Sending Location for Perk ID: {perk.PerkID} || {location.Item2}");
        //        Client.sendLocation(location.Item1, PragmataLocationData.PragmataLocationType.Mod);
        //    }

        //    return PreHookResult.Skip;
        //}

        /// <summary>
        /// Catchall for Container Objects
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        [MethodHook(typeof(app.DropItemContainerObject), nameof(app.DropItemContainerObject.acquireItems), MethodHookType.Pre)]
        public static PreHookResult PreOnContainerAcquireItem(Span<ulong> args) {
            app.DropItemContainerObject container = ManagedObject.ToManagedObject(args[1]).As<app.DropItemContainerObject>();

            if (container._ContainerHandle._Item.ItemID == 0x764F029F) {
                Vector3 containerPos = ConvertVec3(container.GameObject.Transform.Position);

                API.LogInfo($"~~ Upgrade Material Picked Up ~~");
                API.LogInfo($"X: {containerPos.X} || Y: {containerPos.Y} || Z: {containerPos.Z}");

                if (PragmataLocationData.componentLocationDict.TryGetValue(containerPos, out long componentLocationId)) {
                    Client.sendLocation(componentLocationId, PragmataLocationData.PragmataLocationType.Component);
                    return PreHookResult.Skip;
                }
            }

            return PreHookResult.Continue;
        }

        //[MethodHook(typeof(app.ItemManager), nameof(app.ItemManager.acquired), MethodHookType.Pre)]
        //public static PreHookResult PreOnItemAcquired(Span<ulong> args) {
        //    uint itemID1 = (uint)args[2];
        //    uint itemID2 = (uint)args[3];

        //    API.LogInfo($"ItemID1: {itemID1} || ItemID2: {itemID2}");

        //    return PreHookResult.Continue;
        //}

        [MethodHook(typeof(app.TreasureBoxPropDriver), nameof(app.TreasureBoxPropDriver.onItemDropEvent), MethodHookType.Pre)]
        public static PreHookResult PreOnItemDropEvent(Span<ulong> args) {
            app.TreasureBoxPropDriver treasureBox = ManagedObject.ToManagedObject(args[1]).As<app.TreasureBoxPropDriver>();
            string treasureType = treasureBox.GameObject.Name;
            //app.AcquisitionItemInfo boxItemInfo = treasureBox._TreasureData._Item.AcquisitionItemInfo;
            Vector3 boxPos = ConvertVec3(treasureBox.GameObject.Transform.Position);

            API.LogInfo("~~ Treasure Box Opened ~~");
            API.LogInfo($"Type: {treasureType}");
            API.LogInfo($"Box Position || X= {boxPos.X}, Y= {boxPos.Y}, Z= {boxPos.Z}");

            if (PragmataLocationData.treasureBoxLocationDict.TryGetValue(boxPos, out long treasureBoxLocationId)) {
                Client.sendLocation(treasureBoxLocationId, PragmataLocationData.PragmataLocationType.TreasureBox);
                return PreHookResult.Skip;
            }

            return PreHookResult.Continue;
        }
    }
}
