namespace UserAccountingSystem;

/// <summary>
/// Представляет информацию о пользователе.
/// </summary>
public class User
{
  #region Поля и свойства

  /// <summary>
  /// Идентификатор пользователя.
  /// </summary>
  public int Id { get; set; }

  /// <summary>
  /// Имя пользователя.
  /// </summary>
  public string Name { get; set; }

  /// <summary>
  /// Адрес электронной почты.
  /// </summary>
  public string Email { get; set; }

  #endregion

  #region Базовый класс

  /// <summary>
  /// Возвращает строковое представление пользователя.
  /// </summary>
  /// <returns>Строковое представление пользователя</returns>
  public override string ToString() => $"User: {Id}, {Name}, {Email}";

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  /// <param name="id">Идентификатор</param>
  /// <param name="name">Имя</param>
  /// <param name="email">Электронная почта</param>
  public User(int id, string name, string email)
  {
    Id = id;
    Name = name;
    Email = email;
  }

  #endregion
}