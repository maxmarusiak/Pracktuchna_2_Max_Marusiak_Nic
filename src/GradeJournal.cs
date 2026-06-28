public class GradeJournal
{
    public Dictionary<string, double> SubjectGrades { get; } = new();

    public void SetGrade(string subject, double grade)
    {
        SubjectGrades[subject] = grade;
    }

    public double RecalculateAverage()
    {
        if (SubjectGrades.Count == 0) return 0;
        return Math.Round(SubjectGrades.Average(x => x.Value), 2);
    }
}
