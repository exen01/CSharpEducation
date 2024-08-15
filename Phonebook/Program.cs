namespace Phonebook
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Phonebook phonebook = Phonebook.GetInstance();
      bool running = true;

      while (running)
      {
        Console.Clear();
        Console.WriteLine("Телефонная книга");
        Console.WriteLine("1. Добавить абонента");
        Console.WriteLine("2. Получить абонента по номеру телефона");
        Console.WriteLine("3. Получить абонента по имени");
        Console.WriteLine("4. Удалить абонента");
        Console.WriteLine("5. Обновить данные абонента");
        Console.WriteLine("6. Показать всех абонентов");
        Console.WriteLine("0. Выйти");
        Console.Write("Выберите опцию: ");

        string option = Console.ReadLine();

        switch (option)
        {
          case "1":
            AddAbonent(phonebook);
            break;

          case "2":
            GetAbonentByPhone(phonebook);
            break;

          case "3":
            GetAbonentByName(phonebook);
            break;

          case "4":
            DeleteAbonent(phonebook);
            break;

          case "5":
            UpdateAbonent(phonebook);
            break;

          case "6":
            ShowAllAbonents(phonebook);
            break;

          case "0":
            running = false;
            break;

          default:
            Console.WriteLine("Неверный выбор. Попробуйте снова.");
            break;
        }

        if (running)
        {
          Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
          Console.ReadKey();
        }
      }
    }

    /// <summary>
    /// Выводит список всех абонентов из телефонной книги.
    /// </summary>
    /// <param name="phonebook">Экземпляр телефонной книги</param>
    private static void ShowAllAbonents(Phonebook phonebook)
    {
      var abonents = phonebook.GetAbonents();

      if (abonents.Count == 0)
      {
        Console.WriteLine("Телефонная книга пуста.");
      }
      else
      {
        Console.WriteLine("Список абонентов:");
        foreach (var abonent in abonents)
        {
          Console.WriteLine($"Имя: {abonent.Name}, Номер телефона: {abonent.Phone}");
        }
      }
    }

    /// <summary>
    /// Обновляет имя абонента в телефонной книге.
    /// </summary>
    /// <param name="phonebook">Экземпляр телефонной книги</param>
    private static void UpdateAbonent(Phonebook phonebook)
    {
      Console.Write("Введите номер телефона абонента для обновления: ");
      string phone = Console.ReadLine();
      Console.Write("Введите новое имя: ");
      string newName = Console.ReadLine();
      phonebook.UpdateAbonent(phone, newName);
    }

    /// <summary>
    /// Удаляет абонента из телефонной книги.
    /// </summary>
    /// <param name="phonebook">Экземпляр телефонной книги</param>
    private static void DeleteAbonent(Phonebook phonebook)
    {
      Console.Write("Введите номер телефона для удаления: ");
      string phone = Console.ReadLine();
      phonebook.DeleteAbonent(phone);
    }

    /// <summary>
    /// Выводит информацию об абоненте по имени из телефонной книги.
    /// </summary>
    /// <param name="phonebook">Экземпляр телефонной книги</param>
    private static void GetAbonentByName(Phonebook phonebook)
    {
      Console.Write("Введите имя абонента: ");
      string name = Console.ReadLine();
      Abonent? abonent = phonebook.GetAbonentByName(name);

      if (abonent != null)
      {
        Console.WriteLine($"Имя: {abonent.Value.Name}, Номер телефона: {abonent.Value.Phone}");
      }
    }

    /// <summary>
    /// Выводит информацию об абоненте по номеру телефона из телефонной книги.
    /// </summary>
    /// <param name="phonebook">Экземпляр телефонной книги</param>
    private static void GetAbonentByPhone(Phonebook phonebook)
    {
      Console.Write("Введите номер телефона: ");
      string phone = Console.ReadLine();
      Abonent? abonent = phonebook.GetAbonentByPhone(phone);

      if (abonent != null)
      {
        Console.WriteLine($"Имя: {abonent.Value.Name}, Номер телефона: {abonent.Value.Phone}");
      }
    }

    /// <summary>
    /// Добавляет нового абонента в телефонную книгу.
    /// </summary>
    /// <param name="phonebook">Экземпляр телефонной книги</param>
    private static void AddAbonent(Phonebook phonebook)
    {
      Console.Write("Введите имя абонента: ");
      string name = Console.ReadLine();
      Console.Write("Введите номер телефона: ");
      string phone = Console.ReadLine();
      phonebook.CreateAbonent(name, phone);
    }
  }
}
