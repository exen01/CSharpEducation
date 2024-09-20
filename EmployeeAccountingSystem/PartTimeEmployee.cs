namespace EmployeeAccountingSystem;

/// <summary>
/// Представляет неполно занятого сотрудника.
/// </summary>
public class PartTimeEmployee : Employee
{
  /// <summary>
  /// Рабочие часы сотрудника.
  /// </summary>
  public int WorkingHours { get; set; }

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="workingHours">Рабочие часы</param>
  /// <param name="name">Имя</param>
  /// <param name="salary">Базовая зарплата</param>
  public PartTimeEmployee(int workingHours, string name, decimal salary) : base(name, salary)
  {
    WorkingHours = workingHours;
  }

  /// <summary>
  /// Рассчитывает зарплату сотрудника.
  /// </summary>
  /// <returns>Текущая зарплата сотрудника.</returns>
  protected override decimal CalculateSalary()
  {
    return WorkingHours * BaseSalary;
  }

  /// <summary>
  /// Возвращает текстовое представление сотрудника.
  /// </summary>
  /// <returns>Текстовое представление сотрудника.</returns>
  public override string ToString()
  {
    return base.ToString() + $", Рабочие часы: {WorkingHours}";
  }
}