﻿using NebulaModel.Attributes;
using NebulaModel.Networking;
using NebulaModel.Packets.Universe;
using NebulaModel.Logger;
using NebulaModel.Packets.Processors;
using NebulaWorld.Universe;
using System.Collections.Generic;

namespace NebulaHost.PacketProcessors.Universe
{
    [RegisterPacketProcessor]
    class DysonSphereAddShellProcessor : IPacketProcessor<DysonSphereAddShellPacket>
    {
        private PlayerManager playerManager;

        public DysonSphereAddShellProcessor()
        {
            playerManager = MultiplayerHostSession.Instance.PlayerManager;
        }

        public void ProcessPacket(DysonSphereAddShellPacket packet, NebulaConnection conn)
        {
            Log.Info($"Processing DysonSphere Add Shell notification for system {GameMain.data.galaxy.stars[packet.StarIndex].name} (Index: {GameMain.data.galaxy.stars[packet.StarIndex].index})");
            Player player = playerManager.GetPlayer(conn);
            if (player != null)
            {
                playerManager.SendPacketToOtherPlayers(packet, player);
                DysonSphere_Manager.IncomingDysonSpherePacket = true;
                GameMain.data.dysonSpheres[packet.StarIndex]?.GetLayer(packet.LayerId)?.NewDysonShell(packet.ProtoId, new List<int>(packet.NodeIds));
                DysonSphere_Manager.IncomingDysonSpherePacket = false;
            }
        }
    }
}
