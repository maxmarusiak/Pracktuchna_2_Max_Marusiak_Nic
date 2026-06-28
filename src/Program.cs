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
        Console.WriteLine("\n=== МЕНЮ ПР№2 ===");
        Console.WriteLine("1. Додати студента");
        Console.WriteLine("2. Призначити студента до порту");
        Console.WriteLine("3. Відкрити порт");
        Console.WriteLine("4. Закрити порт");
        Console.WriteLine("5. Записати дані у порт");
        Console.WriteLine("6. Прочитати дані з порту");
        Console.WriteLine("7. Додати оцінку студенту");
        Console.WriteLine("8. Показати середній бал студента");
        Console.WriteLine("9. Сканувати матрицю портів");
        Console.WriteLine("10. Показати лог");
        Console.WriteLine("11. Зберегти лог у файл");
        Console.WriteLine("12. Вихід");
        Console.WriteLine("13. Зберегти систему в JSON");
        Console.WriteLine("14. Завантажити систему з JSON");

        Console.Write("Ваш вибір: ");
        var choice = Console.ReadLine();

        try
        {
            switch (choice)
            {
                case "1":
                    // логіка додавання студента
                    break;

                case "2":
                    // логіка призначення порту
                    break;

                case "3":
                    // open port
                    break;

                case "4":
                    // close port
                    break;

                case "5":
                    // write
                    break;

                case "6":
                    // read
                    break;

                case "7":
                    // add grade
                    break;

                case "8":
                    // average grade
                    break;

                case "9":
                    Console.WriteLine(group.Ports.ScanMatrix());
                    break;

                case "10":
                    Console.WriteLine(group.Logger.GetFullLog());
                    break;

                case "11":
                    group.Logger.SaveLogToFile("log.txt");
                    Console.WriteLine("Лог збережено.");
                    break;

                case "12":
                    return;

                case "13":
                    JsonStorage.Save(group, "system.json");
                    Console.WriteLine("Система збережена у system.json");
                    break;

                case "14":
                    JsonStorage.Load(group, "system.json");
                    Console.WriteLine("Система завантажена з system.json");
                    break;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

}
