using Hexa.NET.ImGui;
using PRAGMATA.AP;
using PRAGMATA.Data;
using REFrameworkNET;
using REFrameworkNET.Attributes;
using System.Numerics;

namespace PRAGMATA;

public partial class Plugin {
    [PluginEntryPoint]
    public static void Main() {
        API.LogInfo("~~~~ AP Loaded ~~~~");

        //app.MenuManager menuManager = API.GetManagedSingletonT<app.MenuManager>();
        //ValueTuple<uint, uint> currentMenu = (ValueTuple<uint, uint>)menuManager.currentMenu();
        //API.LogInfo($"Current Menu: {currentMenu.Item1} | {currentMenu.Item2}");

        // Weapon Unlocking

        //app.WeaponManager weaponManager = API.GetManagedSingletonT<app.WeaponManager>();

        ////API.LogInfo($"Shockwave: {weaponManager.isUnlockWeapon(163051433)}");
        //API.LogInfo($"Lim Cannon: {weaponManager.isUnlockWeapon(494541585)}");
        //weaponManager.unlockWeapon(494541585);
        //API.LogInfo($"Lim Cannon: {weaponManager.isUnlockWeapon(494541585)}");

        //_System.UInt32_Array1D weaponIDs = weaponManager.getPurchaseWeaponIDs();

        //for (int i = 0; i < weaponIDs.Length; i++) {
        //    uint weaponID = weaponIDs.Get(i);
        //    API.LogInfo($"ID: {weaponID} | {weaponManager.getNameData(weaponID).getMessage()}");
        //}

        // Chapter Unlocking

        //app.ChapterManager chapterManager = API.GetManagedSingletonT<app.ChapterManager>();
        //ManagedObject chapterStatus = app.ChapterStatus.REFType.CreateInstance(0);
        //chapterStatus.Call(".cctor()");
        //_System.UInt32_Array1D chapters = chapterManager.getCurrentChapters();
        //_System.UInt32_Array1D reqChapters = chapterManager.getReqCurrentChapters();

        //for (int i = 0; i < chapters.Length; i++) {
        //    //object obj = chapterStatus.Call("getName(System.UInt32)", [chapters.Get(i)]) ;
        //    //API.LogInfo($"Chapter: {obj}");
        //    API.LogInfo($"Chapter: {chapters.Get(i)}");
        //}

        //for (int i = 0; i < reqChapters.Length; i++) {
        //    //object obj = chapterStatus.Call("getName(System.UInt32)", [chapters.Get(i)]) ;
        //    //API.LogInfo($"Chapter: {obj}");
        //    API.LogInfo($"Req Chapter: {reqChapters.Get(i)}");
        //}

        // Checkpoint Unlocking

        //app.CheckPointManager checkpointManager = API.GetManagedSingletonT<app.CheckPointManager>();

        //_System.UInt32_Array1D releasedChapters = checkpointManager.getReleasedChapters();
        //_System.String_Array1D releasedNames = checkpointManager.getReleasedName();
        //IList<app.CheckPointInfo> checkpointList = checkpointManager._ReleasedCheckPointList;
        //IDictionary<uint, app.CheckPointInfo> obj = checkpointManager._StageCheckPointInfoDic;

        //for (int i = 0; i < releasedChapters.Length; i++) {
        //    API.LogInfo($"Chapter: {releasedChapters.Get(i)}");
        //}

        //for (int i = 0; i < releasedNames.Length; i++) {
        //    API.LogInfo($"Name: {releasedNames.Get(i)}");
        //}

        //foreach (app.CheckPointInfo checkpoint in checkpointList) {
        //    API.LogInfo($"Checkpoint: {checkpoint.CheckPointName.getMessage()}");
        //}

        ////for (uint i = 0; i < obj.Count; i++) {
        ////    API.LogInfo($"Name: {obj[i].CheckPointName.getMessage()}");
        ////}

        //foreach (uint key in obj.Keys) {
        //    API.LogInfo($"Key: {key} | Value: {obj[key].CheckPointName.getMessage()}");
        //}

        //checkpointManager.releasedCheckPoint(1302555139);
        //checkpointManager.releasedCheckPoint(1302555139);
        //checkpointManager.releasedCheckPoint(1076526282);
        //checkpointManager.releasedCheckPoint(854773287);
        //checkpointManager.releasedCheckPoint(3659416893);
        //checkpointManager.releasedCheckPoint(703194911);
        //checkpointManager.releasedCheckPoint(1183158188);
        //checkpointManager.releasedCheckPoint(205527389);
        //checkpointManager.releasedCheckPoint(898992756);
        //checkpointManager.releasedCheckPoint(493992222);

        // Item ID Scraping

        //TDB tdb = API.GetTDB();

        //app.InventoryManager inventoryManager = API.GetManagedSingletonT<app.InventoryManager>();
        //app.ItemManager itemManager = API.GetManagedSingletonT<app.ItemManager>();

        //_System.UInt32_Array1D itemIDs = inventoryManager.getItemIDs();

        //for (int i = 0; i < itemIDs.Length; i++) {
        //    uint itemID = itemIDs.Get(i);
        //    string message = $"{itemID} || ";

        //    app.TextMessageData textData = itemManager.getNameData(itemID);

        //    if (textData != null)
        //        message += textData.getMessage();

        //    API.LogInfo($"{message}");
        //}
    }

