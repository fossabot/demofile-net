﻿namespace DemoFile.Sdk;

public partial class CEntityInstance
{
    private readonly SendNodeDecoder<object> _decoder;

    internal CEntityInstance(EntityContext context, SendNodeDecoder<object> decoder)
    {
        _decoder = decoder;
        EntityIndex = context.EntityIndex;
        ServerClass = context.ServerClass;
        SerialNumber = context.SerialNumber;
        Demo = context.Demo;
    }

    protected DemoParser Demo { get; }

    public CEntityIndex EntityIndex { get; }

    /// <summary>
    /// Is this entity within the recording player's PVS?
    /// For GOTV demos, this is always <c>true</c>
    /// </summary>
    public bool IsActive { get; internal set; }

    public ServerClass ServerClass { get; }
    public uint SerialNumber { get; }

    internal void ReadField(ReadOnlySpan<int> fieldPath, ref BitBuffer buffer)
    {
        _decoder(this, fieldPath, ref buffer);
    }
}
