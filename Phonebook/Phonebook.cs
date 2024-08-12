using System.Text.Json;

namespace Phonebook
{
  internal class Phonebook
  {
    private static Dictionary<string, string> abonents;
    private static Phonebook instance;

    private Phonebook() { }
    public static Phonebook GetInstance()
    {
      if (instance == null)
      {
        instance = new Phonebook();
        abonents = LoadAbonentsFromFile();
      }

      return instance;
    }

    private static Dictionary<string, string> LoadAbonentsFromFile()
    {
      Dictionary<string, string> abonents = new Dictionary<string, string>();

      if (File.Exists("phonebook.txt"))
      {
        try
        {
          using (StreamReader sr = new StreamReader("phonebook.txt"))
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
        File.Create("phonebook.txt").Dispose();
      }

      return abonents;
    }

    /// <summary>
    /// Добавляет нового абонента в телефонную книгу.
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
    /// <returns>Абонента если найден, иначе null.</returns>
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
    /// <returns>Абонента если найден, иначе null.</returns>
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

    private void SaveAbonentsToFile()
    {
      using StreamWriter sw = new("phonebook.txt", false);
      foreach (var abonent in abonents)
      {
        sw.WriteLine(JsonSerializer.Serialize(new Abonent(abonent.Value, abonent.Key)));
      }
    }
  }
}
