public class StudentGroup
{
    private readonly List<Student> _students = new();

    public string GroupName { get; set; } = "";
    public string Speciality { get; set; } = "";
    public int Course { get; set; }

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
}
