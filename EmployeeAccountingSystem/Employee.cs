namespace EmployeeAccountingSystem;

/// <summary>
/// Представляет информацию о сотруднике.
/// </summary>
public abstract class Employee
{
  #region Поля и свойства

  /// <summary>
  /// Имя сотрудника.
  /// </summary>
  public string Name { get; }

  /// <summary>
  /// Базовая зарплата сотрудника.
  /// </summary>
  public decimal BaseSalary { get; set; }

  #endregion

  #region Методы

  /// <summary>
  /// Рассчитывает зарплату сотрудника.
  /// </summary>
  /// <returns>Текущая зарплата сотрудника.</returns>
  protected abstract decimal CalculateSalary();

  #endregion

  #region Базовый класс

  public override string ToString()
  {
    return $"Имя: {Name}, Базовая зарплата: {BaseSalary}, Текущая зарплата: {CalculateSalary()}";
  }

  #endregion

  #region Конструкторы

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

  #endregion
}