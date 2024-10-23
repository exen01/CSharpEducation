namespace Phonebook.Tests;

public class PhoneNumberValidatorTests
{
  [TestCase("+1 (123) 456-7890")]
  [TestCase("+44 (789) 654-3210")]
  public void ValidatePhoneNumber_ValidPhoneNumber_ValidatedSuccessfully(string phoneNumber)
  {
    var validPhoneNumber = new PhoneNumber(phoneNumber, PhoneNumberType.Personal);

    Assert.DoesNotThrow(() => PhoneNumberValidator.Validate(validPhoneNumber));
  }

  [TestCase("")]
  [TestCase("+1 1234567890")]
  [TestCase("123-456-7890")]
  [TestCase("+1 (123) 4567-890")]
  public void Validate_InvalidPhoneNumber_ThrowsException(string phoneNumber)
  {
    var invalidPhone = new PhoneNumber(phoneNumber, PhoneNumberType.Personal);

    var ex = Assert.Throws<ArgumentException>(() => PhoneNumberValidator.Validate(invalidPhone));
    Assert.That(ex.Message, Is.EqualTo("Phone number is invalid"));
  }
}