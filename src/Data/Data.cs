using System.Collections.Generic;

namespace PRAGMATA.Data;

public static class PragmataItemData {
    public enum PragmataLocationType : uint {
        Weapon      = 0x0000,
        REM         = 0x3000,
        Currency    = 0x4000,
        Training    = 0x8000,
        Mod         = 0x8000,
        Upgrade     = 0xA000,
    }

    public static Dictionary<uint, uint> weaponItemDict = new () {
        { 0x00, 0x2E3AE9C9 }, // Grip Gun
        { 0x01, 0x3D4FA54D }, // Pulse Carbine
        { 0x02, 0xDC5DAD61 }, // Shockwave Gun
        { 0x03, 0x3349AF65 }, // Charge Piercer
        { 0x04, 0xD76231B2 }, // Photon Laser
        { 0x05, 0xC5E661A2 }, // Homing Missiles
        { 0x06, 0x1D7A1B11 }, // Jackhammer
        { 0x07, 0x4205FC43 }, // Lim Cannon
        { 0x08, 0xCF0E0C2A }, // Stasis Net
        { 0x09, 0x9C3783F5 }, // Riot Blaster
        { 0x0A, 0x9B04EB5C }, // Sticky Bombs
        { 0x0B, 0xBDBDEDC7 }, // Code Generator
        { 0x0C, 0xFF2C68E6 }, // Hacking Mines
        { 0x0D, 0x59AC9726 }, // Decoy Generator
        { 0x0E, 0x9CB872C2 }, // Impact Barrier
        { 0x0F, 0x2A898B55 }, // Drone Hive
    };

    public static Dictionary<uint, uint> remItemDict = new () {
        { 0x00, 0x566662D0 }, // Globe
        { 0x01, 0xA1EB20D9 }, // Crayons
        { 0x02, 0x00       }, // CRT TV
        { 0x03, 0xB7D37CBE }, // Slide
        { 0x04, 0x753111BD }, // Balloons
        { 0x05, 0x5EDADED9 }, // Basketball
        { 0x06, 0x39E3058  }, // RC Car
        { 0x07, 0x42F431EE }, // Skateboard
        { 0x08, 0x74559B70 }, // Flowers
        { 0x09, 0x209419B0 }, // Swing
        { 0x0A, 0xECACA4B6 }, // Campfire
        { 0x0B, 0xCD142FA6 }, // Bug Net
        { 0x0C, 0xA7EC621D }, // Tent
        { 0x0D, 0x3C33AE96 }, // Parasol
        { 0x0E, 0x625CB4A9 }, // Water Gun
        { 0x0F, 0xBAF964A3 }, // Sandcastle
    };

    public static Dictionary<uint, (uint, int)> currencyItemDict = new () {
        { 0x00, (0x84C2F1F3, 100) }, // Lunafilament
        { 0x01, (0xB30CA95,    2) }, // Upgrade Component
        { 0x02, (0x7D9B1F63,   1) }, // Pure Lunum
        { 0x03, (0x29C9936B,   1) }, // Cabin Coins
    };

    public static Dictionary<uint, uint> trainingDataItemDict = new () {
        { 0x00, 0x73C10E3A }, // Terra Dome Entrance
        { 0x01, 0xB837B6D5 }, // Soil Research
        { 0x02, 0x21467467 }, // Warehouse
        { 0x03, 0xB4FC23E3 }, // Nexus Tower
        { 0x04, 0x7086454E }, // Research Sector
        { 0x05, 0xDF53740D }, // Lunafilament Lab
    };

    public static Dictionary<uint, uint> upgradeItemDict = new () {
        { 0x00, 0xEADCDE72 },
        { 0x01, 0x73216782 }
    };
}

public static class PragmataLocationData {
    public const uint modOffset = 0x8000;
    public enum PragmataLocationType : uint {
        Mod = 0x8000,
    }

    public static Dictionary<uint, (long, string)> modLocationDict = new Dictionary<uint, (long, string)>() {
        { 0x3979013A, (0, "Mod: Hardened Suit") },
    };
}
