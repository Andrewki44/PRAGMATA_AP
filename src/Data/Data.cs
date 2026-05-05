using System.Collections.Generic;
using System.Numerics;

namespace PRAGMATA.Data;

public static class PragmataItemData {
    public enum PragmataItemType : uint {
        Mission     = 0x0000,
        Weapon      = 0x1000,
        Key         = 0x2000,
        REM         = 0x3000,
        Currency    = 0x4000,
        Mod         = 0x7000,
        Training    = 0x8000,
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

    public static Dictionary<uint, uint> modItemDict = new () {
        { 0x00, 0x3979013A }, // Mod: Hardened Suit
        { 0x00, 0xF7CAA487 }, // Mod: Pocket Refinery
        { 0x00, 0xCBF71C23 }, // Mod: Extended Breach
        { 0x00, 0xDE963637 }, // Mod: Close Quarters
        { 0x00, 0x8BEBC582 }, // Mod: Long Range Targeting
        { 0x00, 0x495293E3 }, // Mod: Relay Amplifier
        { 0x00, 0xC27B883 }, // Mod: Overclocked Weaponry
        { 0x00, 0xBB3CC922 }, // Mod: Self-defense Response
        { 0x00, 0xF63FE051 }, // Mod: Skirmisher
        { 0x00, 0x7388AB72 }, // Mod: Collateral Damage
        { 0x00, 0x9D6DFFE }, // Mod: Recursive Learning
        { 0x00, 0x23DC590 }, // Mod: Aggressive Defense
        { 0x00, 0xF6CE2C05 }, // Mod: Cheap Shot
        { 0x00, 0x65A0D00A }, // Mod: Precision Shot
        { 0x00, 0xE450E7D5 }, // Mod: Quick Fix
        { 0x00, 0x6EEA1FC1 }, // Mod: Hyperfocus
        { 0x00, 0x405697AF }, // Mod: Optimal Performance
        { 0x00, 0xDC35BA23 }, // Mod: Performance Boost
        { 0x00, 0x8C944FFD }, // Mod: Equilibrium
        { 0x00, 0xBD3D357C }, // Mod: Analog Aggression
        { 0x00, 0x68F7421B }, // Mod: Digital Dominance
        { 0x00, 0x713FE1D }, // Mod: Nice Nodes
        { 0x00, 0xE5E8C82A }, // Mod: Eagle Eye
        { 0x00, 0x2BB4317B }, // Mod: Synaptic Response
        { 0x00, 0x4411B07A }, // Mod: Economize
        { 0x00, 0x7517A14E }, // Mod: Last Resort
        { 0x00, 0xEBE40903 }, // Mod: Reinforced Casing
        { 0x00, 0xD40D143 }, // Mod: Untapped Potential
        { 0x00, 0xE60A8987 }, // Mod: Heat Transfer
        { 0x00, 0x644A5E44 }, // Mod: Cursed
        { 0x00, 0x789D82BB }, // Mod: Adrenaline Flood
        { 0x00, 0x9928BD26 }, // Mod: Faster Moves
        { 0x00, 0x5D4ED0D8 }, // Mod: Target Weakness
        { 0x00, 0x5E4DDC34 }, // Mod: Critical Response
        { 0x00, 0x5EB25515 }, // Mod: Sympathetic Hacking
        { 0x00, 0x743DA901 }, // Mod: Better Lucky
        { 0x00, 0x7E3CAB0B }, // Mod: Cyber Thief
        { 0x00, 0xFF347F40 }, // Mod: Grace
        { 0x00, 0x8044F0B9 }, // Mod: Slowdown
        { 0x00, 0x8AF68C96 }, // Mod: Black Box
    };

    public static Dictionary<uint, uint> upgradeItemDict = new () {
        { 0x00, 0xEADCDE72 },
        { 0x01, 0x73216782 }
    };
}

public static class PragmataLocationData {
    public enum PragmataLocationType : uint {
        TreasureBox     = 0x1000,
        Component       = 0x2000,
    }

