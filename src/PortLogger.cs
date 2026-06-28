using System.Text;

public class PortLogger
{
    private readonly StringBuilder _sb = new();

    public void LogOperation(string operation, int portNumber, string details)
    {
        _sb.AppendLine($"{DateTime.Now}: [{operation}] Port {portNumber} — {details}");
    }

    public string GetFullLog()
    {
        return _sb.ToString();
    }

    public void SaveLogToFile(string path)
    {
        File.WriteAllText(path, _sb.ToString());
    }
}
