using Hexa.NET.ImGui;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;
using Color = Archipelago.MultiClient.Net.Models.Color;

namespace PRAGMATA_AP;

public static partial class Archipelago {
    public static class Console {
        private const  ImGuiKey _consoleKey = ImGuiKey.F8;
        private static bool     _enabled    = false;

#if DEBUG
        private const  string _defaultClientAddress = "localhost:38281";
#else
        private const  string _defaultClientAddress = "archipelago.gg:";
#endif

        private static string clientAddress         = _defaultClientAddress;
        private static string clientName            = "";
        private static string clientPassword        = "";

        private static readonly Lock                          clientLogLock = new();
        private static List<List<(string text, Color color)>> clientLog = [];
        private static bool                                   clientLogUpdated = false;

        private static string                        clientInput = "";
        private static LinkedList<string>            clientInputHistory = new();
        private static LinkedListNode<string>?       clientInputHistoryCurrent = null;
        private static unsafe ImGuiInputTextCallback clientInputImGuiInputTextCallback = ClientInputImGuiInputTextCallback;
        private static bool                          focusClientInput = false;

        private static int fontSize = -1;

        //[Callback(typeof(ImGuiRender), CallbackType.Pre)]
        public static void OnImGuiRender() {
            if (fontSize == -1)
                fontSize = (int)ImGui.GetFontSize();

            ImGui.PushFont(null, fontSize);
            //ImGui.SetNextWindowPos(ImGui.GetCenter(ImGui.GetMainViewport()), ImGuiCond.Appearing, new(0.5f, 0.5f));

            RenderConsole();

            ImGui.PopFont();
        }

        private static void RenderConsole() {
            _enabled ^= ImGui.IsKeyPressed(_consoleKey);
            if (!_enabled)
                return;

            ImGuiStylePtr style = ImGui.GetStyle();

            if (ImGui.Begin("Archipelago###Archipelago.Console")) {
                if (ImGui.BeginTabBar("TabBar###Archipelago.Console.TabBar")) {
                    if (ImGui.BeginTabItem("Main###Archipelago.Console.TabBar.Main")) {
                        RenderConnection();
                        RenderLog();

                        ImGui.EndTabItem();
                    }
                    ImGui.EndTabBar();
                }
            }

            ImGui.End();
        }

        private static void RenderConnection() {
            if (!isConnected) {
                ImGui.InputText("Address", ref clientAddress, 50);
                ImGui.InputText("Name", ref clientName, 50);
                ImGui.InputText("Password", ref clientPassword, 50);

                if (ImGui.Button("Connect")) {
                    //_ = Connect(clientAddress, clientName, clientPassword);
                    Connect(clientAddress, clientName, clientPassword).Wait();
                }
                if (ImGui.Button("Disconnect")) {
                    Disconnect().Wait();
                }
            } else {
                ImGui.Text($"Connected as {activePlayer?.Name}");
                if (ImGui.Button("Disconnect")) {
                    Disconnect().Wait();
                }
            }
        }

        private static void RenderLog() {
            ImGuiStylePtr style = ImGui.GetStyle();
            if (ImGui.BeginChild("Archipelago.Console.Log", new(0, ImGui.GetContentRegionAvail().Y - ImGui.GetTextLineHeight() - 3 * style.ItemSpacing.Y), ImGuiChildFlags.Borders, ImGuiWindowFlags.NoMove)) {
                //var curr_scroll = ImGui.GetScrollY() / previous_scroll_max;
                lock (clientLogLock) {
                    foreach (var line in clientLog) {
                        byte part_counter = 0;
                        int part_length = line.Count;
                        //ImGui.PushStyleVar(ImGuiStyleVar.ItemSpacing, new Vector2(0,style.ItemSpacing.Y));
                        //ImGui.PushTextWrapPos(ImGui.GetCursorPosX() + ImGui.GetWindowWidth() - style.WindowPadding.X);
                        var wrap_width = ImGui.GetContentRegionAvail().X;
                        var remaining_width = wrap_width;
                        foreach (var part in line) {
                            var color = new Vector4(part.color.R / 255f, part.color.G / 255f, part.color.B / 255f, 1.0f);
                            ImGui.PushStyleColor(ImGuiCol.Text, color);
                            foreach (var word in part.text.Split(" ")) {
                                var word_width = ImGui.CalcTextSize($"{word} ").X;
                                if (part_counter > 0 && word_width < remaining_width) {
                                    ImGui.SameLine();
                                    ImGui.TextUnformatted(word);
                                    remaining_width -= word_width;
                                } else {
                                    ImGui.TextUnformatted(word);
                                    remaining_width = wrap_width - word_width;
                                }
                                part_counter++;
                            }
                            ImGui.PopStyleColor();
                            //ImGui.TextWrapped(line);
                        }
                        //ImGui.PopTextWrapPos();
                        //ImGui.PopStyleVar();
                    }
                }
                if (clientLogUpdated) {
                    ImGui.SetScrollHereY();
                    clientLogUpdated = false;
                }
            }
            ImGui.EndChild();

            if (focusClientInput) {
                ImGui.SetKeyboardFocusHere();
                focusClientInput = false;
            }

            bool process_input = ImGui.InputText("Input", ref clientInput, 150,
                ImGuiInputTextFlags.EnterReturnsTrue | ImGuiInputTextFlags.CallbackHistory,
                clientInputImGuiInputTextCallback);

            if (process_input && clientInput.Length > 0) {
                clientInputHistory.AddFirst(clientInput);
                if (clientInputHistory.Count > 10) {
                    clientInputHistory.RemoveLast();
                }
                clientInputHistoryCurrent = null;

                focusClientInput = true;

                if (!clientInput.StartsWith("/")) {
                    // Say
                    SayAsync(clientInput);
                } else {
                    // Client command
                }
                clientInput = "";
            }
        }

        public static void AddLogMessage(List<(string, Color)> message) {
            lock (clientLogLock) {
                clientLog.Add(message);
                clientLogUpdated = true;
            }
        }

        private unsafe static int ClientInputImGuiInputTextCallback(ImGuiInputTextCallbackData* data) {
            if (data->EventFlag == ImGuiInputTextFlags.CallbackHistory) {
                if (data->EventKey == ImGuiKey.UpArrow) {
                    if (clientInputHistoryCurrent is null && clientInputHistory.First is not null) {
                        clientInputHistoryCurrent = clientInputHistory.First;
                        data->DeleteChars(0, data->BufTextLen);
                        data->InsertChars(0, clientInputHistoryCurrent.Value);
                    } else if (clientInputHistoryCurrent?.Next is not null) {
                        clientInputHistoryCurrent = clientInputHistoryCurrent.Next;
                        data->DeleteChars(0, data->BufTextLen);
                        data->InsertChars(0, clientInputHistoryCurrent.Value);
                    }
                } else if (data->EventKey == ImGuiKey.DownArrow) {

                    clientInputHistoryCurrent = clientInputHistoryCurrent?.Previous;
                    data->DeleteChars(0, data->BufTextLen);
                    if (clientInputHistoryCurrent is not null) {
                        data->InsertChars(0, clientInputHistoryCurrent.Value);
                    }
                }
            }
            return 0;
        }
    }
}