    public static Dictionary<Vector3, long> treasureBoxLocationDict = new Dictionary<Vector3, long>() {
        { new(28.24f, -10.28f, 101.97f) ,  0 },    // SPP:  Sealed Sector Gate - Behind laser grid with a walker (Safe Box)
        { new(-18.69f, -15.63f, 118.16f),  1 },    // SPP:  Sealed Sector Gate - Black ground with moving platforms (Safe Box)
        { new(-5.57f, -11.46f, 68.98f)  ,  2 },    // SPP:  Sealed Sector Gate - Behind Filament Mass (Safe Box)
        { new(-5.57f, -11.46f, 72.58f)  ,  3 },    // SPP:  Sealed Sector Gate - Behind Filament Mass (Pure Lunum)
        { new(61.98f, -19.77f, 96.63f)  ,  4 },    // SPP:  Main Control Lobby - Next to shelter checkpoint (Mod: Hardened Suit)
        { new(151.02f, -11.81f, 9.19f)  ,  5 },    // MPA:  Test Site Platform - Restaurant Filament Mass (Safe Box)
        { new(164.35f, -11.73f, 63.43f) ,  6 },    // MPA:  Test Site Platform - Nouvelle Filament Mass (Safe Box)
        { new(174.02f, -7.94f, 108.59f) ,  7 },    // MPA:  Shopping District - Entrance - Red Zone (Pure Lunum)
        { new(147.03f, 3.94f, 78.09f)   ,  8 },    // MPA:  Shopping District - Entrance - Moving laser grids, opposite mannequins (Mod: Extended Breach)
        { new(153.06f, 30.39f, 75.49f)  ,  9 },    // MPA:  Shopping District - Entrance - Behind 3 walkers, 1st multihack drop (Safe Box)
        { new(171.73f, 0.08f, 134.08f)  , 10 },    // MPA:  Shopping District - Entrance - Door behind Beacon2 (Safe Box)
        { new(169.34f, 0.08f, 134.05f)  , 11 },    // MPA:  Shopping District - Entrance - Door behind Beacon2 (Pure Lunum)
        { new(154.4f, 9.02f, 124.78f)   , 12 },    // MPA:  Shopping District - Entrance - Holo Wall (Safe Box)
        { new(196.8f, 6.04f, 116.08f)   , 13 },    // MPA:  Shopping District - Entrance - Behind laser wall next to mannequins + walker (Safe Box)
        { new(162.92f, 5.98f, 74.02f)   , 14 },    // MPA:  Shopping District - Entrance - Before Bridge (Mod: Close Quaters)
        { new(175.37f, 6f, 79.09f)      , 15 },    // MPA:  Shopping District - Entrance - Filament Mass near Beacon2 (Safe Box)
        { new(182.53f, -4.2f, 1.65f)    , 16 },    // MPA:  Interconnecting Passage - Above 1st door, 1st Executor Enemy (Mod: Relay Amplfier)
        { new(171.04f, -11.87f, -34.96f), 17 },    // MPA:  Interconnecting Passage - Below Beacon3 (Mod: Long Range Targeting)
        { new(176.55f, 20.43f, -59.31f) , 18 },    // MPA:  Interconnecting Passage - Halfway up zipline after Beacon3 (Safe Box)
        { new(141.98f, 18f, -5.64f)     , 19 },    // MPA:  Office Space - Next to Shelter Checkpoint (Pure Lunum)
        { new(106.18f, -11.93f, -40.1f) , 20 },    // MPA:  Office Space - Red Zone (Pure Lunum)
        { new(103.25f, -11.93f, -40.3f) , 21 },    // MPA:  Office Space - Red Zone (Mod: Pocket Refinery)
        { new(122.35f, -11.97f, -9.29f) , 22 },    // MPA:  Office Space - Left of Red Zone (Safe Box)
        { new(141.92f, -11.8f, -7.85f)  , 23 },    // MPA:  Office Space - Area under Shelter Checkpoint (Safe Box)
        { new(110.98f, 17.74f, 10.82f)  , 24 },    // MPA:  Office Space - Left of upper Filament Mass (Safe Box)
        { new(82.17f, 17.76f, -8.25f)   , 25 },    // MPA:  Office Space - Upper Filament Mass (Safe Box)
        { new(122.95f, 8.07f, -74.63f)  , 26 },    // MPA:  Office Space - Dead Filament Mass right of Red Zone (Safe Box)
        { new(125.01f, 8.07f, -74.63f)  , 27 },    // MPA:  Office Space - Dead Filament Mass right of Red Zone (Safe Box)
        { new(78.95f, 2.05f, 57.52f)    , 28 },    // MPA:  Recycling Control - Holo Wall before spinning laser room (Safe Box)
        { new(74.64f, -4.9f, 90.57f)    , 29 },    // MPA:  Recycling Control - Above Lim Eraser with 4 walkers (Safe Box)
        { new(75.25f, -10.28f, 71.17f)  , 30 },    // MPA:  Recycling Control - Behind laser wall (Safe Box)
    };

