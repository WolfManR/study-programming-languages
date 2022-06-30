﻿namespace DataParser.Device;

public class ReadChunkArgs : EventArgs
{
    public ReadChunkArgs(byte[] chunk)
    {
        Chunk = chunk;
    }

    public byte[] Chunk { get; }
}