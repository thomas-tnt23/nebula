﻿#region

using NebulaAPI.Packets;
using NebulaModel.Networking;
using NebulaModel.Packets;
using NebulaModel.Packets.GameHistory;
using NebulaModel.Packets.Session;
using NebulaModel.Packets.Statistics;
using NebulaModel.Packets.Trash;

#endregion

namespace NebulaNetwork.PacketProcessors.Session;

[RegisterPacketProcessor]
internal class GlobalGameDataRequestProcessor : PacketProcessor<GlobalGameDataRequest>
{
    protected override void ProcessPacket(GlobalGameDataRequest packet, NebulaConnection conn)
    {
        if (IsClient)
        {
            return;
        }

        //Export GameHistoryData, TrashSystem, MilestoneSystem
        //PlanetFactory, Dysonsphere, GalacticTransport will be handle else where

        using (var writer = new BinaryUtils.Writer())
        {
            GameMain.history.Export(writer.BinaryWriter);
            conn.SendPacket(new GameHistoryDataResponse(writer.CloseAndGetBytes(), GameMain.sandboxToolsEnabled));
        }

        using (var writer = new BinaryUtils.Writer())
        {
            GameMain.data.trashSystem.Export(writer.BinaryWriter);
            conn.SendPacket(new TrashSystemResponseDataPacket(writer.CloseAndGetBytes()));
        }

        using (var writer = new BinaryUtils.Writer())
        {
            GameMain.data.milestoneSystem.Export(writer.BinaryWriter);
            conn.SendPacket(new MilestoneDataResponse(writer.CloseAndGetBytes()));
        }
    }
}
