namespace UserAccountingSystem;

/// <summary>
/// Представляет класс для управления списком пользователей.
/// </summary>
public class UserManager
{
  /// <summary>
  /// Список пользователей.
  /// </summary>
  private readonly List<User> _users;

  /// <summary>
  /// Конструктор.
  /// </summary>
  public UserManager()
  {
    _users = new List<User>();
  }

  /// <summary>
  /// Добавляет нового пользователя в список.
  /// </summary>
  /// <param name="user">Объект типа <see cref="User"/></param>
  /// <exception cref="UserAlreadyExistsException">Пользователь уже существует</exception>
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
  /// Удаляет пользователя из списка.
  /// </summary>
  /// <param name="userId">Идентификатор пользователя</param>
  /// <exception cref="UserNotFoundException">Пользователь не найден</exception>
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
  /// <param name="userId">Идентификатор пользователя</param>
  /// <returns>Объект типа <see cref="User"/></returns>
  /// <exception cref="UserNotFoundException">Пользователь не найден</exception>
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
  /// Возвращает список пользователей.
  /// </summary>
  /// <returns>Список пользователей</returns>
  public List<User> ListUsers()
  {
    return _users;
  }
}