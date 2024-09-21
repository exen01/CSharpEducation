namespace UserAccountingSystem;

class Program
{
  static void Main(string[] args)
  {
    UserManager manager = new UserManager();
    bool running = true;

    while (running)
    {
      Console.Clear();
      Console.WriteLine("Система управления пользователями");
      Console.WriteLine("1. Добавить нового пользователя");
      Console.WriteLine("2. Удалить пользователя");
      Console.WriteLine("3. Вывести список пользователей");
      Console.WriteLine("4. Вывести информацию о пользователе");
      Console.WriteLine("0. Выйти");
      Console.Write("Выберите опцию: ");

      string option = Console.ReadLine();

      switch (option)
      {
        case "1":
          AddUser(manager);
          break;
        case "2":
          RemoveUser(manager);
          break;
        case "3":
          PrintUserList(manager);
          break;
        case "4":
          PrintUser(manager);
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
  /// Выводит информацию о пользователе на консоль.
  /// </summary>
  /// <param name="manager">Объект <see cref="UserManager"/></param>
  private static void PrintUser(UserManager manager)
  {
    Console.WriteLine("Введите ID пользователя, для которого нужно вывести информацию:");
    string id = Console.ReadLine();

    if (int.TryParse(id, out int userId))
    {
      try
      {
        var user = manager.GetUser(userId);
        Console.WriteLine(user);
      }
      catch (UserNotFoundException e)
      {
        Console.WriteLine(e.Message);
      }
    }
    else
    {
      Console.WriteLine("Не удалось распознать ID пользователя.");
    }
  }

  /// <summary>
  /// Добавляет пользователя в список.
  /// </summary>
  /// <param name="manager">Объект <see cref="UserManager"/></param>
  private static void AddUser(UserManager manager)
  {
    Console.WriteLine("Введите ID пользователя:");
    string id = Console.ReadLine();
    Console.WriteLine("Введите имя пользователя:");
    string name = Console.ReadLine();
    Console.WriteLine("Введите email пользователя:");
    string email = Console.ReadLine();

    var user = new User(Convert.ToInt32(id), name, email);
    try
    {
      manager.AddUser(user);
    }
    catch (UserAlreadyExistsException e)
    {
      Console.WriteLine(e.Message);
    }
  }

  /// <summary>
  /// Удаляет пользователя из списка.
  /// </summary>
  /// <param name="manager">Объект <see cref="UserManager"/></param>
  private static void RemoveUser(UserManager manager)
  {
    Console.WriteLine("Введите ID пользователя, которого хотите удалить:");
    string id = Console.ReadLine();
    if (int.TryParse(id, out int userId))
    {
      try
      {
        manager.RemoveUser(userId);
      }
      catch (UserNotFoundException e)
      {
        Console.WriteLine(e.Message);
      }
    }
    else
    {
      Console.WriteLine("Не удалось распознать ID пользователя.");
    }
  }

  /// <summary>
  /// Выводит список пользователей на консоль.
  /// </summary>
  /// <param name="manager">Объект <see cref="UserManager"/></param>
  private static void PrintUserList(UserManager manager)
  {
    var listUsers = manager.ListUsers();
    foreach (var user in listUsers)
    {
      Console.WriteLine(user);
    }
  }
}