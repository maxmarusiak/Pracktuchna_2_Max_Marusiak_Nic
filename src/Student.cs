public enum StudentStatus
{
    Active,
    AcademicLeave,
    Expelled,
    Graduated
}

public class Student
{
    // Приватні поля
    private string _fullName;
    private DateTime _dateOfBirth;
    private string _recordBookNumber;
    private double _averageGrade;
    private string _personalEmail;
    public byte[] LabGrades { get; } = new byte[10];

    // Required / init-only / read-only
    public required string FullName
    {
        get => _fullName;
        init
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                throw new ArgumentException("FullName is invalid");
            _fullName = value;
        }
    }

    public DateTime DateOfBirth
    {
        get => _dateOfBirth;
        init => _dateOfBirth = value;
    }

    public int Age => CalculateAge();

    public string RecordBookNumber
    {
        get => _recordBookNumber;
        set
        {
            if (value?.Length != 8 || !value.All(char.IsDigit))
                throw new ArgumentException("RecordBookNumber must be 8 digits");
            _recordBookNumber = value;
        }
    }

    public double AverageGrade
    {
        get => _averageGrade;
        private set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException(nameof(AverageGrade));
            _averageGrade = Math.Round(value, 2);
        }
    }

    public StudentStatus Status { get; set; }
    public DateTime EnrollmentDate { get; init; }
    public string PersonalEmail
    {
        get => _personalEmail;
        set
        {
            // мінімальна валідація
            if (string.IsNullOrWhiteSpace(value) || !value.Contains("@"))
                throw new ArgumentException("Invalid email");
            _personalEmail = value;
        }
    }

    public string? Notes { get; set; }

    // Методи
    public void ShowDetailedInfo() { /* Console.WriteLine(...) */ }

    public void UpdateAverageGrade(double newGrade) => AverageGrade = newGrade;

    public bool IsExcellent() => AverageGrade >= 90;
    public bool IsFailing() => AverageGrade < 60;

    public int CalculateAge()
    {
        var today = DateTime.Today;
        var age = today.Year - DateOfBirth.Year;
        if (DateOfBirth.Date > today.AddYears(-age)) age--;
        return age;
    }

    public int GetYearsToGraduation()
    {
        // Наприклад: 4 роки навчання
        return Math.Max(0, 4 - (DateTime.Today.Year - EnrollmentDate.Year));
    }

    public void AddLabGrade(int labNumber, byte grade)
    {
        LabGrades[labNumber] = grade;
    }

    public double GetAverageLabGrade()
    {
        return LabGrades.Average();
    }


}
