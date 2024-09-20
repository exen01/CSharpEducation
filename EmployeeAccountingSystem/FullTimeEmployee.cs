namespace EmployeeAccountingSystem;

/// <summary>
/// Представляет штатного сотрудника.
/// </summary>
public class FullTimeEmployee : Employee
{
  /// <summary>
  /// Рассчитывает зарплату сотрудника.
  /// </summary>
  /// <returns>Текущая зарплата сотрудника.</returns>
  protected override decimal CalculateSalary()
  {
    return BaseSalary;
  }

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="name">Имя сотрудника.</param>
  /// <param name="baseSalary">Базовая зарплата.</param>
  public FullTimeEmployee(string name, decimal baseSalary) : base(name, baseSalary)
  {
  }
}