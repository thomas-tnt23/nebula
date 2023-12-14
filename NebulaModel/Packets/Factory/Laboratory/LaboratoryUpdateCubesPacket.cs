﻿namespace NebulaModel.Packets.Factory.Laboratory;

public class LaboratoryUpdateCubesPacket
{
    public LaboratoryUpdateCubesPacket() { }

    public LaboratoryUpdateCubesPacket(int itemCount, int itemInc, int index, int labIndex, int planetId)
    {
        ItemCount = itemCount;
        ItemInc = itemInc;
        Index = index;
        LabIndex = labIndex;
        PlanetId = planetId;
    }

    public int ItemCount { get; }
    public int ItemInc { get; }
    public int Index { get; }
    public int LabIndex { get; }
    public int PlanetId { get; }
}
