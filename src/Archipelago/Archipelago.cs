using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.MessageLog.Messages;
using Archipelago.MultiClient.Net.MessageLog.Parts;
using Archipelago.MultiClient.Net.Models;
using Archipelago.MultiClient.Net.Packets;
using REFrameworkNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PRAGMATA_AP;

public static partial class Archipelago {
    public  static Lock                clientLock = new();
    public  static ArchipelagoSession? currentSession;
    public  static string?             currentServer;
    public  static bool                local_locations_updated = false;
    public  static bool                remote_locations_updated = false;
    public  static string?             seedID = null;
    private static bool                _isDisconnecting = false;

    public static PlayerInfo? activePlayer => currentSession?.Players.ActivePlayer;
    public static bool isConnected => currentSession != null;

    public static async Task Connect(string server, string user, string password) {
        API.LogInfo($"~~ AP Connect ~~");
        LoginResult loginResult;
        ArchipelagoSession? session = null;
        if (_isDisconnecting) return;

        // Create new session and connect asynchronously
        try {
            session = ArchipelagoSessionFactory.CreateSession(server);
            connectHandlers(session);
            RoomInfoPacket infoPacket = await session.ConnectAsync();

            loginResult = await session.LoginAsync("Pragmata", user, ItemsHandlingFlags.RemoteItems, Version.Parse("0.6.0"), password: password, requestSlotData: true);
        } catch (Exception e) {
            loginResult = new LoginFailure(e.GetBaseException().Message);
        }

        // If connection succeeded
        if (loginResult.Successful) {
            LoginSuccessful loginSuccess = (LoginSuccessful)loginResult;
            //seedID = loginSuccess.SlotData["SeedID"].ToString();
            currentServer = server;
            currentSession = session;
            API.LogInfo($"~~ Successfully connected to {server} as {user}");
            return;
        } else {    // Connection failed
            LoginFailure loginFail = (LoginFailure)loginResult;
            string errorMessage = $"~~ Failed to connect to {server} as {user}:";

            foreach (string error in loginFail.Errors)
                errorMessage += $"\n    {error}";

            foreach (ConnectionRefusedError error in loginFail.ErrorCodes)
                errorMessage += $"\n    {error}";

            currentSession = null;
            API.LogError(errorMessage);
            return;
        }
    }

    public static async Task Disconnect(ArchipelagoSession? session = null) {
        session ??= currentSession;
        if (session is null || _isDisconnecting)
            return;

        _isDisconnecting = true;
        await session.Socket.DisconnectAsync();
        API.LogWarning("~~ AP Disconnected ~~");
        //}
    }

    private static void connectHandlers(ArchipelagoSession session) {
#if DEBUG
        API.LogInfo("~~ Connect Handlers ~~");
#endif
        session.MessageLog.OnMessageReceived += MessageLog_OnMessageReceived;
        session.Socket.ErrorReceived += Socket_ErrorReceived;
        session.Socket.SocketOpened += Socket_SocketOpened;
        session.Socket.SocketClosed += Socket_SocketClosed;
        session.Locations.CheckedLocationsUpdated += Locations_CheckedLocationsUpdated;
    }

    private static void Locations_CheckedLocationsUpdated(System.Collections.ObjectModel.ReadOnlyCollection<long> newCheckedLocations) {
        lock (clientLock) {
            remote_locations_updated = true;
        }
    }

    private static void Socket_ErrorReceived(Exception e, string message) {
        API.LogError($"~~ Socket Error: {message} ~~");
        API.LogError($"~~ Socket Exception: {e.Message} ~~");

        if (e.StackTrace != null)
            foreach (var line in e.StackTrace.Split('\n'))
                API.LogError($"    {line}");
        else
            API.LogError($"    No Stacktrace Provided");

        Socket_SocketClosed("");
    }

    private static void Socket_SocketOpened() {
#if DEBUG
        API.LogInfo($"Socket Opened: \"{currentSession?.Socket.Uri}\"");
#endif
    }

    private static void Socket_SocketClosed(string reason) {
#if DEBUG
        API.LogWarning($"Socket Closed: \"{reason}\"");
#endif
        Console.AddLogMessage([($"Disconnected from server ({reason})", Color.Red)]);
        lock (clientLock) {
            currentSession = null;
            seedID = null;
            currentServer = null;
            _isDisconnecting = false;
        }
    }

    private static void MessageLog_OnMessageReceived(LogMessage message) {
        MessagePart[] parts = message.Parts;
        List<(string, Color)> messageParts = parts.Select((part) => {
            Color color = part.Color;
            if (part.IsBackgroundColor) {
                color = Color.White;
            }
            else if (part.Color == Color.Black) {
                color = new(128, 128, 128);
            }
            return (part.Text, color);
        }).ToList();
        Console.AddLogMessage(messageParts);
    }

    private static void SayAsync(string message) {
        lock (clientLock) {
            if (isConnected) {
                currentSession!.Socket.SendPacketAsync(new SayPacket { Text = message });
            }
        }
    }
}

