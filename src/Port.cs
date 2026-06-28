public class Port
{
    public int PortNumber { get; }
    public byte[] DataBuffer { get; } = new byte[64];
    public bool IsOpen { get; private set; }
    public string DeviceName { get; }

    public Port(int portNumber, string deviceName)
    {
        PortNumber = portNumber;
        DeviceName = deviceName;
        IsOpen = false;
    }

    public void Open()
    {
        IsOpen = true;
    }

    public void Close()
    {
        IsOpen = false;
    }

    public void Write(byte[] data)
    {
        if (!IsOpen)
            throw new InvalidOperationException("Порт закритий, запис неможливий.");

        if (data.Length > DataBuffer.Length)
            throw new ArgumentException("Дані перевищують розмір буфера.");

        Array.Clear(DataBuffer, 0, DataBuffer.Length);
        Array.Copy(data, DataBuffer, data.Length);
    }

    public byte[] Read()
    {
        if (!IsOpen)
            throw new InvalidOperationException("Порт закритий, читання неможливе.");

        return DataBuffer;
    }
}
