namespace EmployeeAccountingSystem;

/// <summary>
/// Управляет списком сотрудников.
/// </summary>
/// <typeparam name="T">Тип сотрудника, производный от <see cref="Employee"/>.</typeparam>
public class EmployeeManager<T> : IEmployeeManager<T> where T : Employee
{
  #region Поля и свойства

  /// <summary>
  /// Список сотрудников, где ключ - это имя сотрудника, а значение - это объект типа <see cref="T"/>
  /// </summary>
  private readonly Dictionary<string, T> _employees = new Dictionary<string, T>();

  #endregion

  #region Методы

  public void Add(T employee)
  {
    if (!_employees.TryAdd(employee.Name, employee))
    {
      throw new ArgumentException("Не удалось добавить сотрудника. Сотрудник с таким именем уже существует.");
    }
  }

  public T? Get(string name)
  {
    return _employees.SingleOrDefault(e => e.Key == name).Value;
  }

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
      throw new ArgumentException("Не удалось обновить данные сотрудника. Сотрудника с таким именем не существует.");
    }
  }

  #endregion
}