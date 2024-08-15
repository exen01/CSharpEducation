namespace Phonebook
{
  /// <summary>
  /// Представляет информацию об одном абоненте телефонной книги.
  /// </summary>
  internal struct Abonent
  {
    public Abonent()
    {
    }

    /// <summary>
    /// Имя абонента.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Номер телефона абонента.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Создает новый экземпляр структуры Abonent с указанными именем и номером телефона.
    /// </summary>
    /// <param name="name">Имя абонента.</param>
    /// <param name="phone">Номер телефона абонента.</param>
    public Abonent(string name, string phone)
    {
      Name = name;
      Phone = phone;
    }
  }
}
