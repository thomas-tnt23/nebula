﻿namespace NebulaModel.Packets.Logistics;

// This packet is only used to tell clients about AddItem() and TakeItem() calls in InternalTickRemote() of host
// there are other places where items are added/taken from storage in that method but they have their own packet
// there is alos a different packet for updates regarding remoteOrder as it only needs to be sent to the planets where the corresponding two ILS are.
public class ILSShipAddTake
{
    public ILSShipAddTake() { }

    public ILSShipAddTake(bool addItem, int itemId, int itemCount, int stationGID, int inc)
    {
        AddItem = addItem;
        ItemId = itemId;
        ItemCount = itemCount;
        StationGID = stationGID;
        Inc = inc;
    }

    public bool AddItem { get; }
    public int ItemId { get; }
    public int ItemCount { get; }
    public int StationGID { get; }
    public int Inc { get; } // if TakeItem() is called this holds the workShipDatas index needed to update the ShipData
}