    public static Dictionary<Vector3, long> componentLocationDict = new Dictionary<Vector3, long>() {
        { new(-8.01f, 0.1f, -4.03f)     ,  0 },    // SPP: Power Plant Platform - Left of spawn (Upgrade Material)
        { new(13.5f, 1.15f, 38.25f)     ,  1 },    // SPP: Power Plant Platform - Opposite Lock 1 (Upgrade Material)
        { new(3.97f, -6.36f, 107.9f)    ,  2 },    // SPP: Sealed Sector Gate - Middle of laser grid opposite main locked door (Upgrade Material)
        { new(-14.9f, 3.54f, 97.61f)    ,  3 },    // SPP: Sealed Sector Gate - On roof above shelter checkpoint (Upgrade Material)
        { new(-27.19f, -4.42f, 95.01f)  ,  4 },    // SPP: Sealed Sector Gate - Behind a locked door opposite shelter checkpoint (Upgrade Material)
        { new(38.82f, 2.86f, 95.96f)    ,  5 },    // SPP: Sealed Sector Gate - Next to Mini Cabin near Filament Mass (Upgrade Material)
        { new(7.73f, 3.4f, 114.79f)     ,  6 },    // SPP: Sealed Sector Gate - Above hack above the main locked door (Upgrade Material)
        { new(9.56f, -9.88f, 129.59f)   ,  7 },    // SPP: Sealed Sector Gate - Near moving platform with 2 Watchers and 1 Crusher (Upgrade Material)
        { new(35.23f, -4.32f, 107.97f)  ,  8 },    // SPP: Sealed Sector Gate - Directly behind main locked door (Upgrade Material)
        { new(10.05f, 0.14f, 59.34f)    ,  9 },    // SPP: Sealed Sector Gate - Behind Filament Mass, right of entrance to room (Upgrade Material)
        { new(55.9f, -19.68f, 108.92f)  , 10 },    // SPP: Main Control Lobby - Behind door, right of shelter checkpoint (Upgrade Material)
        { new(36.69f, 1.35f, 2.7f)      , 11 },    // SPP: Main Control Lobby - Up zipline (Upgrade Material)
        { new(-26.12f, -8.33f, 151.83f) , 12 },    // MPA: Test Site Platform - Right of spawn (Upgrade Material)
        { new(16.59f, 0.17f, 43.94f)    , 13 },    // MPA: Test Site Platform - Back corner behind Spider (Upgrade Material)
        { new(29.13f, 0.54f, 47.06f)    , 14 },    // MPA: Test Site Platform - Through door walker comes out of (Upgrade Material)
        { new(96.52f, -11.83f, 48.39f)  , 15 },    // MPA: Test Site Platform - Back right corner of main area, under sideways bus (Upgrade Material)
        { new(120.1f, -11.7f, -2.51f)   , 16 },    // MPA: Test Site Platform - Alley next to Yolo Boutique (Upgrade Material)
        { new(208.13f, -7.33f, 59.89f)  , 17 },    // MPA: Test Site Platform - Above-right of main locked gate (Upgrade Material)
        { new(135.35f, -6.86f, 10.7f)   , 18 },    // MPA: Test Site Platform - Filament Mass above Yolo Boutique (Upgrade Material)
        { new(176f, -2.05f, 69.98f)     , 19 },    // MPA: Shopping District - Entrance - Above Stardust shop, moving platform (Upgrade Material)
        { new(160.3f, 2.89f, 103.58f)   , 20 },    // MPA: Shopping District - Entrance - Opposite Mannequins (Upgrade Material)
        { new(147.98f, 21.09f, 78.29f)  , 21 },    // MPA: Shopping District - Entrance - Drop left before drop to Beacon 2 (Upgrade Material)
        { new(160.99f, 2.04f, 78.46f)   , 22 },    // MPA: Shopping District - Entrance - Under Diana's Donuts billboard (Upgrade Material)
        { new(184.9f, 10.61f, 106.54f)  , 23 },    // MPA: Shopping District - Entrance - Above Spicy BBQ Burger (Upgrade Material)
        { new(204.64f, 6.1f, 112.85f)   , 24 },    // MPA: Shopping District - Entrance - Next to laser wall with a chest (Upgrade Material)
        { new(192.07f, 8.09f, -51.1f)   , 25 },    // MPA: Interconnecting Passage - Next to zipline after Beacon3 (Upgrade Material)
        { new(156.33f, 18.44f, -61.05f) , 26 },    // MPA: Interconnecting Passage - Before Beacon4 Arena (Upgrade Material)
        { new(150.94f, 18f, -17.98f)    , 27 },    // MPA: Office Space - Back-left of room with Shelter Checkpoint (Upgrade Material)
        { new(122.35f, -11.2f, -9.29f)  , 28 },    // MPA: Office Space - Left of Red Zone (From above chest) (Upgrade Material)
        { new(110.98f, 18.51f, 10.82f)  , 29 },    // MPA: Office Space - Left of upper Filament Mass (From above chest) (Upgrade Material)
        { new(119.75f, 8.8f, -69.46f)   , 30 },    // MPA: Office Space - Lower Filament Mass right of Red Zone (Upgrade Material)
        { new(118.03f, -5.83f, 84.37f)  , 31 },    // MPA: Recycling Control - Above sShelter Checkpoint (Upgrade Material)
        { new(62.21f, -17.06f, 46.59f)  , 32 },    // MPA: Recycling Control - Left of Lim Eraser upgrade (Upgrade Material)
        { new(137.81f, -23.99f, 77.55f) , 33 },    // MPA: Recycling Control - Right of Beacon6 (Upgrade Material)
    };
}

