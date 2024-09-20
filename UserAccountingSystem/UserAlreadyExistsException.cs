namespace UserAccountingSystem;

/// <summary>
/// Исключение, возникающее, когда пользователь с указанным ID уже существует.
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