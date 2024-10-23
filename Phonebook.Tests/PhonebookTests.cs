namespace Phonebook.Tests;

public class PhonebookTests
{
  private Phonebook phonebook;

  [OneTimeSetUp]
  public void OneTimeSetUp()
  {
    this.phonebook = new Phonebook();
  }

  [TearDown]
  public void TearDown()
  {
    this.phonebook.ClearPhonebookList();
  }

  [OneTimeTearDown]
  public void OneTimeTearDown()
  {
    this.phonebook = null;
  }

  [TestCase("62C6C8E7-6963-4152-8A72-339CA76DF5A5", "John Doe")]
  public void AddSubscriber_NewSubscriber_AddedSuccessfully(string id, string name)
  {
    Guid guid = Guid.Parse(id);
    var expectedSubscriber = new Subscriber(guid, name, new List<PhoneNumber>());

    this.phonebook.AddSubscriber(expectedSubscriber);

    Assert.That(this.phonebook.GetSubscriber(guid), Is.EqualTo(expectedSubscriber));
  }

  [Test]
  public void CreateSubscriber_WithEmptyId_ThrowsException()
  {
    Guid subscriberId = Guid.Empty;
    string subscriberName = string.Empty;

    Assert.Throws<ArgumentNullException>(() => new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>()));
  }

  [Test]
  public void AddSubscriber_ExistingSubscriber_ThrowsException()
  {
    Guid subscriberId = Guid.NewGuid();
    string subscriberName = "John Doe";
    var existingSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());

    this.phonebook.AddSubscriber(existingSubscriber);

    Assert.Throws<InvalidOperationException>(() => { this.phonebook.AddSubscriber(existingSubscriber); });
  }

  [Test]
  public void GetSubscriber_ExistingSubscriber_ReturnsSubscriber()
  {
    Guid subscriberId = Guid.NewGuid();
    string subscriberName = "John Doe";
    var expectedSubscriber = new Subscriber(subscriberId, subscriberName, new List<PhoneNumber>());
    this.phonebook.AddSubscriber(expectedSubscriber);

    var actualSubscriber = this.phonebook.GetSubscriber(subscriberId);

    Assert.That(actualSubscriber, Is.EqualTo(expectedSubscriber));
  }

  [Test]
  public void GetSubscriber_NonExistentSubscriber_ThrowsException()
  {
    Guid nonExistentSubscriberId = Guid.NewGuid();

    Assert.Throws<InvalidOperationException>(() => { this.phonebook.GetSubscriber(nonExistentSubscriberId); });
  }

  [Test]
  public void GetAll_Subscribers_ReturnsCorrectList()
  {
    var subscriber1 = new Subscriber(Guid.NewGuid(), "John Doe", new List<PhoneNumber>());
    var subscriber2 = new Subscriber(Guid.NewGuid(), "Jane Smith", new List<PhoneNumber>());
    var expectedList = new List<Subscriber> { subscriber1, subscriber2 };

    var actualListEmpty = this.phonebook.GetAll();
    Assert.That(actualListEmpty, Is.Empty);

    this.phonebook.AddSubscriber(subscriber1);
    this.phonebook.AddSubscriber(subscriber2);

    var actualList = this.phonebook.GetAll();
    Assert.That(actualList, Is.EquivalentTo(expectedList));
  }

  [Test]
  public void AddNumberToSubscriber_ValidSubscriber_AddPhoneNumberSuccessfully()
  {
    var subscriber = new Subscriber(Guid.NewGuid(), "John Doe", new List<PhoneNumber>());
    var phoneNumber = new PhoneNumber("+123456789", PhoneNumberType.Personal);
    this.phonebook.AddSubscriber(subscriber);

    this.phonebook.AddNumberToSubscriber(subscriber, phoneNumber);

    var updatedSubscriber = this.phonebook.GetSubscriber(subscriber.Id);
    Assert.That(updatedSubscriber.PhoneNumbers, Contains.Item(phoneNumber));
  }

  [Test]
  public void AddNumberToSubscriber_NonExistentSubscriber_ThrowsException()
  {
    var nonExistentSubscriber = new Subscriber(Guid.NewGuid(), "Jane Smith", new List<PhoneNumber>());
    var phoneNumber = new PhoneNumber("+987654321", PhoneNumberType.Personal);

    Assert.Throws<InvalidOperationException>(() =>
      this.phonebook.AddNumberToSubscriber(nonExistentSubscriber, phoneNumber));
  }

  [TestCase("")]
  [TestCase("Jane Doe")]
  public void RenameSubscriber_ValidSubscriber_ChangesName(string name)
  {
    var subscriber = new Subscriber(Guid.NewGuid(), "John Doe", new List<PhoneNumber>());
    this.phonebook.AddSubscriber(subscriber);
    var newName = name;

    this.phonebook.RenameSubscriber(subscriber, newName);

    var updatedSubscriber = this.phonebook.GetSubscriber(subscriber.Id);
    Assert.That(updatedSubscriber.Name, Is.EqualTo(newName));
  }

  [Test]
  public void RenameSubscriber_NonExistentSubscriber_ThrowsException()
  {
    var nonExistentSubscriber = new Subscriber(Guid.NewGuid(), "NonExistent", new List<PhoneNumber>());
    var newName = "New Name";

    Assert.Throws<InvalidOperationException>(() => this.phonebook.RenameSubscriber(nonExistentSubscriber, newName));
  }

  [Test]
  public void UpdateSubscriber_ExistingSubscriber_UpdatesSuccessfully()
  {
    var subscriber = new Subscriber(Guid.NewGuid(), "John Doe", new List<PhoneNumber>());
    this.phonebook.AddSubscriber(subscriber);

    var updatedSubscriber =
      new Subscriber(subscriber.Id, "Jane Doe",
        new List<PhoneNumber> { new PhoneNumber("123456789", PhoneNumberType.Personal) });

    this.phonebook.UpdateSubscriber(subscriber, updatedSubscriber);

    var resultSubscriber = this.phonebook.GetSubscriber(subscriber.Id);
    Assert.That(resultSubscriber.Name, Is.EqualTo("Jane Doe"));
    Assert.That(resultSubscriber.PhoneNumbers.Count, Is.EqualTo(1));
    Assert.That(resultSubscriber.PhoneNumbers[0].Number, Is.EqualTo("123456789"));
    Assert.That(resultSubscriber.PhoneNumbers[0].Type, Is.EqualTo(PhoneNumberType.Personal));
  }

  [Test]
  public void UpdateSubscriber_NonExistentSubscriber_ThrowsException()
  {
    var nonExistentSubscriber = new Subscriber(Guid.NewGuid(), "NonExistent", new List<PhoneNumber>());
    var updatedSubscriber = new Subscriber(nonExistentSubscriber.Id, "Updated Name", new List<PhoneNumber>());

    Assert.Throws<InvalidOperationException>(() =>
      this.phonebook.UpdateSubscriber(nonExistentSubscriber, updatedSubscriber));
  }

  [Test]
  public void DeleteSubscriber_ExistingSubscriber_DeletesSuccessfully()
  {
    var subscriber = new Subscriber(Guid.NewGuid(), "John Doe", new List<PhoneNumber>());
    this.phonebook.AddSubscriber(subscriber);

    this.phonebook.DeleteSubscriber(subscriber);

    Assert.Throws<InvalidOperationException>(() => this.phonebook.GetSubscriber(subscriber.Id));
  }

  [Test]
  public void DeleteSubscriber_NonExistentSubscriber_NoChange()
  {
    var existingSubscriber = new Subscriber(Guid.NewGuid(), "Jane Doe", new List<PhoneNumber>());
    this.phonebook.AddSubscriber(existingSubscriber);

    var nonExistentSubscriber = new Subscriber(Guid.NewGuid(), "John Smith", new List<PhoneNumber>());

    this.phonebook.DeleteSubscriber(nonExistentSubscriber);

    var allSubscribers = this.phonebook.GetAll().ToList();
    Assert.That(allSubscribers.Count, Is.EqualTo(1));
    Assert.That(allSubscribers[0], Is.EqualTo(existingSubscriber));
  }
}