namespace EmployeeAccountingSystem;

/// <summary>
/// Управление сотрудниками.
/// </summary>
/// <typeparam name="T">Тип сотрудника, производный от <see cref="Employee"/>.</typeparam>
public interface IEmployeeManager<T>
{
  /// <summary>
  /// Добавляет сотрудника в список.
  /// </summary>
  /// <param name="employee">Объект сотрудника для добавления.</param>
  void Add(T employee);

  /// <summary>
  /// Получает сотрудника из списка по имени.
  /// </summary>
  /// <param name="name">Имя сотрудника.</param>
  /// <returns>Сотрудник, если найден; в противном случае - null.</returns>
  T? Get(string name);

  /// <summary>
  /// Обновляет данные о сотруднике.
  /// </summary>
  /// <param name="employee">Объект сотрудника с обновленными данными.</param>
  void Update(T employee);
}