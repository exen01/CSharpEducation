namespace UserAccountingSystem;

/// <summary>
/// Управляет списком пользователей.
/// </summary>
public class UserManager
{
  #region Поля и свойства

  /// <summary>
  /// Список пользователей.
  /// </summary>
  private readonly List<User> _users;

  #endregion

  #region Методы

  /// <summary>
  /// Добавляет нового пользователя в список.
  /// </summary>
  /// <param name="user">Объект типа <see cref="User"/> для добавления.</param>
  /// <exception cref="UserAlreadyExistsException">Выбрасывается, если пользователь с таким ID уже существует.</exception>
  public void AddUser(User user)
  {
    if (_users.SingleOrDefault(u => u.Id == user.Id) == null)
    {
      _users.Add(user);
    }
    else
    {
      throw new UserAlreadyExistsException("Пользователь с таким ID уже существует.");
    }
  }

  /// <summary>
  /// Удаляет пользователя из списка по идентификатору.
  /// </summary>
  /// <param name="userId">Идентификатор пользователя для удаления.</param>
  /// <exception cref="UserNotFoundException">Выбрасывается, если пользователь с указанным ID не найден.</exception>
  public void RemoveUser(int userId)
  {
    var user = _users.SingleOrDefault(u => u.Id == userId);
    if (user != null)
    {
      _users.Remove(user);
    }
    else
    {
      throw new UserNotFoundException("Пользователь с таким ID не найден.");
    }
  }

  /// <summary>
  /// Получает пользователя из списка по идентификатору.
  /// </summary>
  /// <param name="userId">Идентификатор пользователя для поиска.</param>
  /// <returns>Объект типа <see cref="User"/>.</returns>
  /// <exception cref="UserNotFoundException">Выбрасывается, если пользователь с указанным ID не найден.</exception>
  public User GetUser(int userId)
  {
    var user = _users.SingleOrDefault(u => u.Id == userId);
    if (user != null)
    {
      return user;
    }

    throw new UserNotFoundException("Пользователь с таким ID не найден.");
  }

  /// <summary>
  /// Возвращает список всех пользователей.
  /// </summary>
  /// <returns>Список объектов типа <see cref="User"/>.</returns>
  public List<User> ListUsers()
  {
    return _users;
  }

  #endregion

  #region Конструкторы

  /// <summary>
  /// Конструктор.
  /// </summary>
  public UserManager()
  {
    _users = new List<User>();
  }

  #endregion
}