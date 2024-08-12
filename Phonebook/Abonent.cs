namespace Phonebook
{
  internal struct Abonent
  {
    public Abonent()
    {
    }

    public string Name { get; set; }
    public string Phone { get; set; }

    public Abonent(string name, string phone)
    {
      Name = name;
      Phone = phone;
    }
  }
}
