public class PortMatrix
{
    public Port[,] Matrix { get; } = new Port[16, 16];

    public PortMatrix()
    {
        for (int r = 0; r < 16; r++)
        {
            for (int c = 0; c < 16; c++)
            {
                int portNumber = r * 16 + c;
                Matrix[r, c] = new Port(portNumber, $"Device_{r}_{c}");
            }
        }
    }

    public void OpenPort(int row, int col)
    {
        Matrix[row, col].Open();
    }

    public void ClosePort(int row, int col)
    {
        Matrix[row, col].Close();
    }

    public void WriteToPort(int row, int col, byte[] data)
    {
        Matrix[row, col].Write(data);
    }

    public byte[] ReadFromPort(int row, int col)
    {
        return Matrix[row, col].Read();
    }

    public string ScanMatrix()
    {
        var sb = new StringBuilder();

        for (int r = 0; r < 16; r++)
        {
            for (int c = 0; c < 16; c++)
            {
                var port = Matrix[r, c];
                sb.Append($"{(port.IsOpen ? "[OPEN]" : "[CLOSED]")} ");
            }
            sb.AppendLine();
        }

        return sb.ToString();
    }
}