    public static void ObtainItem(uint itemId, uint amount = 1) {
        if (itemId == 0) return;

        var itemType = (itemId & 0xF000) >> 12;
        //if (amount == -1) amount = (int)((itemId & 0xFF0000) >> 16);
        itemId &= 0xFF;
        //int count;
        app.InventoryManager inventoryManager = API.GetManagedSingletonT<app.InventoryManager>();
        app.InventoryManager.AcquireItemOptions options = app.InventoryManager.AcquireItemOptions.REFType.CreateInstance(0).As<app.InventoryManager.AcquireItemOptions>();

        switch (itemType) {
            case 0x0:   // Escape Hatches & Missions
                break;
            case 0x1:
                if (PragmataData.weaponItemDict.TryGetValue(itemId, out uint weaponId)) {
                    ManagedObject weaponObj = app.WeaponItemInfo.REFType.CreateInstance(1);
                    weaponObj.Call(".ctor(System.UInt32, System.Int32)", [weaponId, amount]);
                    app.WeaponItemInfo weapon = weaponObj.As<app.WeaponItemInfo>();

                    inventoryManager.acquireWeaponItem(weapon, null, null);
                }
                break;
            case 0x3:   // REM Items
                if (PragmataData.remItemDict.TryGetValue(itemId, out uint remId)) {
                    ManagedObject obj = app.AcquisitionItemInfo.REFType.CreateInstance(1);
                    obj.Call(".ctor(System.UInt32, System.Int32)", [remId, amount]);
                    app.AcquisitionItemInfo item = obj.As<app.AcquisitionItemInfo>();

                    inventoryManager.acquireItem(item, null);
                }
                break;
            case 0x4:   // Currency Items
                if (PragmataData.currencyItemDict.TryGetValue(itemId, out (uint currencyId, int amount) itemInfo)) {
                    ManagedObject obj = app.AcquisitionItemInfo.REFType.CreateInstance(1);
                    obj.Call(".ctor(System.UInt32, System.Int32)", [itemInfo.currencyId, itemInfo.amount]);
                    app.AcquisitionItemInfo item = obj.As<app.AcquisitionItemInfo>();

                    inventoryManager.acquireItem(item, null);
                }
                break;
        }
    }

    public static bool WithinBoundary(via.vec3 player, Vector3 container, float boundary) {
        Vector3 position = new Vector3(player.x, player.y, player.z);
        float distance = Vector3.Distance(position, container);

        if (distance <= boundary)
            return true;
        else
            return false;
    }

    [PluginExitPoint]
    public static void OnUnload() {
        if (Client.isConnected)
            Client.Disconnect().Wait();

        ImGui.End();
        API.LogInfo("C# plugin unloaded.");
    }
}
