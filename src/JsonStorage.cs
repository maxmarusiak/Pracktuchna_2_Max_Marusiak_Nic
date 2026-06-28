using System.Text.Json;

public static class JsonStorage
{
    public static void Save(StudentGroup group, string path)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        var dto = new GroupDto
        {
            Students = group.Students,
            Ports = ConvertPorts(group.Ports)
        };

        File.WriteAllText(path, JsonSerializer.Serialize(dto, options));
    }

    public static void Load(StudentGroup group, string path)
    {
        var json = File.ReadAllText(path);
        var dto = JsonSerializer.Deserialize<GroupDto>(json);

        group.Students.Clear();
        group.Students.AddRange(dto.Students);

        RestorePorts(group.Ports, dto.Ports);
    }

    private static PortDto[,] ConvertPorts(PortMatrix matrix)
    {
        var result = new PortDto[16, 16];

        for (int r = 0; r < 16; r++)
        {
            for (int c = 0; c < 16; c++)
            {
                var p = matrix.Matrix[r, c];
                result[r, c] = new PortDto
                {
                    PortNumber = p.PortNumber,
                    IsOpen = p.IsOpen,
                    Data = p.DataBuffer
                };
            }
        }

        return result;
    }

    private static void RestorePorts(PortMatrix matrix, PortDto[,] dto)
    {
        for (int r = 0; r < 16; r++)
        {
            for (int c = 0; c < 16; c++)
            {
                var p = matrix.Matrix[r, c];
                var d = dto[r, c];

                if (d.IsOpen)
                    p.Open();
                else
                    p.Close();

                p.Write(d.Data);
            }
        }
    }
}

public class GroupDto
{
    public List<Student> Students { get; set; }
    public PortDto[,] Ports { get; set; }
}

public class PortDto
{
    public int PortNumber { get; set; }
    public bool IsOpen { get; set; }
    public byte[] Data { get; set; }
}
