﻿using System.Collections.Generic;
using Maple2.Model.Error;
using Maple2.Model.Game;
using Maple2.PacketLib.Tools;
using Maple2.Server.Core.Constants;
using Maple2.Server.Core.Packets;

namespace Maple2.Server.Game.Packets;

public static class UserEnvPacket {
    private enum Command : byte {
        AddTitle = 0,
        UpdateTitles = 1,
        LoadTitles = 2,
        LifeSkillCount = 8,
    }

    public static ByteWriter AddTitle(int titleId) {
        var pWriter = Packet.Of(SendOp.UserEnv);
        pWriter.Write<Command>(Command.AddTitle);
        pWriter.WriteInt(titleId);
        return pWriter;
    }

    public static ByteWriter UpdateTitle(int objectId, int titleId) {
        var pWriter = Packet.Of(SendOp.UserEnv);
        pWriter.Write<Command>(Command.UpdateTitles);
        pWriter.WriteInt(objectId);
        pWriter.WriteInt(titleId);
        return pWriter;
    }

    public static ByteWriter LoadTitles(ISet<int> titles) {
        var pWriter = Packet.Of(SendOp.UserEnv);
        pWriter.Write<Command>(Command.LoadTitles);
        pWriter.WriteInt(titles.Count);
        foreach (int title in titles) {
            pWriter.WriteInt(title);
        }

        return pWriter;
    }
}