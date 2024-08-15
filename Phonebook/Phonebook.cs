using System.Text.Json;

namespace Phonebook
{
  /// <summary>
  /// Представляет телефонную книгу, позволяющую добавлять, удалять, искать и обновлять контакты.
  /// Данные о контактах хранятся в файле "phonebook.txt" в формате JSON.
  /// </summary>
  internal class Phonebook
  {
    /// <summary>
    /// Словарь, хранящий информацию об абонентах телефонной книги.
    /// Ключом в словаре является номер телефона, а значением - имя абонента.
    /// </summary>
    private static Dictionary<string, string> abonents;

    /// <summary>
    /// Единственный экземпляр класса Phonebook.
    /// Используется для реализации паттерна Singleton.
    /// </summary>
    private static Phonebook instance;

    /// <summary>
    /// Имя файла для сохранения списка абонентов.
    /// </summary>
    private const string FileName = "phonebook.txt";

    private Phonebook() { }

    /// <summary>
    /// Получение экземпляра типа Phonebook.
    /// </summary>
    /// <returns>Объект Phonebook.</returns>
    public static Phonebook GetInstance()
    {
      if (instance == null)
      {
        instance = new Phonebook();
        abonents = LoadAbonentsFromFile();
      }

      return instance;
    }

    /// <summary>
    /// Загружает словарь абонентов из файла.
    /// </summary>
    /// <returns>Словарь абонентов.</returns>
    private static Dictionary<string, string> LoadAbonentsFromFile()
    {
      Dictionary<string, string> abonents = new Dictionary<string, string>();

      if (File.Exists(FileName))
      {
        try
        {
          using (StreamReader sr = new StreamReader(FileName))
          {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
              Abonent ab = JsonSerializer.Deserialize<Abonent>(line);
              abonents.Add(ab.Phone, ab.Name);
            }
          }
        }
        catch (Exception e)
        {
          Console.WriteLine("The file could not be read:");
          Console.WriteLine(e.Message);
        }
      }
      else
      {
        File.Create(FileName).Dispose();
      }

      return abonents;
    }

    /// <summary>
    /// Добавляет нового абонента в телефонную книгу.
    /// Если абонент с указанным номером уже существует, то операция не выполняется.
    /// </summary>
    /// <param name="name">Имя абонента</param>
    /// <param name="phone">Номер телефона</param>
    public void CreateAbonent(string name, string phone)
    {
      if (abonents.TryAdd(phone, name))
      {
        SaveAbonentsToFile();
      }
      else
      {
        Console.WriteLine("Абонент с таким номером телефона уже существует");
      }
    }

    /// <summary>
    /// Получает абонента по номеру телефона.
    /// </summary>
    /// <param name="phone">Номер телефона</param>
    /// <returns>Объект <see cref="Abonent"/>, если абонент найден; иначе null.</returns>
    public Abonent? GetAbonentByPhone(string phone)
    {
      if (abonents.TryGetValue(phone, out string name))
      {
        return new Abonent(name, phone);
      }
      else
      {
        Console.WriteLine("Абонента с таким номером не существует.");
      }

      return null;
    }

    /// <summary>
    /// Получает абонента по имени.
    /// </summary>
    /// <param name="name">Имя абонента</param>
    /// <returns>Объект <see cref="Abonent"/>, если абонент найден; иначе null.</returns>
    public Abonent? GetAbonentByName(string name)
    {
      if (abonents.ContainsValue(name))
      {
        string phone = abonents.First(x => x.Value == name).Key;
        return new Abonent(name, phone);
      }
      else
      {
        Console.WriteLine("Абонента с таким именем не существует.");
      }

      return null;
    }

    /// <summary>
    /// Получает список абонентов.
    /// </summary>
    /// <returns>Список абонентов</returns>
    public List<Abonent> GetAbonents()
    {
      return abonents.Select(a => new Abonent { Phone = a.Key, Name = a.Value }).ToList();
    }

    /// <summary>
    /// Удаляет абонента по номеру телефона.
    /// </summary>
    /// <param name="phone">Номер телефона</param>
    public void DeleteAbonent(string phone)
    {
      if (abonents.Remove(phone))
      {
        SaveAbonentsToFile();
        Console.WriteLine($"Абонент с номером {phone} удален.");
      }
      else
      {
        Console.WriteLine("Абонента с таким номером телефона не существует.");
      }
    }

    /// <summary>
    /// Обновляет имя абонента по номеру телефона.
    /// </summary>
    /// <param name="phone">Номер телефона</param>
    /// <param name="newName">Новое имя абонента</param>
    public void UpdateAbonent(string phone, string newName)
    {
      if (abonents.ContainsKey(phone))
      {
        abonents[phone] = newName;
        SaveAbonentsToFile();
        Console.WriteLine($"Имя абонента с номером {phone} обновлено на {newName}.");
      }
      else
      {
        Console.WriteLine("Абонента с таким номером телефона не существует.");
      }
    }

    /// <summary>
    /// Сохраняет список абонентов в файл.
    /// </summary>
    private void SaveAbonentsToFile()
    {
      using StreamWriter sw = new(FileName, false);
      foreach (var abonent in abonents)
      {
        sw.WriteLine(JsonSerializer.Serialize(new Abonent(abonent.Value, abonent.Key)));
      }
    }
  }
}
