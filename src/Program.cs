static void Main()
{
    var group = new StudentGroup
    {
        GroupName = "ПЗ-21",
        Speciality = "Програмна інженерія",
        Course = 2
    };

    while (true)
    {
        Console.WriteLine("1. Додати студента");
        Console.WriteLine("2. Видалити студента");
        Console.WriteLine("3. Вивести всіх (по 10)");
        Console.WriteLine("4. Пошук студента");
        Console.WriteLine("5. Редагувати студента");
        Console.WriteLine("6. Відмінники / <60");
        Console.WriteLine("7. Статистика групи");
        Console.WriteLine("8. Зберегти / Завантажити");
        Console.WriteLine("9. Вийти");

        var choice = Console.ReadLine();
        // switch-case з викликом методів group
    }
}
