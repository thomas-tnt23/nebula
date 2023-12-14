﻿#region

using System;
using NebulaAPI.GameState;
using NebulaModel.DataStructures;

#endregion

namespace NebulaWorld;

public class LocalPlayer : ILocalPlayer
{
    public void Dispose()
    {
        Data = null;
        GC.SuppressFinalize(this);
    }

    public bool IsInitialDataReceived { get; private set; }
    public bool IsHost { get; set; }
    public bool IsClient => !IsHost;
    public bool IsNewPlayer { get; private set; }
    public ushort Id => Data.PlayerId;
    public IPlayerData Data { get; private set; }

    public void SetPlayerData(PlayerData data, bool isNewPlayer)
    {
        Data = data;
        IsNewPlayer = isNewPlayer;

        if (IsInitialDataReceived)
        {
            return;
        }
        IsInitialDataReceived = true;

        if (Multiplayer.Session.IsGameLoaded)
        {
            Multiplayer.Session.World.SetupInitialPlayerState();
        }
    }
}
