namespace EmployeeAccountingSystem;

internal class Program
{
  private static readonly EmployeeManager<Employee> EmployeeManager = new EmployeeManager<Employee>();

  static void Main(string[] args)
  {
    bool running = true;

    while (running)
    {
      Console.Clear();
      Console.WriteLine("Система учета сотрудников");
      Console.WriteLine("1. Добавить полного сотрудника");
      Console.WriteLine("2. Добавить частичного сотрудника");
      Console.WriteLine("3. Получить информацию о сотруднике");
      Console.WriteLine("4. Обновить данные сотрудника");
      Console.WriteLine("0. Выйти");
      Console.Write("Выберите опцию: ");

      string option = Console.ReadLine();

      switch (option)
      {
        case "1":
          AddFullTimeEmployee();
          break;
        case "2":
          AddPartTimeEmployee();
          break;
        case "3":
          GetEmployeeInfo();
          break;
        case "4":
          UpdateEmployeeInfo();
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
  /// Обновляет информацию о сотруднике.
  /// </summary>
  private static void UpdateEmployeeInfo()
  {
    string name;
    string salary;
    string hours;
    Employee employee;

    Console.WriteLine("Выберите тип сотрудника (1 - полного сотрудника, 2 - частичного сотрудника):");
    string type = Console.ReadLine();

    switch (type)
    {
      case "1":
        Console.Write("Введите имя сотрудника: ");
        name = Console.ReadLine();
        Console.Write("Введите базовую зарплату: ");
        salary = Console.ReadLine();
        employee = new FullTimeEmployee(name, Convert.ToDecimal(salary));

        try
        {
          EmployeeManager.Update(employee);
        }
        catch (ArgumentException e)
        {
          Console.WriteLine(e.Message);
        }

        break;
      case "2":
        Console.Write("Введите имя сотрудника: ");
        name = Console.ReadLine();
        Console.WriteLine("Введите базовую зарплату: ");
        salary = Console.ReadLine();
        Console.Write("Введите рабочие часы сотрудника: ");
        hours = Console.ReadLine();
        employee = new PartTimeEmployee(Convert.ToInt32(hours), name, Convert.ToDecimal(salary));

        try
        {
          EmployeeManager.Update(employee);
        }
        catch (ArgumentException e)
        {
          Console.WriteLine(e.Message);
        }

        break;
      default:
        Console.WriteLine("Не известный тип сотрудника, попробуйте снова");
        break;
    }
  }

  /// <summary>
  /// Выводит информацию о сотруднике.
  /// </summary>
  private static void GetEmployeeInfo()
  {
    Console.Write("Введите имя сотрудника: ");
    string name = Console.ReadLine();

    var employee = EmployeeManager.Get(name);
    if (employee != null)
    {
      Console.WriteLine(employee);
    }
    else
    {
      Console.WriteLine("Сотрудник не найден.");
    }
  }

  /// <summary>
  /// Добавляет нового частичного сотрудника.
  /// </summary>
  private static void AddPartTimeEmployee()
  {
    Console.Write("Введите имя сотрудника: ");
    string name = Console.ReadLine();
    Console.Write("Введите количество рабочих часов сотрудника: ");
    string hours = Console.ReadLine();
    Console.Write("Введите базовую зарплату: ");
    string salary = Console.ReadLine();

    PartTimeEmployee partTimeEmployee = new PartTimeEmployee(Convert.ToInt32(hours), name, Convert.ToDecimal(salary));
    try
    {
      EmployeeManager.Add(partTimeEmployee);
    }
    catch (ArgumentException e)
    {
      Console.WriteLine(e.Message);
    }
  }

  /// <summary>
  /// Добавляет нового полного сотрудника.
  /// </summary>
  private static void AddFullTimeEmployee()
  {
    Console.Write("Введите имя сотрудника: ");
    string name = Console.ReadLine();
    Console.Write("Введите базовую зарплату: ");
    string salary = Console.ReadLine();

    FullTimeEmployee fullTimeEmployee = new FullTimeEmployee(name, Convert.ToDecimal(salary));
    try
    {
      EmployeeManager.Add(fullTimeEmployee);
    }
    catch (ArgumentException e)
    {
      Console.WriteLine(e.Message);
    }
  }
}