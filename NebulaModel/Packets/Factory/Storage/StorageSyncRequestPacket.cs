﻿namespace NebulaModel.Packets.Factory.Storage;

public class StorageSyncRequestPacket
{
    public StorageSyncRequestPacket() { }

    public StorageSyncRequestPacket(int planetId, int storageId)
    {
        PlanetId = planetId;
        StorageId = storageId;
    }

    public int PlanetId { get; }
    public int StorageId { get; }
}
