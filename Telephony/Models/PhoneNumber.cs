using System;

namespace Telephony.Models
{
  class PhoneNumber
  {
    private readonly string fullNumber;

    public string CountryCode { get; private set; }

    public string Number { get; private set; }

    public string FullNumber => fullNumber;

    public override bool Equals(object obj)
    {
      if (obj is PhoneNumber otherNumber)
        return this.FullNumber.Equals(otherNumber.FullNumber, StringComparison.InvariantCultureIgnoreCase);

      return false;
    }

    public override int GetHashCode()
    {
      return fullNumber.GetHashCode();
    }

    public PhoneNumber(string countryCode, string number)
    {
      CountryCode = countryCode;
      Number = number;
      fullNumber = (CountryCode + Number).ToLower();
    }

  }
}
