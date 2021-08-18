using System;

namespace Telephony.Models
{
  public class PhoneNumber
  {
    private readonly string fullNumber;

    public string CountryCode { get; private set; }

    public string Number { get; private set; }

    public string FullNumber => this.fullNumber;

    public override bool Equals(object obj)
    {
      if (obj is PhoneNumber otherNumber)
        return this.FullNumber.Equals(otherNumber.FullNumber, StringComparison.InvariantCultureIgnoreCase);

      return false;
    }

    public override int GetHashCode()
    {
      return this.fullNumber.GetHashCode();
    }

    public PhoneNumber(string countryCode, string number)
    {
      this.CountryCode = countryCode;
      this.Number = number;
      this.fullNumber = (this.CountryCode + this.Number).ToLower();
    }

  }
}
