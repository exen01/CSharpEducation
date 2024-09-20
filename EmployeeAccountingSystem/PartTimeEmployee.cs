namespace EmployeeAccountingSystem;

/// <summary>
/// Представляет неполно занятого сотрудника.
/// </summary>
public class PartTimeEmployee : Employee
{
  #region Поля и свойства

  /// <summary>
  /// Рабочие часы сотрудника.
  /// </summary>
  public int WorkingHours { get; set; }

  #endregion

  #region Базовый класс

  /// <summary>
  /// Рассчитывает зарплату сотрудника.
  /// </summary>
  /// <returns>Текущая зарплата сотрудника.</returns>
  protected override decimal CalculateSalary()
  {
    return WorkingHours * BaseSalary;
  }

  public override string ToString()
  {
    return base.ToString() + $", Рабочие часы: {WorkingHours}";
  }

  #endregion

  #region Конструкторы

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

  #endregion
}