namespace EmployeeAccountingSystem;

/// <summary>
/// Представляет класс для работы с сотрудниками.
/// </summary>
/// <typeparam name="T">Тип сотрудника</typeparam>
public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
{
  /// <summary>
  /// Список сотрудников, где ключ - это имя сотрудника, а значение - это объект типа <see cref="T"/>
  /// </summary>
  private readonly Dictionary<string, T> _employees = new Dictionary<string, T>();

  /// <summary>
  /// Добавляет сотрудника в список.
  /// </summary>
  /// <param name="employee">Объект сотрудника</param>
  public void Add(T employee)
  {
    Console.WriteLine(_employees.TryAdd(employee.Name, employee)
      ? "Сотрудник успешно добавлен."
      : "Не удалось добавить сотрудника. Сотрудник с таким именем уже существует.");
  }

  /// <summary>
  /// Получает сотрудника из списка по имени.
  /// </summary>
  /// <param name="name">Имя сотрудника</param>
  /// <returns>Сотрудника, если не найден, то null</returns>
  public T? Get(string name)
  {
    return _employees.SingleOrDefault(e => e.Key == name).Value;
  }

  /// <summary>
  /// Обновляет данные о сотруднике.
  /// </summary>
  /// <param name="employee"></param>
  public void Update(T employee)
  {
    if (_employees.TryGetValue(employee.Name, out var employeeFromList))
    {
      employeeFromList.BaseSalary = employee.BaseSalary;

      if (employee is PartTimeEmployee newPartTimeEmployee &&
          employeeFromList is PartTimeEmployee existingPartTimeEmployee)
      {
        existingPartTimeEmployee.WorkingHours = newPartTimeEmployee.WorkingHours;
      }
    }
    else
    {
      Console.WriteLine("Не удалось обновить данные сотрудника. Сотрудника с таким именем не существует.");
    }
  }
}