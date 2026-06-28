public class StudentGroup
{
    private readonly List<Student> _students = new();

    public string GroupName { get; set; } = "";
    public string Speciality { get; set; } = "";
    public int Course { get; set; }
    public List<Student> Students { get; } = new();
    public PortMatrix Ports { get; } = new();
    public PortLogger Logger { get; } = new();

    public Student GetStudentByName(string name)
    {
        var student = Students.FirstOrDefault(s => s.Name == name);

        if (student == null)
            throw new ArgumentException($"Студента з ім'ям {name} не знайдено.");

        return student;
    }

    public void AssignStudentToPort(Student student, int row, int col)
    {
        student.AssignedPort = (row, col);
        Logger.LogOperation("ASSIGN", row * 16 + col, $"Студента {student.Name} призначено до порту [{row},{col}]");
    }

    public void WriteStudentData(Student student, byte[] data)
    {
        if (student.AssignedPort == null)
            throw new InvalidOperationException("Студент не має призначеного порту.");

        var (r, c) = student.AssignedPort.Value;

        Ports.WriteToPort(r, c, data);
        Logger.LogOperation("WRITE", r * 16 + c, $"Записано {data.Length} байт для студента {student.Name}");
    }

    public byte[] ReadStudentData(Student student)
    {
        if (student.AssignedPort == null)
            throw new InvalidOperationException("Студент не має призначеного порту.");

        var (r, c) = student.AssignedPort.Value;

        var data = Ports.ReadFromPort(r, c);
        Logger.LogOperation("READ", r * 16 + c, $"Прочитано дані для студента {student.Name}");

        return data;
    }

    public int GroupSize => _students.Count;
    public double AverageGroupGrade => _students.Count == 0
        ? 0
        : Math.Round(_students.Average(s => s.AverageGrade), 2);

    public void AddStudent(Student s) => _students.Add(s);

    public bool RemoveStudent(string recordBookNumber)
    {
        var s = _students.FirstOrDefault(x => x.RecordBookNumber == recordBookNumber);
        if (s is null) return false;
        _students.Remove(s);
        return true;
    }

    public Student? FindStudent(string fullName) =>
        _students.FirstOrDefault(s => s.FullName.Equals(fullName, StringComparison.OrdinalIgnoreCase));

    public Student? FindStudentByRecordBook(string recordBookNumber) =>
        _students.FirstOrDefault(s => s.RecordBookNumber == recordBookNumber);

    public IEnumerable<Student> GetExcellentStudents() =>
        _students.Where(s => s.IsExcellent());

    public IEnumerable<Student> GetStudentsByStatus(StudentStatus status) =>
        _students.Where(s => s.Status == status);

    public void SaveToFile(string path)
    {
        var json = System.Text.Json.JsonSerializer.Serialize(_students);
        File.WriteAllText(path, json);
    }

    public void LoadFromFile(string path)
    {
        if (!File.Exists(path)) return;
        var json = File.ReadAllText(path);
        var loaded = System.Text.Json.JsonSerializer.Deserialize<List<Student>>(json);
        if (loaded is not null)
        {
            _students.Clear();
            _students.AddRange(loaded);
        }
    }

    public IEnumerable<Student> GetAllStudents() => _students;

    public Student GetStudentByName(string name)
    {
        var student = Students.FirstOrDefault(s => s.Name == name);

        if (student == null)
            throw new ArgumentException($"Студента з ім'ям {name} не знайдено.");

        return student;
    }

    public void SortByAverageGrade()
    {
        Students.Sort((a, b) => a.GetAverageLabGrade().CompareTo(b.GetAverageLabGrade()));
    }


}
