using System;

namespace Telephony.Models
{
  public class PhoneNumber
  {
    private readonly string fullNumber;

    public string CountryCode { get; }

    public string Number { get; }

    public string FullNumber => this.fullNumber;

    public PhoneNumber(string countryCode, string number)
    {
      this.CountryCode = countryCode;
      this.Number = number;
      this.fullNumber = (this.CountryCode + this.Number).ToLower();
    }

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
  }
}
