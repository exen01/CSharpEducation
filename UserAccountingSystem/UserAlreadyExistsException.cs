namespace UserAccountingSystem;

/// <summary>
/// Класс исключения для ситуации, когда пользователь не найден.
/// </summary>
public class UserAlreadyExistsException : Exception
{
  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="message">Сообщение</param>
  public UserAlreadyExistsException(string message) : base(message)
  {
  }
}