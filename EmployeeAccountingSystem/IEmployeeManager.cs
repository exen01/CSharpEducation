namespace EmployeeAccountingSystem;

/// <summary>
/// Интерфейс для работы с сотрудниками.
/// </summary>
/// <typeparam name="T">Тип сотрудника</typeparam>
public interface IEmployeeManager<T>
{
  void Add(T employee);
  T? Get(string name);
  void Update(T employee);
}