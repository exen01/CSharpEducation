namespace EmployeeAccountingSystem;

/// <summary>
/// Базовый класс представляющий сотрудника.
/// </summary>
public abstract class Employee
{
  /// <summary>
  /// Имя сотрудника.
  /// </summary>
  public string Name { get; }
  
  /// <summary>
  /// Базовая зарплата сотрудника.
  /// </summary>
  public decimal BaseSalary { get; set; }

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="name">Имя сотрудника.</param>
  /// <param name="baseSalary">Базовая зарплата сотрудника.</param>
  protected Employee(string name, decimal baseSalary)
  {
    Name = name;
    BaseSalary = baseSalary;
  }

  /// <summary>
  /// Рассчитывает зарплату сотрудника.
  /// </summary>
  /// <returns>Текущая зарплата сотрудника.</returns>
  protected abstract decimal CalculateSalary();

  /// <summary>
  /// Возвращает текстовое представление сотрудника.
  /// </summary>
  /// <returns>Текстовое представление сотрудника.</returns>
  public override string ToString()
  {
    return $"Имя: {Name}, Базовая зарплата: {BaseSalary}, Текущая зарплата: {CalculateSalary()}";
  }
}